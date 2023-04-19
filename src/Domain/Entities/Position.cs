using System;
using Domain.Common;

namespace Domain.Entities
{
    //İlan detayındaki açılan pozisyonlar.Mühendis,ebe,
    public class Position:AuditEntity
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public ICollection<PositionExam> PositionExams { get; set; }
        public ICollection<PositionSpecificDocument> PositionSpecificDocuments { get; set; }
    }
}
