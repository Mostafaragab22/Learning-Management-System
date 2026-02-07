using AutoMapper;
using Learning_Management_System.Application.DTOs.CourseDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Mapping
{
    public class CourseProfile:Profile

    {
        public CourseProfile()
        {
            CreateMap<CreateCourseDto, Course>()
                .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow)
                );

            CreateMap<UpdateCourseDto, Course>()
            .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));


            CreateMap<Course, CoursesResponseDto>()
                .ForMember(dest => dest.InstructorName,
                opt => opt.MapFrom(src => src.Instructor.FullName)
                );

        }
    }
}
