using Application.Dto.Applicant;
using Application.Dto.Common;

namespace Application.Services.Applicants;

public interface IApplicantService
{
   Task<ResponseMessageDto> CreateApplicantAsync(ApplicantInputDto input);
   Task<ResponseMessageDto> UpdateApplicantAsync(int id,ApplicantInputDto input);
    Task<ResponseMessageDto> DeleteApplicantAsync(int id);
    Task<ResponseMessageDto> GetApplicantByIdAsync(int id);
    Task<ResponseMessageDto> GetAllApplicantsAsync(int applicantId);
}
