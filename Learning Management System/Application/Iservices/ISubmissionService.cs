using Learning_Management_System.Application.DTOs.QuestionsDTO;
using Learning_Management_System.Application.DTOs.SubmissionDTO;

namespace Learning_Management_System.Application.Iservices
{
    public interface ISubmissionService
    {
        Task<SubmissionResponseDto> CreateAsync(AddSubmissionDto dto);
        Task<SubmissionResponseDto> UpdateAsync(long id, UpdateSubmissionDto dto);
        Task DeleteAsync(long id);
        Task<SubmissionResponseDto> GetByIdAsync(long id);
        Task<SubmissionResponseDto> GetByNameAsync(string Name);
        Task<IEnumerable<SubmissionResponseDto>> GetAllAsync();

    }
}
