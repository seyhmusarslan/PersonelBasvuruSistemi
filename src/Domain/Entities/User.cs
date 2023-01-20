using Domain.Common;

namespace Domain.Entities
{
    public class User:BaseEntity
    {
        /// <summary>
        /// Kullanıcı için gerekli bilgileri tutar
        /// </summary>
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string IdentityNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Gender { get; set; }
        public string Address { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}
