using Business.Abstracts;
using Core.Entities.Identity;
using Core.Utilities.AppSettings;
using DataAccess.Abstracts;
using Microsoft.Extensions.Configuration;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;
        protected IConfiguration _configuration { get; set; }

        public UserManager(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaimsByUser(user);
        }

        public void Add(User user)
        {
            var existingUser = _userRepository.Add(user);
            _userRepository.AddDefaultUserClaim(existingUser.Id);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.Get(u => u.Username == username);
        }

        public void AddDefaultDataForInMemory()
        {
            var appSettings = _configuration.GetSection("DatabaseOptions").Get<AppSettings>();
            if (appSettings.UseInMemoryDatabase)
            {
                _userRepository.AddDefaultDataForInMemory();
            }

        }
    }
}
