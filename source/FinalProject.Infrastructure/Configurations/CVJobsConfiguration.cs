using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Infrastructure.Configurations
{
    public class CVJobsConfiguration: IEntityTypeConfiguration<CVJob>
    {
        public void Configure(EntityTypeBuilder<CVJob> builder)
        {
            builder.ToTable("cvjob");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50).HasColumnName("name");
            builder.Property(c => c.CompanyName).HasMaxLength(50).HasColumnName("company_name");
            builder.Property(c => c.Description).HasMaxLength(5000).HasColumnName("desciption");
            builder.Property(c => c.City).HasColumnName("city");
            builder.Property(c => c.StartDate).HasColumnName("start_date");
            builder.Property(c => c.EndDate).HasColumnName("end_date");

            builder.Property(c => c.CreatedDate).HasColumnName("created_date");
            builder.Property(c => c.UpdatedDate).HasColumnName("update_date");

        }

    }
}
