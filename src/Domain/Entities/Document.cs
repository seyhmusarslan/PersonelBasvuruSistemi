using Domain.Common;

namespace Domain.Entities
{
    public class Document:BaseEntity
    {
        public int DocumentId { get; set; }
        public string DocumentName { get; set; }
        public string Description { get; set; }
        public string FormName { get; set; }
        public bool IsRequiredForAllPositions { get; set; }
        public List<RecruitmentDetailDocument> RecruitmentDetailDocuments { get; set; }
    }
}
