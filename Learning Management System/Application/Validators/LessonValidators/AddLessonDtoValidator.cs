using FluentValidation;
using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.DTOs.LessonDTO;

namespace Learning_Management_System.Application.Validators.LessonValidators
{
    public class AddLessonDtoValidator: AbstractValidator<AddLessonDto>
    {
        public AddLessonDtoValidator() 
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.CourseName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.ContentUrl).NotEmpty(); 
            RuleFor(x => x.CourseId).NotNull().GreaterThan(0);


        }
    }
}
