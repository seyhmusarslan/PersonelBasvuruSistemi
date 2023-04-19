using Domain.Common;

namespace Domain.Entities;

public class ApplicantStatu:AuditEntity
{
    public int ApplicantStatuId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}