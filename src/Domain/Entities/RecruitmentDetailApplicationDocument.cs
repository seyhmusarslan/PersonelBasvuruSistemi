using Domain.Common;

namespace Domain.Entities
{
    public class RecruitmentDetailApplicationDocument:BaseEntity
    {
        public int RecruitmentDetailApplicationDocumentId { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RecruitmentId { get; set; }
        public Recruitment Recruitment { get; set; }
        public int RecruitmentDetailId { get; set; }
        public RecruitmentDetail RecruitmentDetail { get; set; }
        public string DocumentUrl { get; set; }
        public int DocumentId { get; set; }
        public Document Document { get; set; }

    }
}
