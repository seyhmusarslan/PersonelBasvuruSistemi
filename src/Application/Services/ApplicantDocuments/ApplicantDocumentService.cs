using Application.Dto.ApplicantDocument;
using Application.Dto.Common;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.ApplicantDocuments;

public class ApplicantDocumentService : IApplicantDocumentService
{
    private readonly IMapper _mapper;
    private readonly IApplicantDocumentRepositoryAsync _applicantDocumentRepository;
    public ApplicantDocumentService(IMapper mapper, IApplicantDocumentRepositoryAsync applicantDocumentRepository)
    {
        _mapper = mapper;
        _applicantDocumentRepository = applicantDocumentRepository;
    }

    public async Task<ResponseMessageDto> AddApplicantDocumentAsync(ApplicantDocumentInputDto applicantDocumentInputDto)
    {
        var applicantDocument = _mapper.Map<ApplicantDocument>(applicantDocumentInputDto);
        var addedApplicantDocument = await _applicantDocumentRepository.AddAsync(applicantDocument);
        if (addedApplicantDocument == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru dökümanı eklenemedi",
                Errors = new List<string> { "Başvuru dökümanı eklenemedi" }
            };
        }
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru dökümanı başarıyla eklendi",
            Data= _mapper.Map<ApplicantDocumentOutputDto>(addedApplicantDocument)
        };
    }

    public async Task<ResponseMessageDto> DeleteApplicantDocumentAsync(int applicantDocumentId)
    {
        var applicantDocument = await _applicantDocumentRepository.GetByIdAsync(applicantDocumentId);
        if (applicantDocument == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru dökümanı bulunamadı",
                Errors = new List<string> { "Başvuru dökümanı bulunamadı" }
            };
        }
        await _applicantDocumentRepository.DeleteAsync(applicantDocument);
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru dökümanı başarıyla silindi"
        }; 
    }

    public async Task<ResponseMessageDto> GetApplicantDocumentAsync(int applicantDocumentId)
    {
        var applicantDocument = await _applicantDocumentRepository.GetByIdAsync(applicantDocumentId);
        if (applicantDocument == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru dökümanı bulunamadı",
                Errors = new List<string> { "Başvuru dökümanı bulunamadı" }
            };
        }
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru dökümanı başarıyla getirildi",
            Data = _mapper.Map<ApplicantDocumentOutputDto>(applicantDocument)
        }; 
    }

    public async Task<ResponseMessageDto> GetApplicantDocumentsAsync(int applicantId)
    {
        var applicantDocuments = await _applicantDocumentRepository.ListAsync(p=>p.ApplicantId==applicantId,orderBy:p=>p.OrderBy(p=>p.DocumentName));
        if (applicantDocuments == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru dökümanları bulunamadı",
                Errors = new List<string> { "Başvuru dökümanları bulunamadı" }
            };
        }
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru dökümanları başarıyla getirildi",
            Data = _mapper.Map<List<ApplicantDocumentOutputDto>>(applicantDocuments)
        };
    }

    public async Task<ResponseMessageDto> UpdateApplicantDocumentAsync(int applicantDocumentId, ApplicantDocumentInputDto applicantDocumentInputDto)
    {
        var applicantDocument = await _applicantDocumentRepository.GetByIdAsync(applicantDocumentId);
        if (applicantDocument == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru dökümanı bulunamadı",
                Errors = new List<string> { "Başvuru dökümanı bulunamadı" }
            };
        }
        applicantDocument.DocumentName = applicantDocumentInputDto.DocumentName;
        applicantDocument.DocumentPath = applicantDocumentInputDto.DocumentPath;
        await _applicantDocumentRepository.UpdateAsync(applicantDocument);
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru dökümanı başarıyla güncellendi",
            Data = _mapper.Map<ApplicantDocumentOutputDto>(applicantDocument)
        };
    }

}
