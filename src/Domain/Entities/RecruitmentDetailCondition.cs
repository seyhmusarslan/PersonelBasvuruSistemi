using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    /// <summary>
    /// RecruitmentDetail tablosundaki kayıtlar için 
    /// gerekli olan şartları tanımlamaya yarar.
    /// </summary>
    public class RecruitmentDetailCondition:BaseEntity
    {
        public int RecruitmentDetailConditionId { get; set; }
        public int RecruitmentDetailId { get; set; }
        public RecruitmentDetail RecruitmentDetail { get; set; }
        public int ConditionId { get; set; }
        public Condition Condition { get; set; }
    }
}
