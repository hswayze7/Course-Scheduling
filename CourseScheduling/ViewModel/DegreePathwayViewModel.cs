namespace CourseScheduling.ViewModel
{
    public class DegreePathwayViewModel
    {
        public string MajorName { get; set; }
        public List<DegreeCourseStatus> Courses { get; set; }



    }

    public class DegreeCourseStatus
    {
        public string CourseCode { get; set; }
        public string Status { get; set; } //Completed, In Progress, Not taken

        public string CourseName { get; set; }
    }
}
