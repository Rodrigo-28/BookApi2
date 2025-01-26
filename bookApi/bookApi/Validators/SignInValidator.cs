using bookApi.Application.Dtos.Request;
using FluentValidation;

namespace bookApi.Validators
{
    public class SignInValidator : AbstractValidator<SignInDto>
    {
        public SignInValidator()
        {
            RuleFor(u => u.Username)
       .NotEmpty().WithMessage("Username is required")
       .MinimumLength(6).WithMessage("Username must be at least 6 characters long")
       .MaximumLength(25).WithMessage("Username cannot be more than 25 characters long");


            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(u => u.Password1)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
            .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
            .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
            .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

            RuleFor(u => u.Password2)
                .NotEmpty().WithMessage("You must provide a password.")
                .Equal(u => u.Password1).WithMessage("Passwords do not match");
        }
    }
}
