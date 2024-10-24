using FinalProject.Domain.Entities;
using FinalProject.Domain.Entities.RoleAggregate;
using FinalProject.Domain.Exceptions;
using FinalProject.Infrastructure.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharedKernel.Domain.Seedwork;
using System.Reflection;

namespace FinalProject.Infrastructure.DAL
{
    public class AppDbContext(DbContextOptions options, IConfiguration configuration) : DbContext(options), IUnitOfWork
    {
        public DbSet<JobPostEntity> JobPosts { get; set; }
        public DbSet<CompanyEntity> Companies { get; set; }
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ReportEntity> Reports { get; set; }
        public DbSet<UserAppliedJob> UserAppliedJobs { get; set; }
        public DbSet<CVJobEntity> CVJobs { get; set; }
        public DbSet<CVEntity> CVEntities { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedRole.SeedData(modelBuilder);
            SeedAdmin.SeedData(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
            if (string.IsNullOrEmpty(connectionString))
            {
                connectionString = configuration.GetConnectionString("DefaultConnection")
                    ?? throw new ConnectionStringNotFoundException();
            }
            optionsBuilder.UseNpgsql(connectionString, sqlOptions =>
            {
                sqlOptions.MigrationsAssembly("FinalProject.Infrastructure.Migrations");
            });
        }
    }
}
