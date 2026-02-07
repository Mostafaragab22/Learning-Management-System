using FluentValidation;
using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Validators.CategoryValidators
{
    public class UpdateCourseDtoValidators:AbstractValidator <UpdatCategoryDto>
    {
        public UpdateCourseDtoValidators()
        {
            When(x => x.Title != null, () =>
            {
                RuleFor(x => x.Title).MaximumLength(100).MinimumLength(3);
            });
          
            


        }
    }
}
