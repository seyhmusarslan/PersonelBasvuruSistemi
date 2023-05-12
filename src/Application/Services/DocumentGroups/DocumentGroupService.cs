using Application.Dto.Common;
using Application.Dto.DocumentGroup;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.DocumentGroups;

public class DocumentGroupService : IDocumentGroupService
{
    private readonly IDocumentGroupRepositoryAsync _documentGroupRepository;
    private readonly IJobTypeDocumentRepositoryAsync _jobTypeDocumentRepository;
    private readonly IMapper _mapper;

    public DocumentGroupService(IDocumentGroupRepositoryAsync documentGroupRepository, IMapper mapper, IJobTypeDocumentRepositoryAsync jobTypeDocumentRepository)
    {
        _documentGroupRepository = documentGroupRepository;
        _mapper = mapper;
        _jobTypeDocumentRepository = jobTypeDocumentRepository;
    }

    public async Task<ResponseMessageDto> CreateDocumentGroupAsync(DocumentGroupInputDto documentGroupInputDto)
    {
        var documentGroup = _mapper.Map<DocumentGroup>(documentGroupInputDto);
        var addedDocumentGroup = await _documentGroupRepository.AddAsync(documentGroup);
        if (addedDocumentGroup == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Döküman grubu eklenemedi",
                Errors = new List<string> { "Döküman grubu eklenemedi" }
            };
        } 
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Döküman grubu başarıyla eklendi",
            Data = _mapper.Map<DocumentGroupOutputDto>(addedDocumentGroup)
        };
    }

    public async Task<ResponseMessageDto> DeleteDocumentGroupAsync(int documentGroupId)
    {
        var documentGroup = await _documentGroupRepository.GetByIdAsync(documentGroupId);
        if (documentGroup == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Döküman grubu bulunamadı",
                Errors = new List<string> { "Döküman grubu bulunamadı" }
            };
        }
        var jobTypeDocuments = await _jobTypeDocumentRepository.ListAsync(x => x.DocumentGroupId == documentGroupId,orderBy: x => x.OrderBy(x => x.Name));
        if(jobTypeDocuments is not null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Döküman grubu silinemez,bu guruba ait iş türü dökümanları mevcut",
                Errors = new List<string> { "Döküman grubu silinemez,bu guruba ait iş türü dökümanları mevcut" }
            };
        }
        await _documentGroupRepository.DeleteAsync(documentGroup);
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Döküman grubu başarıyla silindi"
        };
    }

    public async Task<ResponseMessageDto> GetDocumentGroupAsync(int documentGroupId)
    {
        var documentGroup = await _documentGroupRepository.GetByIdAsync(documentGroupId);
        if (documentGroup == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Döküman grubu bulunamadı",
                Errors = new List<string> { "Döküman grubu bulunamadı" }
            };
        }
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Döküman grubu başarıyla getirildi",
            Data = _mapper.Map<DocumentGroupOutputDto>(documentGroup)
        };
    }

    public async Task<ResponseMessageDto> GetDocumentGroupsAsync()
    {
        var documentGroups = await _documentGroupRepository.ListAllAsync();
        if (documentGroups == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = true,
                Message = "Gösterilecek döküman gurubu bulunamadı"
            };
        }
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Döküman gurupları başarıyla getirildi",
            Data = _mapper.Map<List<DocumentGroupOutputDto>>(documentGroups)
        };
    }

    public async Task<ResponseMessageDto> UpdateDocumentGroupAsync(int documentGroupId, DocumentGroupInputDto documentGroupInputDto)
    {
        var documentGroup = await _documentGroupRepository.GetByIdAsync(documentGroupId);
        if (documentGroup == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Döküman grubu bulunamadı",
                Errors = new List<string> { "Döküman grubu bulunamadı" }
            };
        }
        documentGroup.Name = documentGroupInputDto.Name;
        await _documentGroupRepository.UpdateAsync(documentGroup);
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Döküman grubu başarıyla güncellendi",
            Data = _mapper.Map<DocumentGroupOutputDto>(documentGroup)
        };
    }
}
