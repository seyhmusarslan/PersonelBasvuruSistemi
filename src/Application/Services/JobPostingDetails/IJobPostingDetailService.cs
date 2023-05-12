using Application.Dto.Common;
using Application.Dto.JobPostingDetail;

namespace Application.Services.JobPostingDetails;

public interface IJobPostingDetailService
{
    Task<ResponseMessageDto> CreateJobPostingDetailAsync(JobPostingDetailInputDto input);
    Task<ResponseMessageDto> DeleteJobPostingDetailByIdAsync(int id);
    Task<ResponseMessageDto> GetJobPostingDetailByIdAsync(int id);
    Task<ResponseMessageDto> GetJobPostingDetailsAsync(int jobPostingId);
    Task<ResponseMessageDto> UpdateJobPostingDetailAsync(int id, JobPostingDetailInputDto input);
}
