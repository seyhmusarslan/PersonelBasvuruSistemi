using Application.Dto.ApplicantExam;
using Application.Dto.Common;

namespace Application.Services.ApplicantExams;

public interface IApplicantExamService
{
    Task<ResponseMessageDto> AddApplicantExamAsync(ApplicantExamInputDto applicantExamInputDto);
    Task<ResponseMessageDto> DeleteApplicantExamAsync(int applicantExamId);
    Task<ResponseMessageDto> GetApplicantExamAsync(int applicantExamId);
    Task<ResponseMessageDto> GetApplicantExamsAsync(int applicantId);
    Task<ResponseMessageDto> UpdateApplicantExamAsync(int applicantExamId ,ApplicantExamInputDto applicantExamInputDto);
    
}
