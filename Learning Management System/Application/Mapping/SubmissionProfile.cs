using AutoMapper;
using Learning_Management_System.Application.DTOs.SubmissionDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Mapping
{
    public class SubmissionProfile:Profile
    {
        public SubmissionProfile()
        {
            CreateMap<AddSubmissionDto, Submission>()
                .ForMember(dest=> dest.SubmittedAt,
                opt => opt.MapFrom(_=>DateTime.Now));

            CreateMap<UpdateSubmissionDto, Submission>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
            CreateMap<Submission, SubmissionResponseDto>()
                .ForMember(dest => dest.StudentName,
                opt => opt.MapFrom(src => src.Student.FullName)).

                ForMember(dest => dest.QuizTitle,
                opt => opt.MapFrom(src => src.quiz.Title));


        }
    }
}
