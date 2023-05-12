using Application.Dto.Common;
using Application.Dto.JobPostingDetail;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;

namespace Application.Services.JobPostingDetails;

public class JobPostingDetailService : IJobPostingDetailService
{
    private readonly IJobPostingDetailRepositoryAsync _jobPostingDetailRepository;
    private readonly IJobPostingRepositoryAsync _jobPostingRepository;
    private readonly IPositionRepositoryAsync _positionRepository;
    private readonly IMapper _mapper;

    public JobPostingDetailService(IJobPostingDetailRepositoryAsync jobPostingDetailRepository,
            IMapper mapper,
            IJobPostingRepositoryAsync jobPostingRepository,
            IPositionRepositoryAsync positionRepository)
    {
        _jobPostingDetailRepository = jobPostingDetailRepository;
        _mapper = mapper;
        _jobPostingRepository = jobPostingRepository;
        _positionRepository = positionRepository;
    }

    public async Task<ResponseMessageDto> CreateJobPostingDetailAsync(JobPostingDetailInputDto input)
    {
        //check if jobPostingId and positionId is not zero
        if(input.JobPostingId == 0 || input.PositonId == 0)
            return new ResponseMessageDto{
                Message = "JobPostingId or PositionId sıfır olamaz",
                IsSuccess = false,
                Errors = new List<string>{"JobPostingId or PositionId is not valid"}
            };
        //check if jobPostingId and positionId exists
        var jobPosting = await _jobPostingRepository.GetByIdAsync(input.JobPostingId);
        if(jobPosting == null)
            return new ResponseMessageDto{
                Message = "ilan bulunamadı",
                IsSuccess = false,
                Errors = new List<string>{"JobPosting not found"}
            };
        //check if position exists
        var position = await _positionRepository.GetByIdAsync(input.PositonId);
        if(position == null)
            return new ResponseMessageDto{
                Message = "Pozisyon bulunamadı",
                IsSuccess = false,
                Errors = new List<string>{"Position not found"}
            };
        

        var jobPostingDetail = _mapper.Map<JobPostingDetail>(input);

        var addedJobPostingDetail = await _jobPostingDetailRepository.AddAsync(jobPostingDetail);
        if(addedJobPostingDetail.JobPostingDetailId == 0)
            return new ResponseMessageDto{
                Message = "JobPostingDetail not created",
                IsSuccess = false,
                Errors = new List<string>{"JobPostingDetail not created"}
            };

        var jobPostingDetailDto = _mapper.Map<JobPostingDetailOutputDto>(addedJobPostingDetail);

        return new ResponseMessageDto{
            Data = jobPostingDetailDto,
            Message = "JobPostingDetail created successfully",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> DeleteJobPostingDetailByIdAsync(int id)
    {
        var jobPostingDetail = await _jobPostingDetailRepository.GetByIdAsync(id);
        if(jobPostingDetail == null)
            return new ResponseMessageDto{
                Message = "JobPostingDetail not found",
                IsSuccess = false,
                Errors = new List<string>{"JobPostingDetail not found"}
            };
        //TODO: check if jobPostingDetail has any application
        await _jobPostingDetailRepository.DeleteAsync(jobPostingDetail);
        return new ResponseMessageDto{
            Message = "JobPostingDetail deleted successfully",
            IsSuccess = true
        };
    }

    public async Task<ResponseMessageDto> GetJobPostingDetailByIdAsync(int id)
    {
        var jobPostingDetail = await _jobPostingDetailRepository.GetByIdAsync(id);
        if(jobPostingDetail == null)
            return new ResponseMessageDto{
                Message = "JobPostingDetail not found",
                IsSuccess = false,
                Errors = new List<string>{"JobPostingDetail not found"}
            };
        return new ResponseMessageDto{
            Data = _mapper.Map<JobPostingDetailOutputDto>(jobPostingDetail),
            Message = "JobPostingDetail found",
            IsSuccess = true
        };

    }

    public async Task<ResponseMessageDto> GetJobPostingDetailsAsync(int jobPostingId)
    {
        var jobPostingDetails = await _jobPostingDetailRepository.ListAsync(x => x.JobPostingId == jobPostingId,orderBy: x => x.OrderBy(x => x.JobPostingDetailId));
        return new ResponseMessageDto{
            Data = _mapper.Map<List<JobPostingDetailOutputDto>>(jobPostingDetails),
            Message = "JobPostingDetails found",
            IsSuccess = true
        };
        
    }

    public async Task<ResponseMessageDto> UpdateJobPostingDetailAsync(int id, JobPostingDetailInputDto input)
    {
        var jobPostingDetail = await _jobPostingDetailRepository.GetByIdAsync(id);
        if(jobPostingDetail == null)
            return new ResponseMessageDto{
                Message = "JobPostingDetail not found",
                IsSuccess = false,
                Errors = new List<string>{"JobPostingDetail not found"}
            };
        //check if jobPostingId and positionId is not zero
        if(input.JobPostingId == 0 || input.PositonId == 0)
            return new ResponseMessageDto{
                Message = "JobPostingId or PositionId sıfır olamaz",
                IsSuccess = false,
                Errors = new List<string>{"JobPostingId or PositionId is not valid"}
            };
        //check if jobPostingId and positionId exists
        var jobPosting = await _jobPostingRepository.GetByIdAsync(input.JobPostingId);
        if(jobPosting == null)
            return new ResponseMessageDto{
                Message = "ilan bulunamadı",
                IsSuccess = false,
                Errors = new List<string>{"JobPosting not found"}
            };
        //check if position exists
        var position = await _positionRepository.GetByIdAsync(input.PositonId);
        if(position == null)
            return new ResponseMessageDto{
                Message = "Pozisyon bulunamadı",
                IsSuccess = false,
                Errors = new List<string>{"Position not found"}
            };
        var updatedJobPostingDetail = _mapper.Map<JobPostingDetailOutputDto>(input);
        updatedJobPostingDetail.JobPostingDetailId = id;
        await _jobPostingDetailRepository.UpdateAsync(_mapper.Map<JobPostingDetail>(updatedJobPostingDetail));
        return new ResponseMessageDto{
            Message = "JobPostingDetail updated successfully",
            IsSuccess = true
        };
        
    }
}
