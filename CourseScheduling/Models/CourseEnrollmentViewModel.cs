namespace CourseScheduling.Models
{
    public class CourseEnrollmentViewModel
    {
        public List<Course> AvailableCourses { get; set; }
        public List<Enrollment> EnrolledCourses { get; set; }


        public string SearchCourseName { get; set; }
        public string SearchCourseCode { get; set; }
    }

}
