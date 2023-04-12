using System;

namespace Domain.Entities
{
    //sozlesmeli,ogretim elemani ve ogretim uyesi gibi farkli ilan turlerini  iceren sinif
    public class JobType
    {
        public int JobTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<Document> RequiredDocuments { get; set; }
        public ICollection<Exam> Exams { get; set; }
    }
    
}
