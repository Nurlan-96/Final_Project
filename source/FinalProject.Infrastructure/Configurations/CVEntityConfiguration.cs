using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Infrastructure.Configurations
{
    public class CVEntityConfiguration: IEntityTypeConfiguration<CVEntity>
    {
        public void Configure(EntityTypeBuilder<CVEntity> builder)
        {
            builder.ToTable("cventity");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Fullname).HasMaxLength(50).HasColumnName("full_name");
            builder.Property(c => c.Email).IsRequired().HasColumnName("email");
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.Education).HasColumnName("education");
            builder.Property(c => c.PhoneNumber).HasColumnName("phone_number");
            builder.Property(c => c.Experience).HasColumnName("experience");
            builder.Property(c => c.City).HasColumnName("city");
            builder.Property(c => c.AboutMe).HasMaxLength(2000).HasColumnName("desciption");
            builder.Property(c => c.Address).HasMaxLength(100).HasColumnName("address");
            
            builder.Property(c => c.Address).HasColumnName("address");
            builder.Property(c => c.ExpectedSalary).HasColumnName("expctedsalary");

            builder.Property(c => c.CreatedDate).HasColumnName("created_date");
            builder.Property(c => c.UpdatedDate).HasColumnName("update_date");
        }
    }
}
