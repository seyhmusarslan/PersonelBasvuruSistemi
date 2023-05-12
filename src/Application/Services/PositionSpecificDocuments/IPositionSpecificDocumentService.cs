using Application.Dto.Common;
using Application.Dto.PositionSpecificDocument;

namespace Application.Services.PositionSpecificDocuments;

public interface IPositionSpecificDocumentService
{
    Task<ResponseMessageDto> CreatePositionSpecificDocumentAsync(PositionSpecificDocumentInputDto input);
    Task<ResponseMessageDto> UpdatePositionSpecificDocumentAsync(int id, PositionSpecificDocumentInputDto input);
    Task<ResponseMessageDto> DeletePositionSpecificDocumentAsync(int id);
    Task<ResponseMessageDto> GetAllPositionSpecificDocumentsAsync(int positionId);

}
