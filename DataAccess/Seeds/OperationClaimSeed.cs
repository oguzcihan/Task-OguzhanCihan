using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Core.Entities.Identity;

namespace DataAccess.Seeds
{
    public class OperationClaimSeed : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            builder.HasData(
                new OperationClaim()
                {
                    Id = 1,
                    Name = "Admin"
                },
                new OperationClaim()
                {
                    Id = 2,
                    Name = "Standart"
                }
             );
        }
    }

}
