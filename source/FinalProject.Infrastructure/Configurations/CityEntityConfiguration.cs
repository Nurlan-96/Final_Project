using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FinalProject.Infrastructure.Configurations
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.ToTable("city");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name).HasMaxLength(50).HasColumnName("name");
            builder.HasIndex(c => c.Name).IsUnique();
        }
    }
}
