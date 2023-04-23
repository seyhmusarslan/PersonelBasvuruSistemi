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
            CreateMap<JobPostingInputDto,JobPosting>().ReverseMap();
            CreateMap<JobTypeInputDto,JobType>().ReverseMap();
            CreateMap<JobTypeOutputDto,JobType>().ReverseMap();
        }
    }
}
