using Learning_Management_System.Application.DTOs.LessonDTO;
using Learning_Management_System.Application.DTOs.QuizDTO;

namespace Learning_Management_System.Application.Iservices
{
    public interface IQuizService
    {
        Task<QuizResponseDto> CreateAsync(CreateQuizDto quizDto);
        Task<QuizResponseDto> UpdateAsync(long id, UpdateQuizDto quizDto);
        Task DeleteAsync(long id);
        Task<QuizResponseDto> GetByIdAsync(long id);
        Task<QuizResponseDto> GetByNameAsync(string Name);
        Task<IEnumerable<QuizResponseDto>> GetAllAsync();
    }
}
