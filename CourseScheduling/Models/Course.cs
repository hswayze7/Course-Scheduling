﻿using System.ComponentModel.DataAnnotations;

namespace CourseScheduling.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string Time { get; set; }

        
       


        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
