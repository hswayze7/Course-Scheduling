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
                new Course { CourseId = 1, CourseCode = "CS101", CourseName = "Introduction to Computer Science", Credits = 3, Time = "Mon 10:00 AM - 12:00 PM" },
                new Course { CourseId = 2, CourseCode = "MATH201", CourseName = "Calculus II", Credits = 4, Time = "Tue 1:00 PM - 3:00 PM" }
            );

            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId = 1,  // Set a unique ID for the student
                   Name = "Test Student",
                   Email = "test@student.com",
                   Password = "test123",  // You can also hash this password
                   Major = "Computer Science",
                   Year = "Sophomore"
               }
           );

            modelBuilder.Entity<Enrollment>()
           .HasKey(e => e.EnrollmentId);
        }
      

    }

}
