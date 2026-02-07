using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Learning_Management_System.Infrastructure.Repositories
{
    public class QuizRepository:IQuizRepository
    {
        App_Context context;

        public QuizRepository(App_Context _context)
        {
            context = _context;
        }

        public async Task Add(Quiz quiz)
        {
            context.quizzes.Add(quiz);
        }
        public void Update(Quiz quiz)
        {
            context.quizzes.Update(quiz);
        }

        
        public void Delete(Quiz quiz)
        { 
           context.quizzes.Remove(quiz);
        }

      

        public async Task <Quiz> GetById(long id)
        {
            return context.quizzes.Include(x => x.questions)
                .Include(x => x.Lesson)       
                .Include(x => x.Course)       
                .FirstOrDefault(x => x.Id == id);
        }
        public async Task <Quiz> GetByName(string Name)
        {
            return context.quizzes.Include(x => x.questions)
                .Include(x => x.Lesson)       
                .Include(x => x.Course)       
                .FirstOrDefault(x => x.Title == Name);
        }
        public async Task<IEnumerable<Quiz>> GetAll()
        {
            return context.quizzes.Include(x => x.questions)
                .Include(x => x.Lesson)
                .Include(x => x.Course);
        }
        public async Task Save()
        {
            context.SaveChanges();
        }
    }
}
