using FluentValidation;
using Learning_Management_System.Application.DTOs.CourseDTO;

namespace Learning_Management_System.Application.Validators.CourseValidators
{
    public class CrateCourseDtoValidators: AbstractValidator<CreateCourseDto>
    {
        public CrateCourseDtoValidators()
        {
            RuleFor(x => x.CourseName).NotEmpty().MinimumLength(3).MaximumLength(50) ;
            RuleFor(x => x.Price).NotNull().GreaterThan(0);
            RuleFor(x => x.InstructorId).NotNull().GreaterThan(0);
            RuleFor(x => x.CategoryId).NotNull().GreaterThan(0);
            RuleFor(x => x.InstructorName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.CategoryName).NotEmpty().MinimumLength(3).MaximumLength(50);


        }
    }
}
