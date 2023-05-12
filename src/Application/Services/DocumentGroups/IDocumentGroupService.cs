using Application.Dto.Common;
using Application.Dto.DocumentGroup;

namespace Application.Services.DocumentGroups;

public interface IDocumentGroupService
{
    Task<ResponseMessageDto> CreateDocumentGroupAsync(DocumentGroupInputDto documentGroupInputDto);
    Task<ResponseMessageDto> UpdateDocumentGroupAsync(int documentGroupId, DocumentGroupInputDto documentGroupInputDto);
    Task<ResponseMessageDto> DeleteDocumentGroupAsync(int documentGroupId);
    Task<ResponseMessageDto> GetDocumentGroupAsync(int documentGroupId);
    Task<ResponseMessageDto> GetDocumentGroupsAsync();
}
