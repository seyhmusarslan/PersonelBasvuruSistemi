using Application.Dto.Applicant;
using Application.Dto.Common;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.Applicants;

public class ApplicantService : IApplicantService
{
    private readonly IApplicantRepositoryAsync _applicantRepository;
    private readonly IMapper _mapper;

    public ApplicantService(IMapper mapper, IApplicantRepositoryAsync applicantRepository)
    {
        _mapper = mapper;
        _applicantRepository = applicantRepository;
    }

    public async Task<ResponseMessageDto> CreateApplicantAsync(ApplicantInputDto input)
    {
        var applicant = _mapper.Map<Applicant>(input);
        var addedApplicant = await _applicantRepository.AddAsync(applicant);
        if (addedApplicant == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = false,
                Message = "Applicant could not be added",
                Errors = new List<string>() { "Applicant could not be added" }
            };
        }
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "Applicant added successfully",
            Data = _mapper.Map<ApplicantOutputDto>(addedApplicant)
        };
    }

    public async Task<ResponseMessageDto> DeleteApplicantAsync(int id)
    {
        var applicant =await _applicantRepository.GetByIdAsync(id);
        if (applicant == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = false,
                Message = "Başvuru bulunamadı",
                Errors = new List<string>() { "Applicant could not be found" }
            };
        }
        //TODO: Applicant'a ait belgeleri de sil
        await _applicantRepository.DeleteAsync(applicant);
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "Başvuru başarıyla silindi"
        };
    }

    public async Task<ResponseMessageDto> GetAllApplicantsAsync(int applicantId)
    {
        var applicants = await _applicantRepository.ListAsync(p=>p.ApplicantId==applicantId,orderBy:p=>p.OrderByDescending(p=>p.ApplicantId));
        if (applicants == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = true,
                Message = "herhangi bir başvuru bulunamadı",
                Data=null
            };
        }
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "Başvurular başarıyla getirildi",
            Data = _mapper.Map<List<ApplicantOutputDto>>(applicants)
        };
    }

    public async Task<ResponseMessageDto> GetApplicantByIdAsync(int id)
    {
        var applicant = await _applicantRepository.GetByIdAsync(id);
        if (applicant == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = true,
                Message = "Başvuru bulunamadı",
                Data = null
            };
        }
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "Başvuru başarıyla getirildi",
            Data = _mapper.Map<ApplicantOutputDto>(applicant)
        };
    }

    public async Task<ResponseMessageDto> UpdateApplicantAsync(int id, ApplicantInputDto input)
    {
        var applicant = await _applicantRepository.GetByIdAsync(id);
        if (applicant == null)
        {
            return new ResponseMessageDto()
            {
                IsSuccess = false,
                Message = "Başvuru bulunamadı",
                Errors = new List<string>() { "Applicant could not be found" }
            };
        }
        applicant = _mapper.Map<Applicant>(input);
        applicant.ApplicantId = id;
        await _applicantRepository.UpdateAsync(applicant);
        return new ResponseMessageDto()
        {
            IsSuccess = true,
            Message = "Başvuru başarıyla güncellendi",
            Data = _mapper.Map<ApplicantOutputDto>(applicant)
        };
    }
}
