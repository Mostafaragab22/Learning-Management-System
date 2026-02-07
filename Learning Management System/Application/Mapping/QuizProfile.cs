using AutoMapper;
using Learning_Management_System.Application.DTOs.QuizDTO;
using Learning_Management_System.Application.Validators.CourseValidators;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Mapping
{
    public class QuizProfile:Profile
    {
        public QuizProfile() 
        {
            CreateMap<CreateQuizDto, Quiz>()
                .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateQuizDto, Quiz>()
                .ForAllMembers(opt=> opt.Condition(
                    (src, dest,srcMember) =>srcMember !=  null));
            CreateMap<Quiz, QuizResponseDto>()
                .ForMember(dest => dest.LessonName,
                opt => opt.MapFrom(src => src.Lesson.Title))
                .ForMember(dest => dest.CourseName,
                opt => opt.MapFrom(src => src.Course.CourseName));
        }
    }
}
