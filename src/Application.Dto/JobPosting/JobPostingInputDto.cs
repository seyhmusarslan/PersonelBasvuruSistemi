using System;

namespace Application.Dto.JobPosting
{
    public class JobPostingInputDto
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public int JobTypeId { get; set; }
    }
}
