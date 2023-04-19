using System;
using Microsoft.AspNetCore.Identity;

namespace Persistence.EFCore.Models.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public string Description { get; set; }
    }
}
