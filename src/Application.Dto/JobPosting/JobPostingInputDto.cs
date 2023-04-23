using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto.JobPosting
{
    public class JobPostingInputDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime EndDate { get; set; }
        public bool IsActive { get; set; }
        [Required]
        public int JobTypeId { get; set; }
    }
}
