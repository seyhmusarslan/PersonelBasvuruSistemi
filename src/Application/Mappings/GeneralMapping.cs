using System;
using Application.Dto.JobPosting;
using Application.Dto.JobType;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappings
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            //JobPosting
            CreateMap<JobPostingInputDto,JobPosting>().ReverseMap();
            CreateMap<JobPostingOutputDto,JobPosting>().ReverseMap();

            //JobType
            CreateMap<JobTypeOutputDto,JobType>().ReverseMap();
            CreateMap<JobTypeInputDto,JobType>().ReverseMap();
        }
    }
}
