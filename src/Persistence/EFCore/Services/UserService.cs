using Application.Dto.Authentication;
using Application.Services.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Persistence.EFCore.Models.Identity;

namespace Persistence.EFCore.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;
        private readonly IConfiguration _configuration;

        public UserService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        IConfiguration configuration,
        IJwtTokenGeneratorService jwtTokenGeneratorService = null)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }

        public async Task<UserManagerResponse> ChangePasswordAsync(ChangePasswordInputDto input)
        {
            var user =await _userManager.FindByEmailAsync(input.Email);
            if(user is null) throw new NullReferenceException("User not found");
            var result = await _userManager.ChangePasswordAsync(user,input.CurrentPassword,input.NewPassword);
            if(result.Succeeded){
                return new UserManagerResponse{
                    Message="Password changed successfully",
                    IsSuccess=true
                };
            }
            return new UserManagerResponse{
                Message="Password did not change",
                IsSuccess=false,
                Errors=result.Errors.Select(p=>p.Description)
            };
        }

        public async Task<UserManagerResponse> GetUserAsync(string id)
        {
            var user =await _userManager.FindByIdAsync(id);
            if(user is null) throw new NullReferenceException("User not found");
            return new UserManagerResponse{
                Message="User found",
                IsSuccess=true
            };
        }

        public async Task<LoginOutputDto> LoginUserAsync(LoginUserInputDto input)
        {
            var user =await _userManager.FindByEmailAsync(input.Email);
            if(user is null) throw new NullReferenceException("User not found");

            var result = await _userManager.CheckPasswordAsync(user,input.Password);
            if(!result){
                return new LoginOutputDto{
                    Message="Invalid password",
                    IsSuccess=false
                };
            }
            var responseMessage = _jwtTokenGeneratorService.GenerateToken(user.Id,user.UserName,user.Email,user.PhoneNumber);
            if(!responseMessage.IsSuccess) throw new Exception("Token generation failed");
            //Sign in user
            await _signInManager.SignInAsync(user,isPersistent:false);


            return new LoginOutputDto{
                Token=responseMessage.Message,
                IsSuccess=true,
                Message="Login successful"
            };

            
        }

        public async Task<UserManagerResponse> RegisterUserAsync(RegisterInputDto input)
        {
            if(input is null) throw new NullReferenceException("Register model is null");
            if(input.Password!=input.ConfirmPassword){
                return new UserManagerResponse{
                  Message="Confirm message doesn't match the password",
                  IsSuccess=false  
                };
            }
            var applicationUser = new ApplicationUser{
                Id=Guid.NewGuid().ToString(),
                Email=input.Email,
                BirthDate=DateTime.Now.AddYears(-35),
                UserName=input.Email
            };
            
            var result =await _userManager.CreateAsync(applicationUser,input.Password);
            if(result.Succeeded){
                return new UserManagerResponse{
                    Message="User succesfully created",
                    IsSuccess=true
                };
            }
            return new UserManagerResponse{
                Message="User did not create",
                IsSuccess=false,
                Errors=result.Errors.Select(p=>p.Description)
            };
            
        }
    }

}
