using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using FinalProject.Domain.Entities.RoleAggregate;

namespace FinalProject.Infrastructure.Configurations
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("role");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50).HasColumnName("name");
            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}
