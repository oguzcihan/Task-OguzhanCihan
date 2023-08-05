using AutoMapper;
using Business.Abstracts;
using Business.Exceptions;
using Core.Dtos;
using Core.Entities.Identity;
using Core.UnitOfWork;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.Jwt;

namespace Business.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUnitOfWork _unitOfWork;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUnitOfWork unitOfWork)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Kullanıcı kayıt işlemi.
        /// </summary>
        /// <param name="userForRegisterDto"></param>
        /// <param name="password"></param>
        /// <returns>UserId</returns>
        public User Register(UserForRegisterDto userForRegisterDto, string password)
        {
            try
            {
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
                var user = new User
                {
                    Email = userForRegisterDto.Email,
                    FirstName = userForRegisterDto.Firstname,
                    Username = userForRegisterDto.Username,
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    Status = true
                };
                _userService.Add(user);
                _unitOfWork.CommitAsync();
                return user;
            }
            catch
            {
                throw new ClientSideException("Failed to create record contact your system administrator!");
            }


        }

        public User Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByUsername(userForLoginDto.Username);
            if (userToCheck == null)
            {
                throw new ClientSideException("user not found please register");
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                throw new ClientSideException("incorrect password!");
            }

            return userToCheck;
        }

        public void UserExists(string username)
        {
            if (_userService.GetByUsername(username) != null)
            {
                throw new ClientSideException($"{username} already exists!");
            }
        }

        public AccessToken CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);

            return accessToken;
        }
    }
}
