namespace Application.Dto.PositionExam;

public class PositionExamOutputDto
{
    public int PositionExamId { get; set; }
    public int ExamId { get; set; }
    public int PositionId { get; set; }
    public double MinResult { get; set; }
    public double Multiplier { get; set; }
}
