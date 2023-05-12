using Application.Dto.Common;
using Application.Dto.JobTypeDocument;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.JobTypeDocuments;

public class JobTypeDocumentService : IJobTypeDocumentService
{
    private readonly IMapper _mapper;
    private readonly IJobTypeDocumentRepositoryAsync _jobTypeDocumentRepository;

    public JobTypeDocumentService(IMapper mapper, IJobTypeDocumentRepositoryAsync jobTypeDocumentRepository)
    {
        _mapper = mapper;
        _jobTypeDocumentRepository = jobTypeDocumentRepository;
    }

    public async Task<ResponseMessageDto> AddJobTypeDocumentAsync(JobTypeDocumentInputDto inputDto)
    {
        var jobTypeDocument = _mapper.Map<JobTypeDocument>(inputDto);
        var addedJobTypeDocument = await _jobTypeDocumentRepository.AddAsync(jobTypeDocument);
        if (addedJobTypeDocument == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = false,
                Message = "İş türü belgesi eklenemedi",
                Errors = new List<string>() { "İş türü belgesi eklenemedi" }
            };
        }
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "İş türü belgesi başarıyla eklendi",
            Data = _mapper.Map<JobTypeDocumentOutputDto>(addedJobTypeDocument)
        };
    }

    public async Task<ResponseMessageDto> DeleteJobTypeDocumentAsync(int jobDocumentId)
    {
        var jobTypeDocument = await _jobTypeDocumentRepository.GetByIdAsync(jobDocumentId);
        if (jobTypeDocument == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = false,
                Message = "İş türü belgesi bulunamadı",
                Errors = new List<string>() { "İş türü belgesi bulunamadı" }
            };
        }
        await _jobTypeDocumentRepository.DeleteAsync(jobTypeDocument);
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "İş türü belgesi başarıyla silindi",
            Data = _mapper.Map<JobTypeDocumentOutputDto>(jobTypeDocument)
        };
    }

    public async Task<ResponseMessageDto> GetAllJobTypeDocumentsAsync(int jobTypeId)
    {
        var jobTypeDocuments = await _jobTypeDocumentRepository.ListAsync(x => x.JobTypeId == jobTypeId,orderBy:x=>x.OrderBy(x=>x.Name));
        if (jobTypeDocuments == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = false,
                Message = "İş türü belgeleri bulunamadı",
                Errors = new List<string>() { "İş türü belgeleri bulunamadı" }
            };
        }
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "İş türü belgeleri başarıyla getirildi",
            Data = _mapper.Map<List<JobTypeDocumentOutputDto>>(jobTypeDocuments)
        };

    }

    public async Task<ResponseMessageDto> GetJobTypeDocumentByIdAsync(int jobDocumentId)
    {
        var jobTypeDocument = await _jobTypeDocumentRepository.GetByIdAsync(jobDocumentId);
        if (jobTypeDocument == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = false,
                Message = "İş türü belgesi bulunamadı",
                Errors = new List<string>() { "İş türü belgesi bulunamadı" }
            };
        }
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "İş türü belgesi başarıyla getirildi",
            Data = _mapper.Map<JobTypeDocumentOutputDto>(jobTypeDocument)
        };
    }

    public async Task<ResponseMessageDto> UpdateJobTypeDocumentAsync(int jobDocumentId, JobTypeDocumentInputDto inputDto)
    {
        var jobTypeDocument = await _jobTypeDocumentRepository.GetByIdAsync(jobDocumentId);
        if (jobTypeDocument == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = false,
                Message = "İş türü belgesi bulunamadı",
                Errors = new List<string>() { "İş türü belgesi bulunamadı" }
            };
        }
        jobTypeDocument.Name = inputDto.Name;
        jobTypeDocument.Description = inputDto.Description;
        jobTypeDocument.IsRequired = inputDto.IsRequired;
        jobTypeDocument.JobTypeId = inputDto.JobTypeId;
        jobTypeDocument.DocumentGroupId = inputDto.DocumentGroupId;
        await _jobTypeDocumentRepository.UpdateAsync(jobTypeDocument);
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "İş türü belgesi başarıyla güncellendi",
            Data = _mapper.Map<JobTypeDocumentOutputDto>(jobTypeDocument)
        };
    }
}
