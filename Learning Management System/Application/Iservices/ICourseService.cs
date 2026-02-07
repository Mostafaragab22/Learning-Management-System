using Learning_Management_System.Application.DTOs.CategoryDTO;
using Learning_Management_System.Application.DTOs.CourseDTO;

namespace Learning_Management_System.Application.Iservices
{
    public interface ICourseService
    {
        Task<CoursesResponseDto> CreateAsync(CreateCourseDto courseDto);
        Task<CoursesResponseDto> UpdateAsync(long id, UpdateCourseDto courseDto);
        Task DeleteAsync(long id);
        Task<CoursesResponseDto> GetByIdAsync(long id);
        Task<CoursesResponseDto> GetByNameAsync(string Name);
        Task<IEnumerable<CoursesResponseDto>> GetAllAsync();
    }
}
