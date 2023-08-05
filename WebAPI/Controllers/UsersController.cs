using Business.Abstracts;
using Core.Dtos;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class UsersController : BaseController
    {

        private readonly IAuthService _authService;

        public UsersController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);

            var result = _authService.CreateAccessToken(userToLogin);

            return CreateActionResult(RestResponseDto<AccessToken>.Success(StatusCodes.Status200OK, result));
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            _authService.UserExists(userForRegisterDto.Username);

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult);

            return CreateActionResult(RestResponseDto<AccessToken>.Success(StatusCodes.Status200OK, result));
        }


    }
}
