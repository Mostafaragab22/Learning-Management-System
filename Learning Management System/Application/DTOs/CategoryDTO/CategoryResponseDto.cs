using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.DTOs.CategoryDTO
{
    public class CategoryResponseDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<Course> Courses { get; set; }
    }
}
