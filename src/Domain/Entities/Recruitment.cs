using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// İşe alım ile ilgili verileri tutan sınıftır.
    /// İşe alım ilanı çıkıldığında kullanılır.
    /// </summary>
    public class Recruitment : AuditEntity
    {
        public int RecruitmentId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
        public int RecruitmentTypeId { get; set; }
        public RecruitmentType RecruitmentType { get; set; }
        public List<RecruitmentDetail> RecruitmentDetails { get; set; }
    }
}
