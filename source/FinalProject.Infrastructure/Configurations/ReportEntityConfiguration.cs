using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Infrastructure.Configurations
{
    public class ReportEntityConfiguration : IEntityTypeConfiguration<ReportEntity>
    {
        public void Configure(EntityTypeBuilder<ReportEntity> builder)
        {
            builder.ToTable("report");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Reason).HasMaxLength(500).HasColumnName("reason").IsRequired();
            builder.Property(c => c.JobPostId).HasColumnName("job_post_id").IsRequired();
            builder.Property(c => c.UserId).HasColumnName("user_id").IsRequired();
            builder.Property(c => c.CreatedDate).HasColumnName("created_date");
            builder.Property(c => c.UpdatedDate).HasColumnName("update_date");
        }
    }
}
