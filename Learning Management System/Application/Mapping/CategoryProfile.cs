using AutoMapper;
using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.DTOs.CourseDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Mapping
{
    public class CategoryProfile:Profile
    {
        public CategoryProfile()
        {
            CreateMap<AddToCatogeryDto, Category>();

            CreateMap<UpdatCategoryDto, Category>()
                .ReverseMap()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<Category, CategoryResponseDto>();
                


                
        }

    }
}
