using FluentValidation;
using Learning_Management_System.Application.DTOs.LessonDTO;
using Learning_Management_System.Application.DTOs.QuestionsDTO;

namespace Learning_Management_System.Application.Validators.QuestionValidators
{
    public class UpdateQuestionsDtoValidator: AbstractValidator<UpdateQuestionsDto>
    {
        public UpdateQuestionsDtoValidator() 
        {
            When(x => x.Text != null, () =>
            {
                RuleFor(x => x.Text).MinimumLength(3).MinimumLength(50);
            });

        }
    }
}
