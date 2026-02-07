using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Persistence;

namespace Learning_Management_System.Infrastructure.Repositories
{
    public class QuestionRepository:IQuestionRepository
    {
        App_Context context;

        public QuestionRepository(App_Context _context)
        {
            context = _context;
        }
        public async Task Add(Question questions)
        {
            context.qustions.Add(questions);
        }

        public void Update(Question question)
        {
            context.qustions.Update(question);
        }
        public void Delete(Question question)
        {
            
                context.qustions.Remove(question);
           

        }

        public async Task <Question> GetQuestion (long id)
        {
            return context.qustions.FirstOrDefault(x => x.Id == id);
        }

        public async Task Save()
        {
            context.SaveChanges();
        }

        public async Task <IEnumerable<Question>> GetQuestions()
        {
            return context.qustions.ToList();
        }
    }
}
