using Application.Dto.ApplicantStatu;
using Application.Dto.Common;

namespace Application.Services.ApplicantStatus;

public interface IApplicantStatuService
{
    Task<ResponseMessageDto> CreateApplicantStatuAsync(ApplicantStatuInputDto input);
    Task<ResponseMessageDto> UpdateApplicantStatuAsync(int id,ApplicantStatuInputDto input);
    Task<ResponseMessageDto> DeleteApplicantStatuAsync(int id);
    Task<ResponseMessageDto> GetApplicantStatuByIdAsync(int id);
    Task<ResponseMessageDto> GetApplicantStatusAsync();
}
