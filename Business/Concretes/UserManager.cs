using Business.Abstracts;
using Core.Entities.Identity;
using DataAccess.Abstracts;

namespace Business.Concretes
{
    public class UserManager : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userRepository.GetClaimsByUser(user);
        }

        public void Add(User user)
        {
            var existingUser = _userRepository.Add(user);
            _userRepository.AddDefaultClaim(existingUser.Id);
        }

        public User GetByUsername(string username)
        {
            return _userRepository.Get(u => u.Username == username);
        }
    }
}
