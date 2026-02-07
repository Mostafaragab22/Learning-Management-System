using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Learning_Management_System.Infrastructure.Repositories
{
    public class CategoryRepository:ICategoryRepository
    {
        App_Context context;
        public CategoryRepository(App_Context _context)
        {
            context = _context;
        }
        public async Task Add(Category category)
        {

            context.categories.Add(category);
        }
        public void Update(Category category)
        {
            context.categories.Update(category);
        }
        public void Delete(Category category)
        {
           
             context.categories.Remove(category);
            
        }
        public async Task<Category> GetById(long id)
        {
            return context.categories
                .Include(x => x.Courses)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return context.categories.Include(x => x.Courses);
        }

        public async Task<Category> GetByName(string Name)
        {
            return context.categories
                .Include(x => x.Courses)
                .FirstOrDefault(x => x.Title == Name);
        }

        public async Task Save()
        {
            context.SaveChanges();
        }
    }
}
