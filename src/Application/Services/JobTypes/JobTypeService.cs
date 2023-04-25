using System;
using Application.Dto.Common;
using Application.Dto.JobType;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.JobTypes
{
    public class JobTypeService : IJobTypeService
    {
        private readonly IJobTypeRepositoryAsync _jobTypeRepository;
        private readonly IJobPostingRepositoryAsync _jobRepository;
        private readonly IMapper _mapper;

        public JobTypeService(IJobTypeRepositoryAsync jobTypeRepository, IJobPostingRepositoryAsync jobRepository, IMapper mapper)
        {
            _jobTypeRepository = jobTypeRepository;
            _jobRepository = jobRepository;
            _mapper = mapper;
        }

        public async Task<ResponseMessageDto> CreateJobTypeAsync(JobTypeInputDto input)
        {
            //create job type
            var jobType = _mapper.Map<JobType>(input);
            var addedJobType = await _jobTypeRepository.AddAsync(jobType);
            if (addedJobType == null)
            {
                return new ResponseMessageDto
                {
                    Message = "İş türü eklenemedi",
                    IsSuccess = false,
                    Errors = new List<string> { "Job Type could not be added" }
                };
            }
            return new ResponseMessageDto
            {
                Message = "İş türü başarıyla eklendi",
                IsSuccess = true,
                Data = _mapper.Map<JobTypeOutputDto>(addedJobType)
            };

        }

        public async Task<ResponseMessageDto> DeleteJobTypeByIdAsync(int id)
        {
            var jobType = await _jobTypeRepository.GetByIdAsync(id);
            if (jobType == null)
            {
                return new ResponseMessageDto
                {
                    Message = "İş türü bulunamadı",
                    IsSuccess = false,
                    Errors = new List<string> { "Job Type could not be found" }
                };
            }
            var jobTypeInUse = await _jobRepository.GetAsync(p=>p.JobTypeId == id);
            if (jobTypeInUse != null)
            {
                return new ResponseMessageDto
                {
                    Message = "İş türü kullanımda olduğu için silinemedi",
                    IsSuccess = false,
                    Errors = new List<string> { "Job Type is in use" }
                };
            }
            await _jobTypeRepository.DeleteAsync(jobType);
            return new ResponseMessageDto
            {
                Message = "İş türü başarıyla silindi",
                IsSuccess = true
            };
        }

        public async Task<ResponseMessageDto> GetJobTypeByIdAsync(int id)
        {
            var jobType = await _jobTypeRepository.GetByIdAsync(id);
            if (jobType == null)
            {
                return new ResponseMessageDto
                {
                    Message = "İş türü bulunamadı",
                    IsSuccess = false,
                    Errors = new List<string> { "Job Type could not be found" }
                };
            }
            return new ResponseMessageDto
            {
                Message = "İş türü başarıyla getirildi",
                IsSuccess = true,
                Data = _mapper.Map<JobTypeOutputDto>(jobType)
            };
        }

        public async Task<ResponseMessageDto> GetJobTypesAsync()
        {
            var jobTypes = await _jobTypeRepository.ListAllAsync();
            if (jobTypes == null)
            {
                return new ResponseMessageDto
                {
                    Message = "İş türleri bulunamadı",
                    IsSuccess = false,
                    Errors = new List<string> { "Job Types could not be found" }
                };
            }
            return new ResponseMessageDto
            {
                Message = "İş türleri başarıyla getirildi",
                IsSuccess = true,
                Data = _mapper.Map<List<JobTypeOutputDto>>(jobTypes)
            };

        }

        public async Task<ResponseMessageDto> UpdateJobTypeAsync(int id, JobTypeInputDto input)
        {
            var jobType = await _jobTypeRepository.GetByIdAsync(id);
            if (jobType == null)
            {
                return new ResponseMessageDto
                {
                    Message = "İş türü bulunamadı",
                    IsSuccess = false,
                    Errors = new List<string> { "Job Type could not be found" }
                };
            }
            jobType.Name = input.Name;
            jobType.Description = input.Description;
            await _jobTypeRepository.UpdateAsync(jobType);
            return new ResponseMessageDto
            {
                Message = "İş türü başarıyla güncellendi",
                IsSuccess = true,
                Data = _mapper.Map<JobTypeOutputDto>(jobType)
            };

        }

        
    }
}
