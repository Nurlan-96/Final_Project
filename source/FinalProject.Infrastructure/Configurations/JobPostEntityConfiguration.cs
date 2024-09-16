using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Configurations
{

    public class JobPostEntityConfiguration : IEntityTypeConfiguration<JobPost>
    {
        public void Configure(EntityTypeBuilder<JobPost> builder)
        {
            builder.ToTable("jobpost");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(60).HasColumnName("name");
            builder.HasIndex(c => c.Name).IsUnique();
        }
    }

}
