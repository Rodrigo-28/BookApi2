using bookApi.Application.Dtos.Request;
using FluentValidation;

namespace bookApi.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>

    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Name is required");
            RuleFor(u => u.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");
            RuleFor(u => u.Password)
          .NotEmpty().WithMessage("Password is required.")
          .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
          .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
          .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
          .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
          .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");
            RuleFor(x => x.RoleId).NotNull().WithMessage("Role is required");
        }
    }
}
