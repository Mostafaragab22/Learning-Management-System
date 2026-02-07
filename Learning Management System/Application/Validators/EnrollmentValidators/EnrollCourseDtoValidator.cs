using FluentValidation;
using Learning_Management_System.Application.DTOs.EnrollmentDTO;

namespace Learning_Management_System.Application.Validators.EnrollmentValidators
{
    public class EnrollCourseDtoValidator: AbstractValidator<EnrollCourseDto>
    {
        public EnrollCourseDtoValidator()
        {
            RuleFor(x => x.CourseId).NotNull().GreaterThan(0);
            RuleFor(x => x.StudentId).NotNull().GreaterThan(0);




        }
    }
}
