using Learning_Management_System.Core.Entities;
using Learning_Management_System.Core.Interfaces;
using Learning_Management_System.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Learning_Management_System.Infrastructure.Repositories
{
    public class CourseRepository:ICourseRepository
    {
        App_Context context;
        public CourseRepository(App_Context _context)
        {
            context = _context;
        }
        public async Task Add(Course course)
        {
            context.courses.Add(course);
        }
        public void Update(Course course)
        {
            context.courses.Update(course);
        }
        public void Delete(Course course)
        {
            
                context.courses.Remove(course);
        }
        public async Task <Course> GetById(long id)
        {
            return context.courses
                .Include(x => x.lessons)
                .FirstOrDefault(x => x.Id == id);
        }

        public async Task<IEnumerable<Course>> GetCourses()
        {
            return context.courses.Include(x => x.lessons)
                .Include(x =>x.Instructor);
        }

        public async Task<Course> GetByName(string Name)
        {
            return context.courses
                .Include(x => x.lessons)
                .FirstOrDefault(x => x.CourseName == Name);
        }

        public async Task Save()
        {
            context.SaveChanges();
        }
    }
}

