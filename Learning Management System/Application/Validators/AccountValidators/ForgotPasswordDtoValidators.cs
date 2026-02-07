using FluentValidation;
using Learning_Management_System.Application.DTOs.AccountDTO;

namespace Learning_Management_System.Application.Validators.AccountValidators
{
    public class ForgotPasswordDtoValidators: AbstractValidator<ForgotPasswordDto>
    {
        public ForgotPasswordDtoValidators()
        {
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
        }
    }
}
