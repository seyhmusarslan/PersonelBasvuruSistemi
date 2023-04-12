using System;
using Domain.Common;

namespace Domain.Entities
{
    //KPSS, YDS , ALES 
    public class Exam:BaseEntity
    {
        public int ExamId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PositionExam> PositionExams { get; set; }
    }
}
