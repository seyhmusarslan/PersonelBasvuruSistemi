using Application.Dto.Common;
using Application.Dto.Exam;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Exams;

public class ExamService : IExamService
{
    private readonly IMapper _mapper;
    private readonly IExamRepositoryAsync _examRepository;

    public ExamService(IMapper mapper, IExamRepositoryAsync examRepository)
    {
        _mapper = mapper;
        _examRepository = examRepository;
    }

    public async Task<ResponseMessageDto> CreateExamAsync(ExamInputDto input)
    {
        var exam = _mapper.Map<Exam>(input);
        var addedExam = await _examRepository.AddAsync(exam);
        if(addedExam.ExamId == 0)
            return new ResponseMessageDto{
                Message = "Exam not created",
                IsSuccess = false,
                Errors = new List<string>{"Exam not created"}
            };
        return new ResponseMessageDto{
            Message = "Exam created",
            IsSuccess = true,
            Data = _mapper.Map<ExamOutputDto>(addedExam)
        };
    }

    public async Task<ResponseMessageDto> DeleteExamByIdAsync(int id)
    {
        var exam = await _examRepository.GetByIdAsync(id);
        if(exam == null)
            return new ResponseMessageDto{
                Message = "Exam not found",
                IsSuccess = false,
                Errors = new List<string>{"Exam not found"}
            };
        await _examRepository.DeleteAsync(exam);
        return new ResponseMessageDto{
            Message = "Exam deleted",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> GetExamByIdAsync(int id)
    {
        var exam = await _examRepository.GetByIdAsync(id);
        if(exam == null)
            return new ResponseMessageDto{
                Message = "Exam not found",
                IsSuccess = false,
                Errors = new List<string>{"Exam not found"}
            };
        return new ResponseMessageDto{
            Message = "Exam found",
            IsSuccess = true,
            Data = _mapper.Map<ExamOutputDto>(exam)
        }; 
    }

    public async Task<ResponseMessageDto> GetExamsAsync()
    {
        return new ResponseMessageDto{
            Message = "Exams found",
            IsSuccess = true,
            Data = _mapper.Map<List<ExamOutputDto>>(await _examRepository.ListAllAsync())
        };
    }

    public async Task<ResponseMessageDto> UpdateExamAsync(int id, ExamInputDto input)
    {
        var exam = await _examRepository.GetByIdAsync(id);
        if(exam == null)
            return new ResponseMessageDto{
                Message = "Exam not found",
                IsSuccess = false,
                Errors = new List<string>{"Exam not found"}
            };
        var updatedExam = _mapper.Map<ExamOutputDto>(input);
        updatedExam.ExamId = id;
        await _examRepository.UpdateAsync(_mapper.Map<Exam>(updatedExam));
        return new ResponseMessageDto{
            Message = "Exam updated",
            IsSuccess = true,
            Data = updatedExam
        };

    }
}
