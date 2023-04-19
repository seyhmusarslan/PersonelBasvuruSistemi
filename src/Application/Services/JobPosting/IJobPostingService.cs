using System;
using Application.Dto.JobPosting;

namespace Application.Services.JobPosting
{
    public interface IJobPostingService
    {
        Task<JobPostingOutputDto> CreateJobPostingAsync(JobPostingInputDto input);
    }
}
