using System;
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

        public async Task<JobTypeOutputDto> CreateJobTypeAsync(JobTypeInputDto input)
        {
            //create job type
            var jobType = _mapper.Map<JobType>(input);
            var addedJobType =await  _jobTypeRepository.AddAsync(jobType);
            if (addedJobType == null)
            {
                return new JobTypeOutputDto
                {
                    Message = "İş türü eklenemedi",
                    IsSuccess = false,
                    Errors = new List<string> {"Job Type could not be added"}
                };
            }
            return new JobTypeOutputDto
            {
                Message = "İş türü başarıyla eklendi",
                IsSuccess = true
            };
            
        }

        public Task<bool> DeleteJobTypeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<JobTypeOutputDto> GetJobTypeByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<JobTypeOutputDto>> GetJobTypesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<JobTypeOutputDto> UpdateJobTypeAsync(int id, JobTypeInputDto input)
        {
            throw new NotImplementedException();
        }
    }
}
