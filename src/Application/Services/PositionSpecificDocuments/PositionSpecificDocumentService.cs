using Application.Dto.Common;
using Application.Dto.PositionSpecificDocument;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.PositionSpecificDocuments;

public class PositionSpecificDocumentService : IPositionSpecificDocumentService
{
    private readonly IMapper _mapper;
    private readonly IPositionSpecificDocumentRepositoryAsync _positionSpecificDocumentRepository;
    private readonly IPositionRepositoryAsync _positionRepository;

    public PositionSpecificDocumentService(IPositionSpecificDocumentRepositoryAsync positionSpecificDocumentRepository, IMapper mapper, IPositionRepositoryAsync positionRepository)
    {
        _positionSpecificDocumentRepository = positionSpecificDocumentRepository;
        _mapper = mapper;
        _positionRepository = positionRepository;
    }

    public async Task<ResponseMessageDto> CreatePositionSpecificDocumentAsync(PositionSpecificDocumentInputDto input)
    {
        var position = await _positionRepository.GetByIdAsync(input.PositionId);
        if (position == null)
        {
            return new ResponseMessageDto
            {
                Message = "Position not found",
                IsSuccess = false,
                Errors = new List<string> { "Position not found" }
            };
        }
        var positionSpecificDocument = _mapper.Map<PositionSpecificDocument>(input);
        var addedPositionSpecificDocument = await _positionSpecificDocumentRepository.AddAsync(positionSpecificDocument);
        if (addedPositionSpecificDocument == null)
        {
            return new ResponseMessageDto
            {
                Message = "PositionSpecificDocument could not be added",
                IsSuccess = false,
                Errors = new List<string> { "PositionSpecificDocument could not be added" }
            };
        }
        return new ResponseMessageDto
        {
            Message = "PositionSpecificDocument added successfully",
            IsSuccess = true,
            Data = _mapper.Map<PositionSpecificDocumentOutputDto>(addedPositionSpecificDocument)
        };
    }

    public async Task<ResponseMessageDto> DeletePositionSpecificDocumentAsync(int id)
    {
        var positionSpecificDocument = await _positionSpecificDocumentRepository.GetByIdAsync(id);
        if (positionSpecificDocument == null)
        {
            return new ResponseMessageDto
            {
                Message = "PositionSpecificDocument not found",
                IsSuccess = false,
                Errors = new List<string> { "PositionSpecificDocument not found" }
            };
        }
        await _positionSpecificDocumentRepository.DeleteAsync(positionSpecificDocument);
        return new ResponseMessageDto
        {
            Message = "PositionSpecificDocument deleted successfully",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> GetAllPositionSpecificDocumentsAsync(int positionId)
    {
        var positionSpecificDocuments = await _positionSpecificDocumentRepository.ListAsync(x => x.PositionId == positionId,orderBy: x => x.OrderBy(x => x.Name));
        return new ResponseMessageDto
        {
            Message = "PositionSpecificDocuments get successfully",
            IsSuccess = true,
            Data = _mapper.Map<List<PositionSpecificDocumentOutputDto>>(positionSpecificDocuments)
        };
    }

    public async Task<ResponseMessageDto> UpdatePositionSpecificDocumentAsync(int id, PositionSpecificDocumentInputDto input)
    {
        var positionSpecificDocument = await _positionSpecificDocumentRepository.GetByIdAsync(id);
        if (positionSpecificDocument == null)
        {
            return new ResponseMessageDto
            {
                Message = "PositionSpecificDocument not found",
                IsSuccess = false,
                Errors = new List<string> { "PositionSpecificDocument not found" }
            };
        }
        var position = await _positionRepository.GetByIdAsync(input.PositionId);
        if (position == null)
        {
            return new ResponseMessageDto
            {
                Message = "Position not found",
                IsSuccess = false,
                Errors = new List<string> { "Position not found" }
            };
        }
        positionSpecificDocument.Name = input.Name;
        positionSpecificDocument.Description = input.Description;
        positionSpecificDocument.IsRequired = input.IsRequired;
        positionSpecificDocument.PositionId = input.PositionId;
        await _positionSpecificDocumentRepository.UpdateAsync(positionSpecificDocument);
        return new ResponseMessageDto
        {
            Message = "PositionSpecificDocument updated successfully",
            IsSuccess = true,
            Data = _mapper.Map<PositionSpecificDocumentOutputDto>(positionSpecificDocument)
        };
    }
}
