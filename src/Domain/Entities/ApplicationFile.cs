using Domain.Common;

namespace Domain.Entities
{
    public class ApplicationFile:BaseEntity
    {
        public int ApplicationFileId { get; set; }
        public int ApplicationId { get; set; }
        public Application Application { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RecruitmentId { get; set; }
        public Recruitment Recruitment { get; set; }
        public int RecruitmentDetailId { get; set; }
        public RecruitmentDetail RecruitmentDetail { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string FileUrl { get; set; }
        
    }
}
