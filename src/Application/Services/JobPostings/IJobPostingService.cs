using System;
using Application.Dto.Common;
using Application.Dto.JobPosting;

namespace Application.Services.JobPostings
{
    public interface IJobPostingService
    {
        Task<ResponseMessageDto> CreateJobPostingAsync(JobPostingInputDto input);
        Task<ResponseMessageDto> GetJobPostingByIdAsync(int id);
        Task<ResponseMessageDto> GetJobPostingsAsync();
        Task<ResponseMessageDto> DeleteJobPostingByIdAsync(int id);
        Task<ResponseMessageDto> UpdateJobPostingAsync(int id,JobPostingInputDto input);
    }
}
