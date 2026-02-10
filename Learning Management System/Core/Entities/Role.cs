using Microsoft.AspNetCore.Identity;
using System;

namespace Learning_Management_System.Core.Entities
{
    public class Role: IdentityRole<long>
    {
        public const string Admin = "Admin";
        public const string Instructor = "Instructor";
        public const string Student = "Student";
    }
}
