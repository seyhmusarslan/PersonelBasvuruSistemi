using System;
using Application.Dto.Authentication;

namespace Application.Services.Authentication
{
    public interface IUserService
    {
        Task<UserManagerResponse> RegisterUserAsync(RegisterInputDto input);
        Task<UserManagerResponse> GetUserAsync(string id);
        Task<LoginOutputDto> LoginUserAsync(LoginUserInputDto input);
        Task<UserManagerResponse> ChangePasswordAsync(ChangePasswordInputDto input);
    }
}
