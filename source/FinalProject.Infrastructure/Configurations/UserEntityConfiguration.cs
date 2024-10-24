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

            builder.Property(c=>c.Email).IsRequired().HasMaxLength(50).HasColumnName("email");
            builder.HasIndex(c => c.Email).IsUnique();

            builder.Property(c => c.PasswordHash).IsRequired().HasColumnName("password");

            builder.Property(c => c.RefreshToken).HasColumnName("refresh_token");
            builder.HasIndex(c => c.RefreshToken).IsUnique();

            builder.Property(c => c.PhoneNumber).HasColumnName("phone_number");
            builder.HasIndex(c => c.PhoneNumber).IsUnique();

            builder.Property(c => c.CVJobId).HasColumnName("cv_job_id");
            builder.Property(c => c.RoleId).IsRequired().HasColumnName("role_id");
            builder.Property(c => c.OTPCode).HasColumnName("otp_code");
            builder.Property(c => c.IsBanned).HasColumnName("is_banned");
            builder.Property(c => c.OTPExpirationDate).HasColumnName("otp_expireation_date");
            builder.Property(c => c.AllowChangeWithOTP).HasColumnName("allow_change_with_otp");

            builder.Property(c => c.CreatedDate).HasColumnName("created_date");
            builder.Property(c => c.UpdatedDate).HasColumnName("updated_date");
        }
    }
}
