using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Dto.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Application.Services.Authentication;

namespace Persistence.EFCore.Services;

public class JwtTokenGeneratorService : IJwtTokenGeneratorService
{
    private readonly IConfiguration _configuration;

    public JwtTokenGeneratorService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ResponseMessageDto GenerateToken(string userId, string userName, string email, string PhoneNumber)
    {
        //Ganerate a token

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, userId),
            new Claim(ClaimTypes.Name, userName),
            new Claim(ClaimTypes.Email, email),
        };
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"])), SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: "https://pbs.dicle.edu.tr",
            audience: "https://pbs.dicle.edu.tr",
            expires: DateTime.Now.AddMinutes(30),
            claims: claims,
            signingCredentials: signingCredentials
        );
        var tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);
        return new ResponseMessageDto{
            Message = tokenAsString,
            IsSuccess = true
        };
    }

    public ResponseMessageDto RefreshToken(string token)
    {

        //Refresh a token
        var jwtToken = new JwtSecurityTokenHandler().ReadJwtToken(token);
        var claims = jwtToken.Claims;
        var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"])), SecurityAlgorithms.HmacSha256);
        var newToken = new JwtSecurityToken(
            issuer: "https://pbs.dicle.edu.tr",
            audience: "https://pbs.dicle.edu.tr",
            expires: DateTime.Now.AddMinutes(30),
            claims: claims,
            signingCredentials: signingCredentials
        );
        var tokenAsString = new JwtSecurityTokenHandler().WriteToken(newToken);
        return new ResponseMessageDto{
            Message = tokenAsString,
            IsSuccess = true
        };
    }

    public ClaimsPrincipal ValidateToken(string token)
    {
        //Validate a token
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["AuthSettings:Key"]);
        //check if token is valid and return true or false
        

        var claimsIdentity = tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = "https://pbs.dicle.edu.tr",
            ValidIssuer = "https://pbs.dicle.edu.tr"
        }, out SecurityToken validatedToken);
         
        return claimsIdentity;

    }
}