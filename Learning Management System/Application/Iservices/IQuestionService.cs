using Learning_Management_System.Application.DTOs.QuestionsDTO;
using Learning_Management_System.Application.DTOs.QuizDTO;

namespace Learning_Management_System.Application.Iservices
{
    public interface IQuestionService
    {
        Task<QuestionsResponseDto> CreateAsync(CreateQuestionsDto questionsDto);
        Task<QuestionsResponseDto> UpdateAsync(long id, UpdateQuestionsDto questionsDto);
        Task DeleteAsync(long id);
        Task<QuestionsResponseDto> GetByIdAsync(long id);
        Task<IEnumerable<QuestionsResponseDto>> GetAllAsync();
    }
}
