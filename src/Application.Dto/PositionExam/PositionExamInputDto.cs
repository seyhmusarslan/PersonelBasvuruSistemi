namespace Application.Dto.PositionExam;

public class PositionExamInputDto
{
    public int ExamId { get; set; }
    public int PositionId { get; set; }
    public double MinResult { get; set; }
    public double Multiplier { get; set; }
}
