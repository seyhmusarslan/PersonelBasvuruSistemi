namespace Application.Dto.JobTypeDocument;

public class JobTypeDocumentInputDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsRequired { get; set; }
    public int JobTypeId { get; set; }
    public int DocumentGroupId { get; set; }
}
