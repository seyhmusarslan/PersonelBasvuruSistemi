using System.Runtime.Serialization;
using Domain.Common;

namespace Domain.Entities;

public class Applicant:BaseEntity
{
    /// <summary>
    /// Kullanıcıların ilanlara yapmış
    /// olduğu başvuruları tutan sınıftır
    /// </summary>
    public int ApplicantId { get; set; }
    public int JobPostingId { get; set; }
    public int ApplicantStatuId { get; set; }
    public ApplicantStatu ApplicantStatus { get; set; }
    public string UserId { get; set; }
}