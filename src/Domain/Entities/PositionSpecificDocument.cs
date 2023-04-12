using System;
using Domain.Common;

namespace Domain.Entities
{
    public class PositionSpecificDocument: Document
    {
        public int PositionSpecificDocumentId { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
