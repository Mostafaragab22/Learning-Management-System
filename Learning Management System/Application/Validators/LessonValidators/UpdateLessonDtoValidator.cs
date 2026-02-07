using FluentValidation;
using Learning_Management_System.Application.DTOs.CourseDTO;
using Learning_Management_System.Application.DTOs.LessonDTO;

namespace Learning_Management_System.Application.Validators.LessonValidators
{
    public class UpdateLessonDtoValidator: AbstractValidator<UpdateLessonDto>
    {
        public UpdateLessonDtoValidator() 
        {

            When(x => x.Title != null, () =>
            {
                RuleFor(x => x.Title).MinimumLength(3).MinimumLength(50);
            });
            
            When(x => x.CourseId.HasValue, () =>
            {
                RuleFor(x => x.CourseId).GreaterThan(0);
            });

            When(x => x.CourseName != null, () =>
            {
                RuleFor(x => x.CourseName).MinimumLength(3).MinimumLength(50);
            });   

        }
    }
}
