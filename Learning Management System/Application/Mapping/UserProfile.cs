using AutoMapper;
using Learning_Management_System.Application.DTOs.AccountDTO;
using Learning_Management_System.Application.DTOs.UserDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Mapping
{
    public class UserProfile:Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterDto, User>()
                .ForMember(dest => dest.FullName,
                opt => opt.MapFrom(src => src.FullName))
                .ForMember(dest => dest.UserName,
                opt => opt.MapFrom(src => src.Email))

                .ForMember(dest => dest.Email,
                opt => opt.MapFrom(src => src.Email))

                .ForMember(dest => dest.CreatedAt,
                opt => opt.MapFrom(_ => DateTime.UtcNow));

            CreateMap<User, UserResponseDto>();




        }
    }
}
