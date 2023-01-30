using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Application:BaseEntity
    {
        /// <summary>
        /// Kullanıcıların ilanlara yapmış
        /// olduğu başvuruları tutan sınıftır
        /// </summary>
        public int ApplicationId { get; set; }
        public int RecruitmentId { get; set; }
        public Recruitment Recruitment { get; set; }
        public int RecruitmentDetailId { get; set; }
        public RecruitmentDetail RecruitmentDetail { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
