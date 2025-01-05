using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Infrastructure.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable("category");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50).HasColumnName("name");
            builder.HasIndex(c => c.Name).IsUnique();

            builder.Property(c => c.Icon).HasColumnName("icon");
            builder.Property(c => c.CreatedDate).HasColumnName("created_date");
            builder.Property(c => c.UpdatedDate).HasColumnName("update_date");
        }
    }
}
