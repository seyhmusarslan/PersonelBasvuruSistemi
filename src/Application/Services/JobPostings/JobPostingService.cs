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
        private readonly IMapper _mapper;

        public JobPostingService(IJobPostingRepositoryAsync jobPostingRepository, 
        IMapper mapper)
        {
            _jobPostingRepository = jobPostingRepository;
            _mapper = mapper;
        }

        public async Task<ResponseMessageDto> CreateJobPostingAsync(JobPostingInputDto input)
        {
            //check input if null then throw exception
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            if(input.JobTypeId == 0){
                return new ResponseMessageDto
                {
                    Message = "İlan ekleme işlemi başarısız",
                    IsSuccess = false,
                    Errors = new List<string> {"Job Type Id is required"}
                };
            }
            var jobPosting = _mapper.Map<JobPosting>(input);
            var addedPosting =await _jobPostingRepository.AddAsync(jobPosting);
            return new ResponseMessageDto
            {
                Data = _mapper.Map<JobPostingOutputDto>(addedPosting),
                Message = "Job Posting Created Successfully",
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
            await _jobPostingRepository.UpdateAsync(jobPosting);
            return new ResponseMessageDto
            {
                Data = _mapper.Map<JobPostingOutputDto>(jobPosting),
                Message = "İlan güncellendi",
                IsSuccess = true
            };
        }
    }
}
