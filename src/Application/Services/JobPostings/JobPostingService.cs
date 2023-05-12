using System;
using Application.Dto.Common;
using Application.Dto.JobPosting;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.JobPostings
{
    public class JobPostingService : IJobPostingService
    {
        private readonly IJobPostingRepositoryAsync _jobPostingRepository;
        private readonly IJobTypeRepositoryAsync _jobTypeRepository;
        private readonly IMapper _mapper;

        public JobPostingService(IJobPostingRepositoryAsync jobPostingRepository,
        IMapper mapper,
        IJobTypeRepositoryAsync jobTypeRepository)
        {
            _jobPostingRepository = jobPostingRepository;
            _mapper = mapper;
            _jobTypeRepository = jobTypeRepository;
        }

        public async Task<ResponseMessageDto> CreateJobPostingAsync(JobPostingInputDto input)
        {
            //check input if null then throw exception
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            //check if job type exists
            var jobType = await _jobTypeRepository.GetByIdAsync(input.JobTypeId);
            if(jobType == null)
                return new ResponseMessageDto
                {
                    Message = "İlan ekleme işlemi başarısız.İlan türü bulunamadı",
                    IsSuccess = false,
                    Errors = new List<string> {"Job Type not found"}
                };
            if(input.JobTypeId == 0){
                return new ResponseMessageDto
                {
                    Message = "İlan ekleme işlemi başarısız",
                    IsSuccess = false,
                    Errors = new List<string> {"JobTypeId is required"}
                };
            }
            var jobPosting = _mapper.Map<JobPosting>(input);
            var addedPosting =await _jobPostingRepository.AddAsync(jobPosting);
            return new ResponseMessageDto
            {
                Data = _mapper.Map<JobPostingOutputDto>(addedPosting),
                Message = "İlan başarıyla eklendi",
                IsSuccess = true
            };
        }

        public async Task<ResponseMessageDto> DeleteJobPostingByIdAsync(int id)
        {
            var jobPosting = await _jobPostingRepository.GetByIdAsync(id);
            if(jobPosting == null)
                return new ResponseMessageDto
                {
                    Message = "İlan bulunamadı",
                    IsSuccess = false,
                    Errors = new List<string> {"Job Posting not found"}
                };
            
            await _jobPostingRepository.DeleteAsync(jobPosting);
            return new ResponseMessageDto
            {
                Message = "İlan silindi",
                IsSuccess = true
            };

        }

        public async Task<ResponseMessageDto> GetJobPostingByIdAsync(int id)
        {
            var jobPosting =await _jobPostingRepository.GetByIdAsync(id);
            if(jobPosting == null)
                return new ResponseMessageDto
                {
                    Message = "İlan bulunamadı",
                    IsSuccess = false,
                    Errors = new List<string> {"Job Posting not found"}
                };
           return  new ResponseMessageDto
            {
                Data = _mapper.Map<JobPostingOutputDto>(jobPosting),
                Message = "İlan bulundu",
                IsSuccess = true
            };
        }

        public async Task<ResponseMessageDto> GetJobPostingsAsync()
        {
            var jobPostings =await _jobPostingRepository.ListAllAsync();
            return new ResponseMessageDto
            {
                Data = _mapper.Map<List<JobPostingOutputDto>>(jobPostings),
                Message = "İlanlar listelendi",
                IsSuccess = true
            };

        }

        public async Task<ResponseMessageDto> UpdateJobPostingAsync(int id ,JobPostingInputDto input)
        {
            var jobPosting = await _jobPostingRepository.GetByIdAsync(id);
            if(jobPosting == null)
                return new ResponseMessageDto
                {
                    Message = "İlan bulunamadı",
                    IsSuccess = false,
                    Errors = new List<string> {"Job Posting not found"}
                };
            var updatedJobPosting = _mapper.Map<JobPosting>(input);
            await _jobPostingRepository.UpdateAsync(updatedJobPosting);
            return new ResponseMessageDto
            {
                Data = _mapper.Map<JobPostingOutputDto>(updatedJobPosting),
                Message = "İlan güncellendi",
                IsSuccess = true
            };
        }
    }
}
