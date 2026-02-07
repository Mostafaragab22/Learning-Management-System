using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Learning_Management_System.Infrastructure.Repositories
{
    public class LessonRepository:ILessonRepository
    {
        App_Context context;

        public LessonRepository(App_Context _context)
        {
            context = _context;
        }
        public async Task Add(Lessons lesson)
        {
            context.lessons.Add(lesson);
        }
        public void Update(Lessons lesson)
        {
            context.lessons.Update(lesson);
          
        }
        public void Delete(Lessons lesson)
        {
           
                context.lessons.Remove(lesson);
        }
        public async Task <Lessons> GetById(long id)
        {
            return context.lessons.Include(x => x.Course )
                .Include(x => x.CourseName )
                .FirstOrDefault(x => x.Id == id);
        }
        public async Task<Lessons> GetByTitle(string Name)
        {
            return context.lessons.Include(x => x.Course)
                .Include(x => x.CourseName)
                .FirstOrDefault(x => x.Title == Name);
        }
        public async Task<IEnumerable<Lessons>> Getlessons()
        {
            return context.lessons.Include(x => x.Course);
        }

        public async Task Save()
        {
            context.SaveChanges();
        }
    }
}
