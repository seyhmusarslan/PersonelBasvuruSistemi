using Domain.Common;

namespace Domain.Entities;

public class Application:BaseEntity
{
    /// <summary>
    /// Kullanıcıların ilanlara yapmış
    /// olduğu başvuruları tutan sınıftır
    /// </summary>
    public int ApplicationId { get; set; }
    public int JobPostingId { get; set; }
    public JobPosting JobPosting { get; set; }
    public int JobPostingDetailId { get; set; }
    public JobPostingDetail JobPostingDetail { get; set; }
    public string UserId { get; set; }
}