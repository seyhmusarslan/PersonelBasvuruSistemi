using Application.Dto.Common;
using Application.Dto.Exam;

namespace Application.Services.Exams;

public interface IExamService
{
    Task<ResponseMessageDto> CreateExamAsync(ExamInputDto input);
    Task<ResponseMessageDto> DeleteExamByIdAsync(int id);
    Task<ResponseMessageDto> GetExamByIdAsync(int id);
    Task<ResponseMessageDto> GetExamsAsync();
    Task<ResponseMessageDto> UpdateExamAsync(int id, ExamInputDto input);
}
