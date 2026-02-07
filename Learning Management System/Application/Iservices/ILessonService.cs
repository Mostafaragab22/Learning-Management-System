using Learning_Management_System.Application.DTOs.EnrollmentDTO;
using Learning_Management_System.Application.DTOs.LessonDTO;

namespace Learning_Management_System.Application.Iservices
{
    public interface ILessonService
    {
        Task<LessonResponseDto> CreateAsync(AddLessonDto lessonDto);
        Task<LessonResponseDto> UpdateAsync(long id, UpdateLessonDto lessonDto);
        Task DeleteAsync(long id);
        Task<LessonResponseDto> GetByIdAsync(long id);
        Task<LessonResponseDto> GetByNameAsync(string Name);
        Task<IEnumerable<LessonResponseDto>> GetAllAsync();
    }
}
