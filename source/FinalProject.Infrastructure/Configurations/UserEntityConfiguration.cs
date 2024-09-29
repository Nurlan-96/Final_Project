using FinalProject.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.Infrastructure.Configurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("user");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Fullname).IsRequired().HasMaxLength(60).HasColumnName("name");

            builder.Property(c=>c.Email).IsRequired().HasColumnName("email");
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.PasswordHash).IsRequired().HasColumnName("password");
            builder.Property(c => c.RefreshToken).HasColumnName("refresh_token");
            builder.Property(c => c.RoleId).IsRequired().HasColumnName("role");
            builder.Property(c => c.OTPCode).HasColumnName("otpcode");
            builder.Property(c => c.OTPExpirationDate).HasColumnName("otpexpireationdate");
            builder.Property(c => c.OTPExpirationDate).HasColumnName("otpexpireationdate");
            builder.Property(c => c.AllowChangeWithOTP).HasColumnName("allowchangewithotp");
            builder.Property(c => c.RefreshToken).HasColumnName("refreshtoken");
        }
    }
}
