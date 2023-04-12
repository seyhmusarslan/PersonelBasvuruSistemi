using System;
using Domain.Common;

namespace Domain.Entities
{
    //Akademik,Zorunlu belgeler,spesifik belgeler vs
    public class DocumentGroup:BaseEntity
    {
        public int DocumentGroupId { get; set; }
        public string Name { get; set; }
    }
}
