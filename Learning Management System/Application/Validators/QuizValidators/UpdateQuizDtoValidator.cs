using FluentValidation;
using Learning_Management_System.Application.DTOs.QuizDTO;

namespace Learning_Management_System.Application.Validators.QuizValidators
{
    public class UpdateQuizDtoValidator: AbstractValidator<UpdateQuizDto>
    {
        public UpdateQuizDtoValidator()
        {
            When(x => x.Title != null, () =>
            {
                RuleFor(x => x.Title).MinimumLength(3).MinimumLength(50);
            });
           
            When(x => x.LessonName != null, () =>
            {
                RuleFor(x => x.LessonName).MinimumLength(3).MinimumLength(50);
            });


            When(x => x.LessonId.HasValue, () =>
            {
                RuleFor(x => x.LessonId).GreaterThan(0);
            });


        }
    }
}
