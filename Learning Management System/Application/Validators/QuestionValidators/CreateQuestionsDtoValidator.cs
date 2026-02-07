using FluentValidation;
using Learning_Management_System.Application.DTOs.LessonDTO;
using Learning_Management_System.Application.DTOs.QuestionsDTO;

namespace Learning_Management_System.Application.Validators.QuestionValidators
{
    public class CreateQuestionsDtoValidator: AbstractValidator<CreateQuestionsDto>
    {

        public CreateQuestionsDtoValidator() 
        {

            RuleFor(x => x.Text).NotEmpty().MinimumLength(3).MaximumLength(50);;
            RuleFor(x => x.QuizId).NotNull().GreaterThan(0);
        }
    }
}
