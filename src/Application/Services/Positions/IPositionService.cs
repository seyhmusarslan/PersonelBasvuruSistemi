using Application.Dto.Common;
using Application.Dto.Position;

namespace Application.Services.Positions;

public interface IPositionService
{
    Task<ResponseMessageDto> CreatePositionAsync(PositionInputDto input);
    Task<ResponseMessageDto> DeletePositionByIdAsync(int id);
    Task<ResponseMessageDto> UpdatePositionAsync(int id,PositionInputDto input);
    Task<ResponseMessageDto> GetPositionByIdAsync(int id);
    Task<ResponseMessageDto> GetPositionsAsync();
}
