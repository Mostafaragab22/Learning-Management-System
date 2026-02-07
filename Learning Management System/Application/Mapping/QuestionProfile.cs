using AutoMapper;
using Learning_Management_System.Application.DTOs.QuestionsDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Mapping
{
    public class QuestionProfile:Profile
    {
        public QuestionProfile() 
        {
            CreateMap<CreateQuestionsDto, Question>()
                .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<UpdateQuestionsDto, Question>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Question, QuestionsResponseDto>();
                
        
        
        }
    }
}
