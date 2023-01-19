using Domain.Common;

namespace Domain.Entities
{
    //İşe alım ile ilgili verileri tutan sınıftır.
    //İşe alım ilanı çıkıldığında kullanılır.
    public class Recruitment : BaseEntity
    {
        public int RecruitmentId { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; }
    }
}
