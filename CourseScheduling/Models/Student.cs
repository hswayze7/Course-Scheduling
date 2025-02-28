using System.ComponentModel.DataAnnotations;

namespace CourseScheduling.Models
{
    //Table for Student entity
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Major { get; set; }
        [Required]
        public string Year { get; set; }


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
