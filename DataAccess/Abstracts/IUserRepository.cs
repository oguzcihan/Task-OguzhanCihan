using Core.DataAccess.Abstracts;
using Core.Entities;
using Core.Entities.Identity;

namespace DataAccess.Abstracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        List<OperationClaim> GetClaimsByUser(User user);

        void AddDefaultUserClaim(int id);

        void AddDefaultDataForInMemory();
    }
}
