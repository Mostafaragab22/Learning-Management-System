using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task Add(Category category);
        void Update(Category category);
        void Delete(Category category);
        Task <Category?> GetById(long id);
        Task <Category?> GetByName(String Title);
         Task<IEnumerable<Category>> GetAll();
        Task  Save();
    }
}
