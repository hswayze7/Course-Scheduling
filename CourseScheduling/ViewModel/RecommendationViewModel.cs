using CourseScheduling.Models;

namespace CourseScheduling.ViewModel
{
    public class RecommendationViewModel
    {
        public string Major { get; set; }
        public List<Course> RecommendedCourses { get; set; }
    }
}