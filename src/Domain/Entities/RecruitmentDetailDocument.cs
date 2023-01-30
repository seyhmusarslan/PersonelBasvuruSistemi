using Domain.Common;

namespace Domain.Entities
{
    public class RecruitmentDetailDocument:BaseEntity
    {

        public int RecruitmentDetailDocumentId { get; set; }
        public int RecruitmentDetailId { get; set; }
        public RecruitmentDetail RecruitmentDetail { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }
    }
}
