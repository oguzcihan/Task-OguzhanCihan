using Core.Dtos;
using Core.Entities.Identity;
using Core.Utilities.Security.Jwt;

namespace Business.Abstracts
{
    public interface IAuthService
    {
        /// <summary>
        /// Kullanıcı kayıt işlemini yapar.
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <param name="password"></param>
        /// <returns>UserId</returns>
        User Register(UserForRegisterDto userForRegisterDto, string password);

        /// <summary>
        /// Kullanıcı giriş işlemlerini yapar.
        /// </summary>
        /// <param name="userForLoginDto"></param>
        /// <returns></returns>
        /// <exception cref="ClientSideException"></exception>
        User Login(UserForLoginDto userForLoginDto);

        /// <summary>
        /// Kullanıcı kontrolünü yapar.
        /// </summary>
        /// <param name="username"></param>
        /// <exception cref="ClientSideException"></exception>
        void UserExists(string email);

        /// <summary>
        /// Kullanıcılar için token oluşturur.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>AccessToken</returns>
        AccessToken CreateAccessToken(User user);
    }
}
