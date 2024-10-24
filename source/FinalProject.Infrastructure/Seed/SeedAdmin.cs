using CryptoHelper;
using Domain.Entities.RoleAggergate;
using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Seed
{
    public class SeedAdmin
    {
        public static void SeedData(ModelBuilder builder)
        {
            if (!builder.Model.GetEntityTypes().Any(e => e.ClrType.Name == "users"))
            {
                UserEntity user = new()
                {
                    Id = 1,
                    PhoneNumber = "Test"
                };
                user.SetDetails("Alex Mercer", "alex@example.com", "000000");
                user.SetRole(RoleParameter.SuperAdmin.Id);
                user.ChangePassword(Crypto.HashPassword("unrealengine2012"));
                builder.Entity<UserEntity>().HasData(
                    user
                );
            }
        }
    }
}
