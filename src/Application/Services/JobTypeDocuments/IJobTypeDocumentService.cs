using Application.Dto.Common;
using Application.Dto.JobTypeDocument;

namespace Application.Services.JobTypeDocuments;

public interface IJobTypeDocumentService
{
    Task<ResponseMessageDto> AddJobTypeDocumentAsync(JobTypeDocumentInputDto inputDto);
    Task<ResponseMessageDto> UpdateJobTypeDocumentAsync(int jobDocumentId,JobTypeDocumentInputDto inputDto);
    Task<ResponseMessageDto> DeleteJobTypeDocumentAsync(int jobDocumentId);
    Task<ResponseMessageDto> GetJobTypeDocumentByIdAsync(int jobDocumentId);
    Task<ResponseMessageDto> GetAllJobTypeDocumentsAsync(int jobTypeId);

}
