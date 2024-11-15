using CourseScheduling.Models;
using CourseScheduling.ViewModel;

namespace CourseScheduling.ViewModel
{
    public class SearchViewModel
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public List<Course> Results { get; set; }
    }
}
