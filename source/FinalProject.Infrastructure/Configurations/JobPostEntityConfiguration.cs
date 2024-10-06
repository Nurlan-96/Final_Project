using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Configurations
{

    public class JobPostEntityConfiguration : IEntityTypeConfiguration<JobPostEntity>
    {
        public void Configure(EntityTypeBuilder<JobPostEntity> builder)
        {
            builder.ToTable("jobpost");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50).HasColumnName("name");
            builder.Property(c => c.Education).HasColumnName("education");
            builder.Property(c => c.Experience).HasColumnName("experience");
            builder.Property(c => c.ExpirationDate).HasColumnName("exp_date");
            builder.Property(c => c.Description).HasMaxLength(5000).HasColumnName("desciption");
            builder.Property(c => c.Requirements).HasMaxLength(5000).HasColumnName("requirements");

            builder.Property(c => c.Address).HasColumnName("address");
            builder.Property(c => c.Salary).HasColumnName("salary");
        }
    }

}
