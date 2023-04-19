using System;
using Domain.Common;

namespace Domain.Entities
{
	public class ApplicantDocument:BaseEntity
	{
		public int ApplicantDocumentId { get; set; }
		public string DocumentName { get; set; }
		public string DocumentPath { get; set; }
		public int ApplicantId { get; set; }
		public Applicant Applicant { get; set; }
	}
}

