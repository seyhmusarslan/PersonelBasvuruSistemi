using Application.Dto.ApplicantExam;
using Application.Dto.Common;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.ApplicantExams;

public class ApplicantExamService : IApplicantExamService
{
    private readonly IMapper _mapper;
    private readonly IApplicantExamRepositoryAsync _applicantExamRepository;

    public ApplicantExamService(IMapper mapper, IApplicantExamRepositoryAsync applicantExamRepository)
    {
        _mapper = mapper;
        _applicantExamRepository = applicantExamRepository;
    }

    public async Task<ResponseMessageDto> AddApplicantExamAsync(ApplicantExamInputDto applicantExamInputDto)
    {
        var applicantExam = _mapper.Map<ApplicantExam>(applicantExamInputDto);
        var addedApplicantExam = await _applicantExamRepository.AddAsync(applicantExam);
        if (addedApplicantExam == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru sınavı eklenemedi",
                Errors = new List<string> { "Başvuru sınavı eklenemedi" }
            };
        }
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru sınavı başarıyla eklendi",
            Data = _mapper.Map<ApplicantExamOutputDto>(addedApplicantExam)
        };
    }

    public async Task<ResponseMessageDto> DeleteApplicantExamAsync(int applicantExamId)
    {
        var applicantExam = await _applicantExamRepository.GetByIdAsync(applicantExamId);
        if (applicantExam == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru sınavı bulunamadı",
                Errors = new List<string> { "Başvuru sınavı bulunamadı" }
            };
        }
        await _applicantExamRepository.DeleteAsync(applicantExam);
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru sınavı başarıyla silindi"
        };
    }

    public async Task<ResponseMessageDto> GetApplicantExamAsync(int applicantExamId)
    {
        var applicantExam = await _applicantExamRepository.GetByIdAsync(applicantExamId);
        if (applicantExam == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru sınavı bulunamadı",
                Errors = new List<string> { "Başvuru sınavı bulunamadı" }
            };
        }
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru sınavı başarıyla getirildi",
            Data = _mapper.Map<ApplicantExamOutputDto>(applicantExam)
        };
    }

    public async Task<ResponseMessageDto> GetApplicantExamsAsync(int applicantId)
    {
        var applicantExams = await _applicantExamRepository.ListAsync(x => x.ApplicantId == applicantId,orderBy:x=>x.OrderByDescending(x=>x.ExamYear));
        if (applicantExams == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru sınavları bulunamadı",
                Errors = new List<string> { "Başvuru sınavları bulunamadı" }
            };
        }
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru sınavları başarıyla getirildi",
            Data = _mapper.Map<List<ApplicantExamOutputDto>>(applicantExams)
        };
    }

    public async Task<ResponseMessageDto> UpdateApplicantExamAsync(int applicantExamId,ApplicantExamInputDto applicantExamInputDto)
    {
        var applicantExam = await _applicantExamRepository.GetByIdAsync(applicantExamId);
        if(applicantExam == null)
        {
            return new ResponseMessageDto
            {
                IsSuccess = false,
                Message = "Başvuru sınavı bulunamadı",
                Errors = new List<string> { "Başvuru sınavı bulunamadı" }
            };
        }
        applicantExam.ExamName = applicantExamInputDto.ExamName;
        applicantExam.ExamResult = applicantExamInputDto.ExamResult;
        applicantExam.ExamYear = applicantExamInputDto.ExamYear;
        applicantExam.Multiplier = applicantExamInputDto.Multiplier;
        await _applicantExamRepository.UpdateAsync(applicantExam);
        return new ResponseMessageDto
        {
            IsSuccess = true,
            Message = "Başvuru sınavı başarıyla güncellendi",
            Data = _mapper.Map<ApplicantExamOutputDto>(applicantExam)
        };
    }
}
