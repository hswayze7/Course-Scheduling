namespace CourseScheduling.Models
{
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    //Database class that creates the database structure of the project
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
                new Course { CourseId = 1, CourseCode = "CS101", CourseName = "Introduction to Computer Science", Credits = 3, Time = "M/W/F 10:00 AM - 12:00 PM", Professor = "Prof1", Description = "Into to Computer Science subjects." },
                new Course { CourseId = 2, CourseCode = "MATH243", CourseName = "Calculus II", Credits = 4, Time = "T/TR 1:00 PM - 3:00 PM", Professor = "Prof2", Description = "General education math and natural sciences course. Analytic geometry and the calculus in an interrelated form. Students may receive credit for only one of these courses: MATH 144, 242 or 251. This is a Kansas Systemwide Transfer Course." },
                new Course { CourseId = 3, CourseCode = "CS400", CourseName = "Data Structures", Credits = 4, Time = "T/TR 2:15 PM - 3:30 PM", Professor = "Prof3", Description = "Introduces basic data structures and covers their implementations using classes in C++. Includes lists, stacks, queues, binary trees and hash tables." },
                new Course { CourseId = 4, CourseCode = "CS510", CourseName = "Programming Language Concepts", Credits = 3, Time = "T/TR 8:30 AM - 9:50 AM", Professor = "Prof13", Description = "Theoretical concepts in the design and use of programming languages. Formal syntax, including Backus Normal Form (BNF), Extended Backus-Naur Form (EBNF), and syntax diagrams. Semantics, including declaration, allocation and evaluation, symbol table and runtime environment; data types and type checking, procedure activation and parameter passing, modules and abstract data types." },
                new Course { CourseId = 5, CourseCode = "MATH231", CourseName = "Discrete Math", Credits = 3, Time = "M/W/F 1:00 PM - 3:00 PM", Professor = "Prof4", Description = "A study of some of the basic topics of discrete mathematics, including elementary logic, properties of sets, mathematical induction, counting problems using permutations and combinations, trees, elementary probability, and an introduction to graph theory." },
                new Course { CourseId = 6, CourseCode = "PSY325", CourseName = "Developmental Psychology", Credits = 3, Time = "M/T/F 12:30 PM - 1:45 PM", Professor = "Prof5", Description = "Studies systems of formal logic including sentential and predicate logic. Emphasizes the uses of these systems in the analysis of arguments." },
                new Course { CourseId = 7, CourseCode = "SOC338", CourseName = "Health & Lifestyle", Credits = 3, Time = "M/W/F 2:15 PM - 3:30 PM", Professor = "Prof6", Description = "General education social and behavioral sciences course. Examines the component dimensions of health and the societal-level factors and lifestyle choices that influence health across the life span." },
                new Course { CourseId = 8, CourseCode = "MKT690J", CourseName = "Social Media Marketing", Credits = 3, Time = "T/TR 9:30 AM - 10:45 AM", Professor = "Prof7", Description = "Social media is an essential part of today’s digital marketing mix and integral to a successful digital strategy. This course provides an introduction to social media marketing and lays the foundation for developing an effective social media campaign. Students learn what social media marketing entails, including the various platforms that exist, selecting the appropriate channels to fit their needs, setting goals and success metrics, and constructing social media strategies that achieve the desired marketing goals. Students also are introduced to quantitative and qualitative measurement tools to evaluate social media initiatives and assess their return on investment for an organization." },
                new Course { CourseId = 9, CourseCode = "MGMT681", CourseName = "Strategic Management", Credits = 3, Time = "M/F/W 3:30 PM - 4:45 PM", Professor = "Prof8", Description = "Choosing and executing the right strategy at the right time in the right way is the most important element of business success. This is a capstone course which integrates the functional areas of business, including management, marketing, finance, accounting and production. Students learn the tools to develop and implement strategies in organizations. Students are challenged through various projects, simulations and case studies to explore domestic and international policy issues, large and small firms, various sources of competitive advantage, and learn to effectively implement a successful strategy. For undergraduate credit only" },
                new Course { CourseId = 10, CourseCode = "NURS362", CourseName = "Clinical Care Lab", Credits = 1, Time = "F 1:00 PM - 4:00 PM", Professor = "Prof9", Description = "Focuses on progression of nursing skills." },
                new Course { CourseId = 11, CourseCode = "GEOG235", CourseName = "Meteorology", Credits = 3, Time = "M/W/F 2:15 PM - 3:30 PM", Professor = "Prof10", Description = "General education math and natural sciences course. Cross-listed as GEOL 235. Introductory study of the atmosphere and its properties and the various phenomena of weather. Includes a brief survey of important principles of physical, dynamic, synoptic and applied meteorology. Does not apply toward a major or minor in geology. Requires field trips at the option of the instructor." },
                new Course { CourseId = 12, CourseCode = "ENGR101", CourseName = "Introduction to Engineering", Credits = 3, Time = "T/TR 11:15 AM - 12:25 PM", Professor = "Prof11", Description = "Assists engineering students in exploring engineering careers and opportunities. Provides information on academic and life skills essential to becoming a successful engineering student. Promotes connections to specific engineering majors and provides activities to assist and reinforce the decision to major in engineering." },
                new Course { CourseId = 13, CourseCode = "CHEM211", CourseName = "General Chemistry I", Credits = 5, Time = "T/TR 4:30 PM - 6:00 PM", Professor = "Prof12", Description = "General education math and natural sciences course. Introduces general concepts of chemistry. Includes chemical stoichiometry, atomic and molecular structure, bonding, gas laws, states of matter and chemical periodicity. CHEM 211-212 meets the needs of students who may wish to take more than one course in chemistry. Credit is allowed in only one of the following: CHEM 211 or 110. Course requires a lab fee. This is a Kansas Systemwide Transfer Course" }
            );

            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId = 1,  // Set a unique ID for the student
                   FirstName = "Test Student",
                   LastName = "Onetest Student",
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
