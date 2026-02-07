using FluentValidation;
using Learning_Management_System.Application.DTOs.SubmissionDTO;

namespace Learning_Management_System.Application.Validators.SubmissionValidatord
{
    public class UpdateSubmissionDtoValidator: AbstractValidator<UpdateSubmissionDto>

    {
        public UpdateSubmissionDtoValidator() 
        {
            When(x => x.Score != null, () =>
            {
                RuleFor(x => x.Score).ExclusiveBetween(0,100);
            });

        }
    }
}
