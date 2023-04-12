using System;
using Domain.Common;

namespace Domain.Entities
{
    //sozlesmeli,ogretim elemani ve ogretim uyesi gibi farkli ilan turlerini  iceren sinif
    public class JobType:BaseEntity
    {
        public int JobTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<JobTypeDocument> RequiredDocuments { get; set; }
    }
    
}
