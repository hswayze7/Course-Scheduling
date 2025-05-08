using System.Security;

namespace CourseScheduling.Models
{
    //Enrollment table for the database
    public class Enrollment
    {
        public int EnrollmentId { get; set; }  // Primary key

        public int StudentId { get; set; }  // Foreign key to the Student
        public Student Student { get; set; }  // Navigation property

        public int CourseId { get; set; }  // Foreign key to the Course
        public Course Course { get; set; }  // Navigation property

        public string? CourseCode { get; set; }

        public DateTime EnrollmentDate { get; set; }  

        public string? Grade { get; set; }
    }
}
