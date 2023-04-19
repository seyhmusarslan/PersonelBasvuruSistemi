using System;
using System.Security.Claims;
using Application.Dto.Common;

namespace Application.Services.Authentication
{
    
    public interface IJwtTokenGeneratorService
    {
        //Create a method that will generate a token
        ResponseMessageDto GenerateToken(string userId, string userName, string email,string PhoneNumber);

        //Create a method that will validate a token
        ClaimsPrincipal ValidateToken(string token);

        //Create a method that will refresh a token

        ResponseMessageDto RefreshToken(string token);
    }
}
