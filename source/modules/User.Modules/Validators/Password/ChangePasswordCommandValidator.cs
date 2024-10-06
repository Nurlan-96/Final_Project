using FluentValidation;
using UserModule.Commands;

namespace User.Module.Validators.Password
{
    public class ChangePasswordCommandValidator : AbstractValidator<ChangePasswordCommand>
    {
        public ChangePasswordCommandValidator() : base()
        {
            RuleFor(command => command.OldPassword).NotEmpty().NotNull();

            RuleFor(command => command.NewPassword).NotNull().NotEmpty().MinimumLength(8)
                    .Must(password => password.Any(char.IsUpper))
                .WithMessage("Password must contain at least one uppercase letter.")
                    .Must(password => password.Any(ch => !char.IsLetterOrDigit(ch)))
                .WithMessage("Password must contain at least one special character.");

            RuleFor(command => command.ConfirmPassword).Equal(m => m.NewPassword)
                 .WithMessage("Password must be equal to confirm password!");
        }
    }
}