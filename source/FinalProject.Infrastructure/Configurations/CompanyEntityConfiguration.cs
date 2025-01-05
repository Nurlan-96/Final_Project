using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Infrastructure.Configurations
{
    public class CompanyEntityConfiguration : IEntityTypeConfiguration<CompanyEntity>
    {
        public void Configure(EntityTypeBuilder<CompanyEntity> builder)
        {
            builder.ToTable("company");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();


            builder.Property(c => c.Name).HasMaxLength(50).HasColumnName("name");
            builder.HasIndex(c => c.Name).IsUnique();


            builder.Property(c=>c.Description).HasMaxLength(500).HasColumnName("description");
            builder.Property(c=>c.Address).HasMaxLength(50).HasColumnName("address");
            builder.Property(c => c.PhoneNumber).HasColumnName("phone_number");
            builder.Property(c => c.IsDeleted).HasColumnName("is_deleted");
            builder.Property(c => c.Image).HasColumnName("image");
            builder.Property(c => c.Email).IsRequired().HasMaxLength(50).HasColumnName("email");
            builder.HasIndex(c => c.Email).IsUnique();
            builder.Property(c => c.UserId).HasColumnName("user_id");
            builder.HasIndex(c => c.UserId).IsUnique();
            builder.Property(c => c.CreatedDate).HasColumnName("created_date");
            builder.Property(c => c.UpdatedDate).HasColumnName("update_date");
        }
    }
}
