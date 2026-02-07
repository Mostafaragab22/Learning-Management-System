using FluentValidation;
using Learning_Management_System.Application.DTOs.CourseDTO;

namespace Learning_Management_System.Application.Validators.CourseValidators
{
    public class UpdateCourseDtoValidators: AbstractValidator<UpdateCourseDto>
    {
        public UpdateCourseDtoValidators()
        {
            When(x => x.CourseName != null, () =>
            {
                RuleFor(x => x.CourseName).MinimumLength(3).MinimumLength(50);
            });
            When(x => x.Price.HasValue, () =>
            {
                RuleFor(x => x.Price).GreaterThan(0);
            });
            When(x => x.InstructorId.HasValue, () =>
            {
                RuleFor(x => x.InstructorId).GreaterThan(0);
            });
            When(x => x.InstructorName != null, () =>
            {
                RuleFor(x => x.InstructorName).MinimumLength(3).WithMessage("لايمكن ان يكون اقل من 3 حروف")
                .MinimumLength(50)
                .WithMessage("لايمكن ان يكون اكبر من 50 حرف");
            });

            When(x => x.CategoryId.HasValue, () =>
            {
                RuleFor(x => x.CategoryId).GreaterThan(0);
            });
            When(x => x.CategoryName != null, () =>
            {
                RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("لايمكن ان يكون اقل من 3 حروف")
                .MinimumLength(50)
                .WithMessage("لايمكن ان يكون اكبر من 50 حرف");
            });

        }
    }
}
