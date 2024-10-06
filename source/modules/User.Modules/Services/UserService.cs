using CryptoHelper;
using Domain.Exceptions;
using FinalProject.Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using Identity.Module.Response;
using IdentityModule.Queries;
using User.Module.Commands;
using UserModule.Commands;
using Identity.Module.Auth;
using System.Security.Authentication;
using SharedKernel.Domain;
using EmailModule.Manager;
using System.Runtime;
using UserModule.Managers;
using FinalProject.SharedKernel.Domain.Settings;
using Microsoft.Extensions.Options;

namespace User.Module.Services
{
    public class UserService(IUserManager userManager,IUserRepository userRepository, IUserQueries userQuery, IEmailManager emailManager, IOptions<JWTSettings> settings) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserQueries _userQueries = userQuery;
        private readonly IUserManager _userManager = userManager;
        private readonly IEmailManager _emailManager = emailManager;
        private readonly JWTSettings _settings = settings.Value;

        private static string GenerateOTP()
        {
            Random random = new();
            const string chars = "0123456789";

            return new string(Enumerable.Repeat(chars, 6)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public async Task<bool> ChangePassword(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            if (request.NewPassword != request.ConfirmPassword)
                throw new PasswordMismatchException();

            UserEntity self = await _userManager.GetCurrentUser();

            if (!Crypto.VerifyHashedPassword(self.PasswordHash, request.OldPassword))
                throw new UnauthorizedException("Incorrect Password");

            self.ChangePassword(Crypto.HashPassword(request.NewPassword));
            self.UpdateRefreshToken(null); //Logs user out on every platform.
            _userRepository.Update(self);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ConfirmOTP(ConfirmOTPCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueries.FindAsync(request.Email);
            if (user.OTPCode != request.OTP)
                throw new UnauthorizedException("Invalid OTP Code.");

            user.AllowPasswordChangeWithOTP();
            _userRepository.Update(user);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ForgotPassword(ForgotPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueries
            .FindAsync(request.Email) ?? throw new EntityNotFoundException<UserEntity>();

            if (user.AllowChangeWithOTP != true)
                throw new UnauthorizedAccessException("You don't have access to change password of this user.");

            if (user.OTPExpirationDate > DateTime.UtcNow.AddMinutes(5))
                throw new OTPExpiredException();

            user.ChangePassword(Crypto.HashPassword(request.Password));
            user.NullifyOTP();

            _userRepository.Update(user);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<bool> ForgotPasswordSendOTP(ForgotPasswordSendOTPCommand request, CancellationToken cancellationToken)
        {
            var user = await _userQueries.FindAsync(request.Email)
       ?? throw new EntityNotFoundException<UserEntity>();
            string otp = GenerateOTP();

            Dictionary<string, string> replacements = new()
            {
                { "OTP", otp }
            };

            Email mail = new()
            {
                To = request.Email,
                Subject = "WeWork : You have requested a password reset.",
                Body = _emailManager.LoadHTML($@"{_emailManager.GetTemplatePath()}\OTP.html", replacements),
                IsHtml = true
            };

            await _emailManager.SendEmail(mail, cancellationToken);
            user.SetOTP(otp, DateTime.UtcNow.AddMinutes(5));
            _userRepository.Update(user);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<JWTResponse> RefreshToken(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var splitToken = request.Token.Split("_");

            var user = await _userQueries.FindByRefreshToken(refreshToken: request.Token)
                ?? throw new EntityNotFoundException<UserEntity>();

            if (Convert.ToDateTime(splitToken[2]) < DateTime.Now)
                throw new AuthenticationException("Token is expired.");

            (string token, DateTime expiresAt) = _userManager.GenerateJwtToken(user);

            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

            return new JWTResponse
            {
                Token = token,
                RefreshToken = request.Token,
                ExpiresAt = expiresAt
            };
        }

        public Task<bool> ResetPassword(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ValidateToken(ValidateTokenCommand request, CancellationToken cancellationToken)
        {
            var email = request.Email.ToLower();
            var user = await _userQueries.FindAsync(email)
                ?? throw new EntityNotFoundException<UserEntity>();

            var validateTokenUserId = TokenManager.ValidateToken(_settings, request.Token)
                ?? throw new AuthenticationException("Token is null");

            var formattedId = Guid.Parse(validateTokenUserId);

            if (!user.Id.Equals(formattedId))
            {
                throw new AuthenticationException("Token is invalid for this user");
            }

            return true;
        }
    }
}
