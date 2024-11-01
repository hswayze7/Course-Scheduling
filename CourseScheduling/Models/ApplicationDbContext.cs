namespace CourseScheduling.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }

        public DbSet<Enrollment> Enrollments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseCode = "CS101", CourseName = "Introduction to Computer Science", Credits = 3, Time = "M/W/F 10:00 AM - 12:00 PM", Professor = "Prof1" },
                new Course { CourseId = 2, CourseCode = "MATH201", CourseName = "Calculus II", Credits = 4, Time = "T/TR 1:00 PM - 3:00 PM", Professor = "Prof2" },
                new Course { CourseId = 3, CourseCode = "CS400", CourseName = "Data Structures", Credits = 4, Time = "T/TR 2:15 PM - 3:30 PM", Professor = "Prof3" },
                new Course { CourseId = 4, CourseCode = "CS510", CourseName = "Programming Language Concepts", Credits = 3, Time = "T/TR 8:30 AM - 9:50 AM", Professor = "Prof13" },
                new Course { CourseId = 5, CourseCode = "MATH231", CourseName = "Discrete Math", Credits = 3, Time = "M/W/F 1:00 PM - 3:00 PM", Professor = "Prof4" },
                new Course { CourseId = 6, CourseCode = "PSY325", CourseName = "Developmental Psychology", Credits = 3, Time = "M/T/F 12:30 PM - 1:45 PM", Professor = "Prof5" },
                new Course { CourseId = 7, CourseCode = "SOC338", CourseName = "Health & Lifestyle", Credits = 3, Time = "M/W/F 2:15 PM - 3:30 PM", Professor = "Prof6" },
                new Course { CourseId = 8, CourseCode = "MKT690J", CourseName = "Social Media Marketing", Credits = 3, Time = "T/TR 9:30 AM - 10:45 AM", Professor = "Prof7" },
                new Course { CourseId = 9, CourseCode = "MGMT681", CourseName = "Strategic Management", Credits = 3, Time = "M/F/W 3:30 PM - 4:45 PM", Professor = "Prof8" },
                new Course { CourseId = 10, CourseCode = "NURS362", CourseName = "Clinical Care Lab", Credits = 1, Time = "F 1:00 PM - 4:00 PM", Professor = "Prof9" },
                new Course { CourseId = 11, CourseCode = "GEOG235", CourseName = "Meteorology", Credits = 3, Time = "M/W/F 2:15 PM - 3:30 PM", Professor = "Prof10" },
                new Course { CourseId = 12, CourseCode = "ENGR101", CourseName = "Introduction to Engineering", Credits = 3, Time = "T/TR 11:15 AM - 12:25 PM", Professor = "Prof11" },
                new Course { CourseId = 13, CourseCode = "CHEM221", CourseName = "General Chemistry I", Credits = 5, Time = "T/TR 4:30 PM - 6:00 PM", Professor = "Prof12" }
            );

            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId = 1,  // Set a unique ID for the student
                   Name = "Test Student",
                   Email = "test@student.com",
                   Password = "test123",  
                   Major = "Computer Science",
                   Year = "Sophomore"
               }
           );

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>().HasData(
            new Enrollment
            {
                EnrollmentId = 1,  // Unique identifier for the enrollment
                CourseId = 1,      // Enroll in the course with CourseId = 1
                StudentId = 1,     // Enroll the student with StudentId = 1
                EnrollmentDate = DateTime.Now
            }
        );
        }
      

    }

}
