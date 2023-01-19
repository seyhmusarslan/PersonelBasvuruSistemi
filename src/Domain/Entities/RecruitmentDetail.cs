using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class RecruitmentDetail:BaseEntity
    {
        public int RecruitmentDetailId { get; set; }
        public int RecruitmentId { get; set; }
        public Recruitment Recuruitment { get; set; }
        public string Unit { get; set; }
        public string Division { get; set; }
        public string Program { get; set; }
        public int Count { get; set; }
    }
}
