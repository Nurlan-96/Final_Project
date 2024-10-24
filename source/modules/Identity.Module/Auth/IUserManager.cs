using FinalProject.Domain.Entities;

namespace Identity.Module.Auth
{
    public interface IUserManager
    {
        int? GetCurrentUserId();
        string GetCurrentUserName();
        Task<UserEntity> GetCurrentUser();
        (string token, DateTime expiresAt) GenerateJwtToken(UserEntity user);
    }
}