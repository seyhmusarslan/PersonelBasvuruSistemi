using Application.Dto.Common;

namespace Application.Services.JobPostingDetails;

public interface IJobPostingDetailService
{
    Task<ResponseMessageDto> CreateJobPostingDetailAsync(JobPostingDetailInputDto input);
    Task<ResponseMessageDto> DeleteJobPostingDetailByIdAsync(int id);
    Task<ResponseMessageDto> GetJobPostingDetailByIdAsync(int id);
    Task<ResponseMessageDto> GetJobPostingDetailsAsync();
    Task<ResponseMessageDto> UpdateJobPostingDetailAsync(int id, JobPostingDetailInputDto input);
    
    
}
