using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Dto.JobType
{
    public class JobTypeInputDto
    {
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
