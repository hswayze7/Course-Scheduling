﻿namespace CourseScheduling.Models
{
    public class StudentCourse
    {
        public int StudentCourseId { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime RegisteredAt { get; set; }
    }
}
