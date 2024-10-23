namespace CourseScheduling.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  // We'll store hashed passwords later
        public string Major { get; set; }
        public string Year { get; set; }
    }
}
