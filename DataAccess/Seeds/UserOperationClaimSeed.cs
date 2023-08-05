using Core.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
    public class UserOperationClaimSeed : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasData(
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
             );
        }
    }
}
