using System;
using Microsoft.AspNetCore.Identity;

namespace Persistence.EFCore.Models.Identity
{
    public class ApplicationUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string TCKN { get; set; }
    }
}
