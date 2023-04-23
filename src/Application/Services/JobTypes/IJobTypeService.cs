using System.Threading.Tasks;
using System;
using Application.Dto.JobType;

namespace Application.Services.JobTypes
{
    public interface IJobTypeService
    {
        Task<JobTypeOutputDto> CreateJobTypeAsync(JobTypeInputDto input);
        Task<bool> DeleteJobTypeByIdAsync(int id);
        Task<JobTypeOutputDto> GetJobTypeByIdAsync(int id);
        Task<List<JobTypeOutputDto>> GetJobTypesAsync();
        Task<JobTypeOutputDto> UpdateJobTypeAsync(int id,JobTypeInputDto input);

        
    }
}
