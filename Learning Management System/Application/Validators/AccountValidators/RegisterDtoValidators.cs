using FluentValidation;
using Learning_Management_System.Application.DTOs.AccountDTO;

namespace Learning_Management_System.Application.Validators.AccountValidators
{
    public class RegisterDtoValidators : AbstractValidator<RegisterDto>
    {
        public RegisterDtoValidators()
        {
            RuleFor(x => x.FullName).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Age).InclusiveBetween(9,100);
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8)
                .Matches(@"[A-Z]").WithMessage("Must contain uppercase letter")
                .Matches(@"[a-z]").WithMessage("Must contain Lowercase letter")
                .Matches(@"[0-9]").WithMessage("Must contain number")
                .Matches(@"[@#$%^&*!]").WithMessage("Must contain Special Code");
            RuleFor(x => x.Phone).Matches(@"^\+?[0-9]{10-12}$");
                
                
                
            


        }
    }
}
