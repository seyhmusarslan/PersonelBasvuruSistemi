using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// Recruitment(İşe Alım) süreçlerindeki
    /// koşulları tanımlamaya yarar
    /// </summary>
    public class Condition:BaseEntity
    {
        public int ConditionId { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public List<RecruitmentDetailCondition> RecruitmentDetailConditions { get; set; }
    }
}
