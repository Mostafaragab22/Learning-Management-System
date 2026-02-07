using AutoMapper;
using Learning_Management_System.Application.DTOs.EnrollmentDTO;
using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Enums;

namespace Learning_Management_System.Application.Mapping
{
    public class EnrollmentProfile:Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<EnrollCourseDto, Enrollment>()
                .ForMember(dest => dest.EnrolledAt,
                opt => opt.MapFrom(_=>DateTime.UtcNow))
                .ForMember(dest => dest.Status,
                opt => opt.MapFrom(_ => EnrollmentStatus.Pending));

            CreateMap<UpdateEnrollmentDto, Enrollment>()
                .ForAllMembers(dest => dest.Condition((src, dest, srcMember) => srcMember != null));

            CreateMap<Enrollment,EnrollmentResponseDto>()
                .ForMember(dest => dest.StudentName,
                opt => opt.MapFrom(src => src.Student.FullName))
            .ForMember(dest => dest.CourseName,
                opt => opt.MapFrom(src => src.Course.CourseName));



        }
    }
}
