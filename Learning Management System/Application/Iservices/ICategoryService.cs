using Learning_Management_System.Application.DTOs.CategoryDTO;

namespace Learning_Management_System.Application.Iservices
{
    public interface ICategoryService
    {
        Task<CategoryResponseDto> CreateAsync(AddToCatogeryDto categoryDto);
        Task<CategoryResponseDto> UpdateAsync( long id, UpdatCategoryDto categoryDto);
        Task DeleteAsync(long id);
        Task<CategoryResponseDto> GetByIdAsync(long id);
        Task<CategoryResponseDto> GetByNameAsync(string Name );
        Task<IEnumerable<CategoryResponseDto>>GetAllAsync();

    }
}
