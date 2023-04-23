using System;
using Application.Dto.Common;

namespace Application.Dto.JobPosting
{
    public class JobPostingOutputDto
    {
        public int JobPostingId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int JobTypeId { get; set; }
    }
}
