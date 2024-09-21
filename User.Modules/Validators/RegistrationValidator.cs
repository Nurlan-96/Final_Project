using FluentValidation;
using User.Module.Commands;

namespace User.Module.Validators
{
    public class RegistrationValidator: AbstractValidator<RegisterCommand>
    {
        public RegistrationValidator()
        {
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email can't be empty")
               .EmailAddress().WithMessage("Not a valid email address");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password can't be empty")
                .MinimumLength(8).WithMessage("Password can't have fewer than 8 characters")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter");
            RuleFor(x => x.ConfirmPassword).Matches(x => x.Password).WithMessage("Passwords doesn't match");
            RuleFor(x=>x.Phone).NotEmpty().WithMessage("Phone can't be empty")
                .MinimumLength(10).WithMessage("Phone number can't have fewer than 10 characters")
                .Matches(@"^\d+$").WithMessage("Phone number must contain only numbers.");
            RuleFor(x=>x.Fullname).NotEmpty().WithMessage("Name can't be empty")
            .Matches(@"^[a-zA-Z]+\s[a-zA-Z]+$").WithMessage("Password must contain only letters with a space in the middle.");

        }
    }
}
