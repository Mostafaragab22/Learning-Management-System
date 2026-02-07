using FluentValidation;
using Learning_Management_System.Application.DTOs.QuizDTO;

namespace Learning_Management_System.Application.Validators.QuizValidators
{
    public class CreateQuizDtoValidator : AbstractValidator<CreateQuizDto>
    {
        public CreateQuizDtoValidator() 
        {

            RuleFor(x => x.Title).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.CourseName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.LessonName).NotEmpty().MinimumLength(3).MaximumLength(50);
            RuleFor(x => x.CourseId).NotNull().GreaterThan(0);
            RuleFor(x => x.LessonId).NotNull().GreaterThan(0);

        }
    }
}
