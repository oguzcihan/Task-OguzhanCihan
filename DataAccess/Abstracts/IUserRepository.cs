using Core.DataAccess.Abstracts;
using Core.Entities;
using Core.Entities.Identity;

namespace DataAccess.Abstracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        /// <summary>
        /// User a göre rol listesini döner.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        List<OperationClaim> GetClaimsByUser(User user);

        /// <summary>
        /// Varsayılan rolleri ekler.
        /// </summary>
        /// <param name="id"></param>
        void AddDefaultUserClaim(int id);

        /// <summary>
        /// In-memory çalışırken varsayılan verileri oluşturur.
        /// </summary>
        void AddDefaultDataForInMemory();
    }
}
