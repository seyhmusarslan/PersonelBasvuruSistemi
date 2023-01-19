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
        public int ApplicationId { get; set; }
        public int RecruitmentId { get; set; }
        public Recruitment Recruitment { get; set; }
        public int UserId { get; set; }
    }
}
