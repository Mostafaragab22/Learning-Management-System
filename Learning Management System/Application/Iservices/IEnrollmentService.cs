using Learning_Management_System.Application.DTOs.CourseDTO;
using Learning_Management_System.Application.DTOs.EnrollmentDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.Iservices
{
    public interface IEnrollmentService
    {
        Task<EnrollmentResponseDto> CreateAsync(EnrollCourseDto enrollmentDto);
        Task<EnrollmentResponseDto> UpdateAsync(long id, UpdateEnrollmentDto enrollmentDto);
        Task DeleteAsync(long id);
        Task<EnrollmentResponseDto> GetByIdAsync(long id);
        Task<EnrollmentResponseDto> GetBystudentIdAsync(long studentId);
        Task<IEnumerable<EnrollmentResponseDto>> GetAllAsync();
    }
}
