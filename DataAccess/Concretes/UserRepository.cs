using Core.DataAccess.EntityFramework;
using Core.Entities.Identity;
using DataAccess.Abstracts;
using DataAccess.Context;

namespace DataAccess.Concretes
{
    public class UserRepository : EfBaseRepository<User, AppDbContext>, IUserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        //kullanıcının rolleri çekildi.
        public List<OperationClaim> GetClaims(User user)
        {
            //iki tabloyu join ettim.
            var result = from operationClaim in _appDbContext.OperationClaims
                         join userOperationClaim in _appDbContext.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name }; //sonuçta olan claim listesi döndürüldü

            return result.ToList();
        }

    }
}
