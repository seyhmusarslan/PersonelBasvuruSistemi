using Application.Dto.Common;
using Application.Dto.Position;
using Application.Interfaces.Repositories;
using Domain.Entities;
using AutoMapper;

namespace Application.Services.Positions;

public class PositionService : IPositionService
{
    private readonly IPositionRepositoryAsync _positionRepository;
    private readonly IMapper _mapper;

    public PositionService(IPositionRepositoryAsync positionRepository, IMapper mapper )
    {
        _positionRepository = positionRepository;
        _mapper = mapper;
    }

    public async Task<ResponseMessageDto> CreatePositionAsync(PositionInputDto input)
    {
        var position = _mapper.Map<Position>(input);
        var addedPosition = await _positionRepository.AddAsync(position);
        if (addedPosition.PositionId == 0)
            return new ResponseMessageDto
            {
                Message = "Position not created",
                IsSuccess = false,
                Errors = new List<string> { "Position not created" }
            };
        var positionDto = _mapper.Map<PositionOutputDto>(addedPosition);
        return new ResponseMessageDto
        {
            Data = positionDto,
            Message = "Position created successfully",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> DeletePositionByIdAsync(int id)
    {
        //check if position exist
        var position = await _positionRepository.GetByIdAsync(id);
        if (position == null)
            return new ResponseMessageDto
            {
                Message = "Position not found",
                IsSuccess = false,
                Errors = new List<string> { "Position not found" }
            };
        await _positionRepository.DeleteAsync(position);
        //delete position
        return new ResponseMessageDto
        {
            Message = "Position deleted successfully",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> GetPositionByIdAsync(int id)
    {
        var position = await _positionRepository.GetByIdAsync(id);
        if (position == null)
            return new ResponseMessageDto
            {
                Message = "Position not found",
                IsSuccess = false,
                Errors = new List<string> { "Position not found" }
            };
        var positionDto = _mapper.Map<PositionOutputDto>(position);
        return new ResponseMessageDto
        {
            Data = positionDto,
            Message = "Position found successfully",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> GetPositionsAsync()
    {
        var positions = await _positionRepository.ListAllAsync();
        if (positions == null)
            return new ResponseMessageDto
            {
                Message = "Positions not found",
                IsSuccess = false,
                Errors = new List<string> { "Positions not found" }
            };
        var positionDtos = _mapper.Map<List<PositionOutputDto>>(positions);
        return new ResponseMessageDto
        {
            Data = positionDtos,
            Message = "Positions found successfully",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> UpdatePositionAsync(int id,PositionInputDto input)
    {
        var position = await _positionRepository.GetByIdAsync(id);
        if (position == null)
            return new ResponseMessageDto
            {
                Message = "Pozisyon bulunamadı",
                IsSuccess = false,
                Errors = new List<string> { "Position not found" }
            };
        position.Name = input.Name;
        position.Description = input.Description;
        position.Code = input.Code;
        await _positionRepository.UpdateAsync(position);
        var positionDto = _mapper.Map<PositionOutputDto>(position);
        return new ResponseMessageDto
        {
            Data = positionDto,
            Message = "Position updated successfully",
            IsSuccess = true
        };
    }



}
