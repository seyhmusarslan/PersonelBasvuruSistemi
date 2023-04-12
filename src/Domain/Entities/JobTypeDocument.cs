using System;
using Domain.Common;

namespace Domain.Entities
{
    public class JobTypeDocument:BaseEntity
    {
        public int JobTypeDocumentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public int JobTypeId { get; set; }
        public JobType JobType { get; set; }
        public int DocumentGroupId { get; set; }
        public DocumentGroup DocumentGroup { get; set; }   
    }
}
