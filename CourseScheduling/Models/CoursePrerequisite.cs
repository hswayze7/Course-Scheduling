namespace CourseScheduling.Models
{
    public class CoursePrerequisite
    {
        public int CoursePrerequisiteId { get; set; }  // Primary key
        public int CourseId { get; set; }              // The course that has a prerequisite
        public int PrerequisiteCourseId { get; set; }  // The course that must be completed first

        public Course Course { get; set; }
        public Course PrerequisiteCourse { get; set; }
    }

}
