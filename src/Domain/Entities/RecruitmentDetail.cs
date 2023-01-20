using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// İşe alım süreçlerindeki ilanın alt bölümlerini tutar
    /// Örneğin; Bilgisayar Mühendisi Alım .... 1 Adet ... Şu şartlarda olmalı vs.
    /// </summary>
    public class RecruitmentDetail:BaseEntity
    {
        public int RecruitmentDetailId { get; set; }
        public int RecruitmentId { get; set; }
        public Recruitment Recuruitment { get; set; }
        public string Unit { get; set; }
        public string Division { get; set; }
        public string Program { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int Count { get; set; }
        public List<RecruitmentDetailCondition> RecruitmentDetailConditions { get; set; }
    }
}
