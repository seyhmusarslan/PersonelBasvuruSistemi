using System;
using Application.Dto.Common;

namespace Application.Dto.JobType
{
    public class JobTypeOutputDto
    {
        public int JobTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
