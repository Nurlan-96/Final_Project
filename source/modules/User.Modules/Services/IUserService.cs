using Identity.Module.Response;
using User.Module.Commands;
using UserModule.Commands;

namespace User.Module.Services
{
    public interface IUserService
    {
        Task<bool> ChangePassword(ChangePasswordCommand request, CancellationToken cancellationToken);
        Task<JWTResponse> RefreshToken(RefreshTokenCommand request, CancellationToken cancellationToken);
        Task<bool> ValidateToken(ValidateTokenCommand request, CancellationToken cancellationToken);
        Task<bool> ForgotPassword(ForgotPasswordCommand request, CancellationToken cancellationToken);
        Task<bool> ForgotPasswordSendOTP(ForgotPasswordSendOTPCommand request, CancellationToken cancellationToken);
        Task<bool> ResetPassword(ResetPasswordCommand request, CancellationToken cancellationToken);
        Task<bool> ConfirmOTP(ConfirmOTPCommand request, CancellationToken cancellationToken);





    }
}
