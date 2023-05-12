using System.ComponentModel.DataAnnotations;

namespace Application.Dto.Position;

public class PositionInputDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string Code { get; set; }
    public string Description { get; set; }
}
