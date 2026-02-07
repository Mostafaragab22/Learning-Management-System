using Microsoft.AspNetCore.Identity;

namespace Learning_Management_System.Core.Enums
{
    public enum EnumRole
    {
        Instructor = 1,
        Student = 2,
        Admin = 3,

    }

    public enum EnrollmentStatus
    {
        Active = 1,
        Completed = 2,
        Cancelles = 3,
        Pending = 4,

    }

}
