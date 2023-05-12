using System.Net.Http.Headers;
using Application.Dto.Common;
using Application.Dto.PositionExam;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.PositionExams;

public class PositionExamService : IPositionExamService
{
    private readonly IMapper _mapper;
    private readonly IPositionExamRepositoryAsync _positionExamRepository;
    private readonly IExamRepositoryAsync _examRepository;
    private readonly IPositionRepositoryAsync _positionRepository;

    public PositionExamService(IMapper mapper, IPositionExamRepositoryAsync positionExamRepository, IExamRepositoryAsync examRepository, IPositionRepositoryAsync positionRepository)
    {
        _mapper = mapper;
        _positionExamRepository = positionExamRepository;
        _examRepository = examRepository;
        _positionRepository = positionRepository;
    }

    public async Task<ResponseMessageDto> CreatePositionExam(PositionExamInputDto positionExamInputDto)
    {
        var exam = await _examRepository.GetByIdAsync(positionExamInputDto.ExamId);
        if (exam == null)
        {
            return new ResponseMessageDto
            {
                Message = "Exam not found",
                IsSuccess = false,
                Errors = new List<string> { "Exam not found" }
            };
        }
        var position = await _positionRepository.GetByIdAsync(positionExamInputDto.PositionId);
        if (position == null)
        {
            return new ResponseMessageDto
            {
                Message = "Position not found",
                IsSuccess = false,
                Errors = new List<string> { "Position not found" }
            };
        }
        var positionExam = _mapper.Map<PositionExam>(positionExamInputDto);
        var addedPositionExam = await _positionExamRepository.AddAsync(positionExam);
        if (addedPositionExam == null)
        {
            return new ResponseMessageDto
            {
                Message = "PositionExam could not be added",
                IsSuccess = false,
                Errors = new List<string> { "PositionExam could not be added" }
            };
        }
        return new ResponseMessageDto
        {
            Message = "PositionExam added successfully",
            IsSuccess = true,
            Data = _mapper.Map<PositionExamOutputDto>(addedPositionExam)
        };
    }

    public async Task<ResponseMessageDto> DeletePositionExam(int id)
    {
        var positionExam =await _positionExamRepository.GetByIdAsync(id);
        if (positionExam == null)
        {
            return new ResponseMessageDto
            {
                Message = "PositionExam not found",
                IsSuccess = false,
                Errors = new List<string> { "PositionExam not found" }
            };
        }
        await _positionExamRepository.DeleteAsync(positionExam);
        return new ResponseMessageDto
        {
            Message = "PositionExam deleted successfully",
            IsSuccess = true,
        };
    }

    public async Task<ResponseMessageDto> GetAllPositionExams(int positionId)
    {
        var positionExams = await _positionExamRepository.ListAsync(x => x.PositionId == positionId,orderBy:x=>x.OrderBy(x=>x.PositionExamId));
        return new ResponseMessageDto
        {
            Message = "PositionExams listed successfully",
            IsSuccess = true,
            Data = _mapper.Map<List<PositionExamOutputDto>>(positionExams)
        };
    }

    public async Task<ResponseMessageDto> UpdatePositionExam(int id, PositionExamInputDto positionExamInputDto)
    {
        var positionExam = await _positionExamRepository.GetByIdAsync(id);
        if (positionExam == null)
        {
            return new ResponseMessageDto
            {
                Message = "PositionExam not found",
                IsSuccess = false,
                Errors = new List<string> { "PositionExam not found" }
            };
        }
        var exam = await _examRepository.GetByIdAsync(positionExamInputDto.ExamId);
        if (exam == null)
        {
            return new ResponseMessageDto
            {
                Message = "Exam not found",
                IsSuccess = false,
                Errors = new List<string> { "Exam not found" }
            };
        }
        var position = await _positionRepository.GetByIdAsync(positionExamInputDto.PositionId);
        if (position == null)
        {
            return new ResponseMessageDto
            {
                Message = "Position not found",
                IsSuccess = false,
                Errors = new List<string> { "Position not found" }
            };
        }
        var positionExamToUpdate = _mapper.Map<PositionExam>(positionExamInputDto);
        positionExamToUpdate.PositionExamId = id;
        await _positionExamRepository.UpdateAsync(positionExamToUpdate);
        return new ResponseMessageDto
        {
            Message = "PositionExam updated successfully",
            IsSuccess = true,
            Data = _mapper.Map<PositionExamOutputDto>(positionExamToUpdate)
        };
    }
}
