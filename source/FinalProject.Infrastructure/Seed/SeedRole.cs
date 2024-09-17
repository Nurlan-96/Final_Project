using CryptoHelper;
using Domain.Entities.RoleAggergate;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Entities.RoleAggregate;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infrastructure.Seed
{
    public class SeedRole
    {
        public static void SeedData(ModelBuilder builder)
        {
            if (!builder.Model.GetEntityTypes().Any(e => e.ClrType.Name == "user_roles"))
            {
                builder.Entity<Role>().HasData(
                    new Role { Id = RoleParameter.SuperAdmin.Id, Name = RoleParameter.SuperAdmin.Name }
                );
            }
        }
    }
}
