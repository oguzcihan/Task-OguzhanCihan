using Core.Dtos;
using Core.Entities.Identity;
using Core.Utilities.Security.Jwt;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        User Register(UserForRegisterDto userForRegisterDto, string password);
        User Login(UserForLoginDto userForLoginDto);
        void UserExists(string email);
        AccessToken CreateAccessToken(User user);
    }
}
