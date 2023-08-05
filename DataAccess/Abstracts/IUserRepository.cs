using Core.DataAccess.Abstracts;
using Core.Entities;
using Core.Entities.Identity;

namespace DataAccess.Abstracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
    }
}
