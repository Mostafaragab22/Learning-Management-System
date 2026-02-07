using FluentValidation;
using Learning_Management_System.Application.DTOs.UserDTO;

namespace Learning_Management_System.Application.Validators.UserValidator
{
    public class UpdateUserProfileDtoValidator: AbstractValidator<UpdateUserProfileDto>
    {
        public UpdateUserProfileDtoValidator()
        {
            When(x => x.FullName != null, () =>
            {
                RuleFor(x => x.FullName).MaximumLength(100).MinimumLength(3);
            });
           
            When(x => x.Email != null, () =>
            {
                RuleFor(x => x.Email).EmailAddress();
            });
            When(x => x.phone != null, () =>
            {
                RuleFor(x => x.phone).Matches(@"^\+?[0-9]{10-12}$");
            });
            When(x => x.Age.HasValue, () =>
            {
                RuleFor(x => x.Age).ExclusiveBetween(9, 100);
            });

        }

    }
}
