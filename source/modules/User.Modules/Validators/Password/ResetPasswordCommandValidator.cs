using FluentValidation;
using UserModule.Commands;

namespace User.Module.Validators.Password
{
    public class ResetPasswordCommandValidator : AbstractValidator<ResetPasswordCommand>
    {
        public ResetPasswordCommandValidator() : base()
        {
            RuleFor(command => command.Password).NotNull().MinimumLength(8)
                    .Must(password => password.Any(ch => !char.IsLetterOrDigit(ch)))
                .WithMessage("Password must contain at least one special character.");

            RuleFor(command => command.ConfirmPassword).Equal(m => m.Password)
                .WithMessage("Confirm password must be equal to password!");
        }
    }
}