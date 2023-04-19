using System;
using Domain.Common;

namespace Domain.Entities
{
    //İlan detayındaki herbir pozisyon için gerekli olan sınavları ve minimum sonucunu ve çarpanını tutan sınıftır.
    public class PositionExam:AuditEntity
    {
        public int PositionExamId { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public double MinResult { get; set; }
        public double Multiplier { get; set; }
    }
}
