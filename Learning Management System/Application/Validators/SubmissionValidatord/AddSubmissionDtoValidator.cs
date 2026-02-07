using FluentValidation;
using Learning_Management_System.Application.DTOs.SubmissionDTO;

namespace Learning_Management_System.Application.Validators.SubmissionValidatord
{
    public class AddSubmissionDtoValidator: AbstractValidator<AddSubmissionDto>
    {
        public AddSubmissionDtoValidator() 
        {
            
            RuleFor(x => x.StudentId).NotNull().GreaterThan(0);
            RuleFor(x => x.QuizId).NotNull().GreaterThan(0);

        }
    }
}
