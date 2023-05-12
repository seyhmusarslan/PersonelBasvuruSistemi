namespace Application.Dto.PositionSpecificDocument;

public class PositionSpecificDocumentInputDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsRequired { get; set; }
    public int PositionId { get; set; }
}
