using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace DataAccess.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();

            builder.HasData(
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

            );
        }
    }
}
