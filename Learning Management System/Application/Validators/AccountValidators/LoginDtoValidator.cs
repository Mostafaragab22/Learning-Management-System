using FluentValidation;
using Learning_Management_System.Application.DTOs.AccountDTO;

namespace Learning_Management_System.Application.Validators.AccountValidators
{
    public class LoginDtoValidator : AbstractValidator<LoginDto>
    {
        public LoginDtoValidator()
        { 
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty();
                


        }
    }
}
