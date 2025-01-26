using bookApi.Application.Dtos.Request;
using FluentValidation;

namespace bookApi.Validators
{
    public class UpdatePasswordValidator : AbstractValidator<UpdatePasswordDto>
    {

        public UpdatePasswordValidator()
        {
            RuleFor(u => u.NewPassword)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter.")
                .Matches(@"[0-9]").WithMessage("Password must contain at least one digit.")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character.");

            RuleFor(u => u.ConfirmNewPassword)
                .NotEmpty().WithMessage("You must provide a password.")
                .Equal(u => u.NewPassword).WithMessage("Passwords do not match");
        }
    }
}
