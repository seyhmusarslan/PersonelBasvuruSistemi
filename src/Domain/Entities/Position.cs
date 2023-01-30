using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// Position sınıfı RecruitmentDetails(işe alım detay)
    /// tablosundaki bu işin hangi pozistona ait olduğunu tutmaya
    /// yarar.Örneğin Mühendis,Ebe,Hemşire vs gibi.
    /// Bir nevi hangi kadroya alınacağını belirliyoruz.
    /// </summary>
    public class Position:BaseEntity
    {
        public int PositionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
