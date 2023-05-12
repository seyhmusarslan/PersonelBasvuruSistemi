using Application.Dto.ApplicantDocument;
using Application.Dto.Common;

namespace Application.Services.ApplicantDocuments;

public interface IApplicantDocumentService
{
    Task<ResponseMessageDto> AddApplicantDocumentAsync(ApplicantDocumentInputDto applicantDocumentInputDto);
    Task<ResponseMessageDto> DeleteApplicantDocumentAsync(int applicantDocumentId);
    Task<ResponseMessageDto> GetApplicantDocumentAsync(int applicantDocumentId);
    Task<ResponseMessageDto> GetApplicantDocumentsAsync(int applicantId);
    Task<ResponseMessageDto> UpdateApplicantDocumentAsync(int applicantDocumentId,ApplicantDocumentInputDto applicantDocumentInputDto);
}
