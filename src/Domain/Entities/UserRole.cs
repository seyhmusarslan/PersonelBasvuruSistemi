using Domain.Common;

namespace Domain.Entities
{
    /// <summary>
    /// Kullanıcıların Rollerini ifade eder
    /// Bir kullanıcı birden fazla role sahip olabileceği için
    /// bir ara tabloya ihtiyaç var.
    /// </summary>
    public class UserRole:BaseEntity
    {
        public int UserRoleId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
