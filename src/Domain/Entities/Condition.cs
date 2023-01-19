using Domain.Common;

namespace Domain.Entities
{
    public class Condition:BaseEntity
    {
        public int ConditionId { get; set; }
        public string Description { get; set; }
        public int ConditionType { get; set; }//Condition type entitysi tanımlanacak
        public bool Active { get; set; }
    }
}
