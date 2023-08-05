using Core.DataAccess.EntityFramework;
using Core.Entities.Identity;
using DataAccess.Abstracts;
using DataAccess.Context;

namespace DataAccess.Concretes
{
    public class UserRepository : EfBaseRepository<User, AppDbContext>, IUserRepository
    {
        private AppDbContext _context;
        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        //kullanıcının rolleri çekildi
        public List<OperationClaim> GetClaimsByUser(User user)
        {
            //iki tablo join edildi
            var result = from operationClaim in _context.OperationClaims
                         join userOperationClaim in _context.UserOperationClaims
                             on operationClaim.Id equals userOperationClaim.OperationClaimId
                         where userOperationClaim.UserId == user.Id
                         select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
            //sonuçta olan claim listesi döndürüldü

            return result.ToList();
        }

        public void AddDefaultClaim(int id)
        {
            //claim tablosunda hiç kayıt yoksa kayıtlar eklenmiştir.
            var result = _context.OperationClaims.Any();
            if (!result)
            {
                var claims = new List<OperationClaim>
                {
                    new OperationClaim
                    {
                        Id = 1,
                        Name = "Admin"
                    },
                    new OperationClaim
                    {
                        Id = 2,
                        Name = "Standart"
                    }
                };

                _context.OperationClaims.AddRange(claims);
                _context.SaveChanges();

            }

            //ilk defa kayıt olan kullanıcılara standart rolü atanmıştır.
            var operationClaim = _context.OperationClaims.Where(claim => claim.Id == 2).FirstOrDefault();
            var userOperationClaim = new UserOperationClaim()
            {
                OperationClaimId = operationClaim.Id,
                UserId = id,
                CreatedDate = DateTime.Now,
            };
            _context.UserOperationClaims.Add(userOperationClaim);
            _context.SaveChanges();



        }

    }
}
