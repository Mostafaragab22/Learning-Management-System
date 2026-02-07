using FluentValidation;
using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.DTOs.CourseDTO;

namespace Learning_Management_System.Application.Validators.CategoryValidators
{
    public class CreateCategoryDtoValidators: AbstractValidator<AddToCatogeryDto>
    {
        public CreateCategoryDtoValidators() 
        {
            RuleFor(x => x.Title).NotEmpty().MinimumLength(3);
          
            ;


        }

    }
   
}
