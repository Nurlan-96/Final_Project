using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Configurations
{
    public class UserAppliedJobsConfiguration : IEntityTypeConfiguration<UserAppliedJob>
    {
        public void Configure(EntityTypeBuilder<UserAppliedJob> builder)
        {
            builder.ToTable("user_applied_jobs");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId).IsRequired().HasColumnName("user_id");
        }
    }
}
