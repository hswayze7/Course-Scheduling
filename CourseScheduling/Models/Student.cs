namespace CourseScheduling.Models
{
    //Table for Student entity
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }  
        public string Major { get; set; }
        public string Year { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
