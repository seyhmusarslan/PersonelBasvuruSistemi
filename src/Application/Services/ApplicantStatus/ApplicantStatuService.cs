using Application.Dto.ApplicantStatu;
using Application.Dto.Common;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.ApplicantStatus;

public class ApplicantStatuService : IApplicantStatuService
{
    private readonly IApplicantStatuRepositoryAsync _applicantStatuRepository;
    private readonly IMapper _mapper;

    public ApplicantStatuService(IApplicantStatuRepositoryAsync applicantStatuRepository, IMapper mapper)
    {
        _applicantStatuRepository = applicantStatuRepository;
        _mapper = mapper;
    }

    public async Task<ResponseMessageDto> CreateApplicantStatuAsync(ApplicantStatuInputDto input)
    {
        var applicantStatu = _mapper.Map<ApplicantStatu>(input);  
        var addedApplicantStatu = await _applicantStatuRepository.AddAsync(applicantStatu);
        return new ResponseMessageDto{
            Data = _mapper.Map<ApplicantStatuOutputDto>(addedApplicantStatu),
            Message = "Başarıyla eklendi",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> DeleteApplicantStatuAsync(int id)
    {
        var applicantStatu =await _applicantStatuRepository.GetByIdAsync(id);
        if(applicantStatu == null)
        {
            return new ResponseMessageDto{
                Data=null,
                Message = "Böyle bir başvuru durumu bulunamadı",
                IsSuccess = true
            };
        }
        await _applicantStatuRepository.DeleteAsync(applicantStatu);
        return new ResponseMessageDto{
            Message = "Başarıyla silindi",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> GetApplicantStatuByIdAsync(int id)
    {
        var applicantStatu =await _applicantStatuRepository.GetByIdAsync(id);
        if(applicantStatu == null)
        {
            return new ResponseMessageDto{
                Data=null,
                Message = "Böyle bir başvuru durumu bulunamadı",
                IsSuccess = true
            };
        }
        return new ResponseMessageDto{
            Data = _mapper.Map<ApplicantStatuOutputDto>(applicantStatu),
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> GetApplicantStatusAsync()
    {
        var applicantStatus = await _applicantStatuRepository.ListAllAsync();
        if(applicantStatus == null)
        {
            return new ResponseMessageDto{
               Data=null,
                Message = "Böyle bir başvuru durumu bulunamadı",
                IsSuccess = true
            };
        }
        return new ResponseMessageDto{
            Data = _mapper.Map<List<ApplicantStatuOutputDto>>(applicantStatus),
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> UpdateApplicantStatuAsync(int id, ApplicantStatuInputDto input)
    {
        var applicantStatu =await _applicantStatuRepository.GetByIdAsync(id);
        if(applicantStatu == null)
        {
            return new ResponseMessageDto{
                Data=null,
                Message = "Böyle bir başvuru durumu bulunamadı",
                IsSuccess = true
            };
        }
        applicantStatu.Name = input.Name;
        applicantStatu.Description = input.Description;
        await _applicantStatuRepository.UpdateAsync(applicantStatu);
        return new ResponseMessageDto{
            Data = _mapper.Map<ApplicantStatuOutputDto>(applicantStatu),
            Message = "Başarıyla güncellendi",
            IsSuccess = true
        };
        
    }
}
