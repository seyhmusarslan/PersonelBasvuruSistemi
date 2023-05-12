namespace Application.Dto.ApplicantExam;

public class ApplicantExamInputDto
{
    public string ExamName { get; set; }
    public double ExamResult { get; set; }
    public int Multiplier { get; set; }
    public int ExamYear { get; set; }
    public int ApplicantId { get; set; }
}
