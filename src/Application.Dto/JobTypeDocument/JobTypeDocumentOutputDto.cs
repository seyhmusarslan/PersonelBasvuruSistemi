namespace Application.Dto.JobTypeDocument;

public class JobTypeDocumentOutputDto
{
    public int JobTypeDocumentId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool IsRequired { get; set; }
    public int JobTypeId { get; set; }
    public int DocumentGroupId { get; set; }
}
