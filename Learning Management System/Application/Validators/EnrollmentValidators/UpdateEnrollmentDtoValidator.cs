using FluentValidation;

using Learning_Management_System.Application.DTOs.EnrollmentDTO;

namespace Learning_Management_System.Application.Validators.EnrollmentValidators
{
    public class UpdateEnrollmentDtoValidator : AbstractValidator<UpdateEnrollmentDto>
    {
        public UpdateEnrollmentDtoValidator() 
        {
            When(x => x.CourseId.HasValue, () =>
            {
                RuleFor(x => x.CourseId).GreaterThan(0);
            });

            When(x => x.Status.HasValue, () =>
            {
                RuleFor(x => x.Status).IsInEnum();
            });



        }


    
    }
}
