using Microsoft.AspNetCore.Mvc;
using Application.Dto.Authentication;
using Application.Services.Authentication;

namespace RestApi.Controllers
{
    [Route("auth")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenGeneratorService _jwtTokenGeneratorService;

        public AuthController(IUserService userService, IJwtTokenGeneratorService jwtTokenGeneratorService = null)
        {
            this._userService = userService;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Post(RegisterInputDto input){
            var result = await _userService.RegisterUserAsync(input);
            if(!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Post(LoginUserInputDto input){
            var result = await _userService.LoginUserAsync(input);
            if(!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("change-password")]
        public async Task<IActionResult> Post(ChangePasswordInputDto input){
            var result = await _userService.ChangePasswordAsync(input);
            if(!result.IsSuccess) return BadRequest(result);
            return Ok(result);
        }
        [HttpPost("refresh-token")]
        public IActionResult Post(string token){
            var result =_jwtTokenGeneratorService.RefreshToken(token);
            if(result is null) return BadRequest(result);
            return Ok(result);
        }
    }
}
