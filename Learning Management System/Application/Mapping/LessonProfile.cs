using AutoMapper;
using Learning_Management_System.Application.DTOs.LessonDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Mapping
{
    public class LessonProfile :Profile
    {
        public LessonProfile()
        {
            CreateMap<AddLessonDto, Lessons>()
                .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateLessonDto, Lessons>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Lessons, LessonResponseDto>()

                .ForMember(dest => dest.CourseName,
                opt => opt.MapFrom(src => src.Course.CourseName));

        }


    }
}
