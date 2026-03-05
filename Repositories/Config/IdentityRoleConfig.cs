
using Entities.Models.IdentityUser;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class IdentityRoleConfig : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasData(
                new AppRole
                {
                    Id = 1,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = "a075152b-fb4b-4edb-976b-852705425030"
                },
                new AppRole
                {
                    Id = 2,
                    Name = "Editor",
                    NormalizedName = "EDITOR",
                    ConcurrencyStamp = "b11d7795-8522-4f2c-b155-1e80140e8d4a"
                },
                new AppRole
                {
                    Id = 3,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "a5feeb49-487d-4e90-8ac7-3b10fd80fed3"
                }


            );
        }
    }
}