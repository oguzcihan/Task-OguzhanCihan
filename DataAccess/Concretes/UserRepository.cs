using Core.DataAccess.EntityFramework;
using Core.Entities.Identity;
using DataAccess.Abstracts;
using DataAccess.Context;
using System.Security.Cryptography;
using System.Text;

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

        public void AddDefaultUserClaim(int id)
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

        /// <summary>
        /// AppSettings dosyasındaki in-memory değişkeni true olduğunda çalışır.
        /// </summary>
        public void AddDefaultDataForInMemory()
        {
            #region User
            using var hmac = new HMACSHA512();
            var user = new List<User>
            {
                    new User()
                    {
                        Id = 1,
                        FirstName = "admin",
                        Username = "admin",
                        Email = "admin@gmail.com",
                        Status = true,
                        PasswordSalt = hmac.Key,
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1")),
                        CreatedDate = DateTime.Now
                    },
                    new User()
                    {
                        Id = 2,
                        FirstName = "standart",
                        Username = "standart",
                        Email = "standart@gmail.com",
                        Status = true,
                        PasswordSalt = hmac.Key,
                        PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("1")),
                        CreatedDate = DateTime.Now
                    }
            };

            _context.Users.AddRange(user);

            #endregion

            #region OperationClaim
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
            #endregion

            #region UserOperationClaim
            var userOperationClaims = new List<UserOperationClaim>
        {
            new UserOperationClaim()
            {
                //admin
                Id = 1,
                OperationClaimId = 1,
                UserId = 1,
                CreatedDate = DateTime.Now,
            },
            new UserOperationClaim()
            {
                //standart
                Id = 2,
                OperationClaimId = 2,
                UserId = 2,
                CreatedDate = DateTime.Now,
            }
        };
            _context.UserOperationClaims.AddRange(userOperationClaims);
            #endregion

            _context.SaveChanges();


        }

    }
}
