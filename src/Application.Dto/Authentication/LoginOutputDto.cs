using System;
using Application.Dto.Common;

namespace Application.Dto.Authentication
{
    public class LoginOutputDto:ResponseMessageDto
    {
        public string Token { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }
}
