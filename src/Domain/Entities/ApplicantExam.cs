using System;
using Domain.Common;

namespace Domain.Entities
{
	public class ApplicantExam:BaseEntity
	{
		public int ApplicantExamId { get; set; }
		public string ExamName { get; set; }
		public double ExamResult { get; set; }
		public int Multiplier { get; set; }
		public int ExamYear { get; set; }
		public int ApplicantId { get; set; }
		public Applicant Applicant { get; set; }
	}
}

