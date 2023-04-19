using System;

namespace Application.Dto.Authentication
{
    public class ChangePasswordInputDto
    {
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
