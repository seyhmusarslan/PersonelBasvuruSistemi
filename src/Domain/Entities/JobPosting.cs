using System;
using Domain.Common;

namespace Domain.Entities
{
    public class JobPosting:BaseEntity
    {
        public int JobPostingId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        public ICollection<JobPostingDetail> JobPostingDetails { get; set; }
        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }
    }
}
