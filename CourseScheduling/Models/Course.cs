﻿using System.ComponentModel.DataAnnotations;

namespace CourseScheduling.Models
{
    //Course table entity for database
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credits { get; set; }
        public string Time { get; set; }

        public string Professor { get; set; }


        public int MaxCapacity { get; set; }
        public int CurrentEnrollment {  get; set; }


        public ICollection<Waitlist> Waitlists { get; set; }
        
       


        public ICollection<Enrollment> Enrollments { get; set; }
        public string Description { get;  set; }
    }
}
