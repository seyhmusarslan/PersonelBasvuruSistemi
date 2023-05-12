using Application.Dto.Common;
using Application.Dto.PositionExam;

namespace Application.Services.PositionExams;

public interface IPositionExamService
{
    Task<ResponseMessageDto> CreatePositionExam(PositionExamInputDto positionExamInputDto);
    Task<ResponseMessageDto> UpdatePositionExam(int id,PositionExamInputDto positionExamInputDto);
    Task<ResponseMessageDto> DeletePositionExam(int id);
    Task<ResponseMessageDto> GetAllPositionExams(int positionId);

}
