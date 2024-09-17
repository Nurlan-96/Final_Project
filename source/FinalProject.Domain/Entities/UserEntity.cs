using FinalProject.Domain.Entities.RoleAggregate;
using FinalProject.SharedKernel.Domain.Seedwork;

namespace FinalProject.Domain.Entities
{
    public class UserEntity:BaseEntity
    {
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public bool IsBanned { get; set; }
        public string? RefreshToken { get; set; }

        public void SetRole(int roleId)
        {
            RoleId = roleId;
        }

        public void SetDetails(string name, string username)
        {
            Fullname = name;
            Email = username;
        }

        public void ChangePassword(string passwordHash)
        {
            PasswordHash = passwordHash;
        }

        public void UpdateRefreshToken(string refreshToken)
        {
            RefreshToken = refreshToken;
        }

        //public void SetOTP(string otp, DateTime expDate)
        //{
        //    OTPCode = otp;
        //    OTPExpirationDate = expDate;
        //}

        //public void NullifyOTP()
        //{
        //    OTPCode = null;
        //    OTPExpirationDate = null;
        //    AllowChangeWithOTP = false;
        //}

        //public void AllowPasswordChangeWithOTP()
        //{
        //    AllowChangeWithOTP = true;
        //}

    }
}
