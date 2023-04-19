using System;
using Domain.Common;

namespace Domain.Entities
{
    public class PositionSpecificDocument: AuditEntity
    {
        public int PositionSpecificDocumentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsRequired { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
