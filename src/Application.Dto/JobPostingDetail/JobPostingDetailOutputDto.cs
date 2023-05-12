using System.ComponentModel.DataAnnotations;

namespace Application.Dto.JobPostingDetail;

public class JobPostingDetailOutputDto
{
    public int JobPostingDetailId { get; set; }
    [Required]
    public string WorkedDestination { get; set; }
    [Required]
    public int Count { get; set; }
    public string Description { get; set; }
    [Required]
    public int PositonId { get; set; }
    [Required]
    public int JobPostingId { get; set; }
}
