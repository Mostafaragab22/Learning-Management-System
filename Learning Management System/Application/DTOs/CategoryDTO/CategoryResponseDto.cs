using Learning_Management_System.Application.DTOs.CourseDTO;
using Learning_Management_System.Core.Entities;

namespace Learning_Management_System.Application.DTOs.CategoryDTO
{
    public class CategoryResponseDto
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<CoursesResponseDto> Courses { get; set; }
    }
}
