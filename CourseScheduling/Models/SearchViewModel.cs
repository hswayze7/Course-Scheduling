namespace CourseScheduling.Models
{
    public class SearchViewModel
    {
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public List<Course> Results { get; set; }
    }
}
