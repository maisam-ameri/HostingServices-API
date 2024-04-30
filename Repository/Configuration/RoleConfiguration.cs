
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
            
                new IdentityRole
                {
                    Name = "manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Name = "adminstrator",
                    NormalizedName = "ADMINSTRATOR"
                }

            );
        }
    }
}
