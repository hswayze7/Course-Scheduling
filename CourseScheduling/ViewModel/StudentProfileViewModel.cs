using CourseScheduling.Models;
using CourseScheduling.ViewModel;

namespace CourseScheduling.ViewModel
{
    public class StudentProfileViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Major { get; set; }
        public string Year { get; set; }
        public List<CourseViewModel> EnrolledCourses { get; set; }
    }

    public class CourseViewModel
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string Professor { get; set; }
        public string Time { get; set; }
    }
}
