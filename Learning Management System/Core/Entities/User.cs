using Learning_Management_System.Core.Enums;
using Microsoft.AspNetCore.Identity;

namespace Learning_Management_System.Core.Entities
{
    public class User:IdentityUser<long>
    {
       
        public string FullName { get; set; }
        public decimal age { get; set; }
      
        public EnumRole Role { get; set; } = EnumRole.Student;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public ICollection <Enrollment> enrollments { get; set; }
        public ICollection <Course> courses { get; set; }

    }
}
