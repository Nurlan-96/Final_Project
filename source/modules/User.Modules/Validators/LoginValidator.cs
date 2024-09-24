using FluentValidation;
using User.Module.Commands;

namespace User.Module.Validators
{
    public class LoginValidator:AbstractValidator<LoginCommand>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can't be empty")
                .EmailAddress().WithMessage("Not a valid email address");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty")
                .MinimumLength(8).WithMessage("Password can't have fewer than 8 characters")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter");
        }
    }
}
