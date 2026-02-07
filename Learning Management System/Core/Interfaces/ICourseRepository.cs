using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Core.Interfaces
{
    public interface ICourseRepository
    {
        Task Add(Course course);
        public void Update(Course course);
        public void Delete(Course course);
        Task <Course> GetById(long id);
        Task <Course> GetByName(string CourseName);
        Task <IEnumerable<Course>> GetCourses();
        Task Save();
    }
}
