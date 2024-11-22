using CourseScheduling.Models;
using CourseScheduling.ViewModel;

namespace CourseScheduling.ViewModel
{
    //Model to handle the course enrollment page and variables included
    public class CourseEnrollmentViewModel
    {
        public List<Course> AvailableCourses { get; set; }
        public List<Enrollment> EnrolledCourses { get; set; }
        public int TotalCredits => EnrolledCourses?.Sum(e => e.Course?.Credits ?? 0) ?? 0;  // Calculated from enrolled courses

        // Helper to determine if a course is already enrolled
        public HashSet<int> EnrolledCourseIds => EnrolledCourses.Select(e => e.CourseId).ToHashSet();

        public string SearchCourseName { get; set; }
        public string SearchCourseCode { get; set; }



    }

}
