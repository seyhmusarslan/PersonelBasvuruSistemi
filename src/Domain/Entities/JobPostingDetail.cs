using System;
using Domain.Common;

namespace Domain.Entities
{
    public class JobPostingDetail:AuditEntity
    {
        public int JobPostingDetailId { get; set; }
        public string WorkedDestination { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public int PositonId { get; set; }
        public Position Position { get; set; }
    }
}
