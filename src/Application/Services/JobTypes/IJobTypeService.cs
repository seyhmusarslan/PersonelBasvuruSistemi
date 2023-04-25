using System.Threading.Tasks;
using System;
using Application.Dto.JobType;
using Application.Dto.Common;

namespace Application.Services.JobTypes
{
    public interface IJobTypeService
    {
        Task<ResponseMessageDto> CreateJobTypeAsync(JobTypeInputDto input);
        Task<ResponseMessageDto> DeleteJobTypeByIdAsync(int id);
        Task<ResponseMessageDto> GetJobTypeByIdAsync(int id);
        Task<ResponseMessageDto> GetJobTypesAsync();
        Task<ResponseMessageDto> UpdateJobTypeAsync(int id,JobTypeInputDto input);

        
    }
}
