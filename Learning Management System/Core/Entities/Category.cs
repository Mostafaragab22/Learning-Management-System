namespace Learning_Management_System.Core.Entities
{
    public class Category
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public List<Course> Courses { get; set; }

    }
}
