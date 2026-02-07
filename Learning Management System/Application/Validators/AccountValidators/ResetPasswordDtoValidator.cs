using FluentValidation;
using Learning_Management_System.Application.DTOs.AccountDTO;

namespace Learning_Management_System.Application.Validators.AccountValidators
{
    public class ResetPasswordDtoValidator: AbstractValidator<ResetPasswordDto>
    {
        public ResetPasswordDtoValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Token).NotEmpty();
            RuleFor(x => x.NewPassword).NotEmpty().MinimumLength(8)
               .Matches(@"[A-Z]").WithMessage("Must contain uppercase letter")
               .Matches(@"[a-z]").WithMessage("Must contain Lowercase letter")
               .Matches(@"[0-9]").WithMessage("Must contain number")
               .Matches(@"[@#$%^&*!]").WithMessage("Must contain Special Code");
            RuleFor(x => x.ConfirmPassword).NotEmpty()
                .Equal(x => x.NewPassword);

        }
    }
}
