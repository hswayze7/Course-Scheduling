﻿// <auto-generated />
using System;
using CourseScheduling.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CourseScheduling.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20241115044642_UpdateStudent")]
    partial class UpdateStudent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseScheduling.Models.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Professor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Time")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");

                    b.HasData(
                        new
                        {
                            CourseId = 1,
                            CourseCode = "CS101",
                            CourseName = "Introduction to Computer Science",
                            Credits = 3,
                            Description = "Into to Computer Science subjects.",
                            Professor = "Prof1",
                            Time = "M/W/F 10:00 AM - 12:00 PM"
                        },
                        new
                        {
                            CourseId = 2,
                            CourseCode = "MATH243",
                            CourseName = "Calculus II",
                            Credits = 4,
                            Description = "General education math and natural sciences course. Analytic geometry and the calculus in an interrelated form. Students may receive credit for only one of these courses: MATH 144, 242 or 251. This is a Kansas Systemwide Transfer Course.",
                            Professor = "Prof2",
                            Time = "T/TR 1:00 PM - 3:00 PM"
                        },
                        new
                        {
                            CourseId = 3,
                            CourseCode = "CS400",
                            CourseName = "Data Structures",
                            Credits = 4,
                            Description = "Introduces basic data structures and covers their implementations using classes in C++. Includes lists, stacks, queues, binary trees and hash tables.",
                            Professor = "Prof3",
                            Time = "T/TR 2:15 PM - 3:30 PM"
                        },
                        new
                        {
                            CourseId = 4,
                            CourseCode = "CS510",
                            CourseName = "Programming Language Concepts",
                            Credits = 3,
                            Description = "Theoretical concepts in the design and use of programming languages. Formal syntax, including Backus Normal Form (BNF), Extended Backus-Naur Form (EBNF), and syntax diagrams. Semantics, including declaration, allocation and evaluation, symbol table and runtime environment; data types and type checking, procedure activation and parameter passing, modules and abstract data types.",
                            Professor = "Prof13",
                            Time = "T/TR 8:30 AM - 9:50 AM"
                        },
                        new
                        {
                            CourseId = 5,
                            CourseCode = "MATH231",
                            CourseName = "Discrete Math",
                            Credits = 3,
                            Description = "A study of some of the basic topics of discrete mathematics, including elementary logic, properties of sets, mathematical induction, counting problems using permutations and combinations, trees, elementary probability, and an introduction to graph theory.",
                            Professor = "Prof4",
                            Time = "M/W/F 1:00 PM - 3:00 PM"
                        },
                        new
                        {
                            CourseId = 6,
                            CourseCode = "PSY325",
                            CourseName = "Developmental Psychology",
                            Credits = 3,
                            Description = "Studies systems of formal logic including sentential and predicate logic. Emphasizes the uses of these systems in the analysis of arguments.",
                            Professor = "Prof5",
                            Time = "M/T/F 12:30 PM - 1:45 PM"
                        },
                        new
                        {
                            CourseId = 7,
                            CourseCode = "SOC338",
                            CourseName = "Health & Lifestyle",
                            Credits = 3,
                            Description = "General education social and behavioral sciences course. Examines the component dimensions of health and the societal-level factors and lifestyle choices that influence health across the life span.",
                            Professor = "Prof6",
                            Time = "M/W/F 2:15 PM - 3:30 PM"
                        },
                        new
                        {
                            CourseId = 8,
                            CourseCode = "MKT690J",
                            CourseName = "Social Media Marketing",
                            Credits = 3,
                            Description = "Social media is an essential part of today’s digital marketing mix and integral to a successful digital strategy. This course provides an introduction to social media marketing and lays the foundation for developing an effective social media campaign. Students learn what social media marketing entails, including the various platforms that exist, selecting the appropriate channels to fit their needs, setting goals and success metrics, and constructing social media strategies that achieve the desired marketing goals. Students also are introduced to quantitative and qualitative measurement tools to evaluate social media initiatives and assess their return on investment for an organization.",
                            Professor = "Prof7",
                            Time = "T/TR 9:30 AM - 10:45 AM"
                        },
                        new
                        {
                            CourseId = 9,
                            CourseCode = "MGMT681",
                            CourseName = "Strategic Management",
                            Credits = 3,
                            Description = "Choosing and executing the right strategy at the right time in the right way is the most important element of business success. This is a capstone course which integrates the functional areas of business, including management, marketing, finance, accounting and production. Students learn the tools to develop and implement strategies in organizations. Students are challenged through various projects, simulations and case studies to explore domestic and international policy issues, large and small firms, various sources of competitive advantage, and learn to effectively implement a successful strategy. For undergraduate credit only",
                            Professor = "Prof8",
                            Time = "M/F/W 3:30 PM - 4:45 PM"
                        },
                        new
                        {
                            CourseId = 10,
                            CourseCode = "NURS362",
                            CourseName = "Clinical Care Lab",
                            Credits = 1,
                            Description = "Focuses on progression of nursing skills.",
                            Professor = "Prof9",
                            Time = "F 1:00 PM - 4:00 PM"
                        },
                        new
                        {
                            CourseId = 11,
                            CourseCode = "GEOG235",
                            CourseName = "Meteorology",
                            Credits = 3,
                            Description = "General education math and natural sciences course. Cross-listed as GEOL 235. Introductory study of the atmosphere and its properties and the various phenomena of weather. Includes a brief survey of important principles of physical, dynamic, synoptic and applied meteorology. Does not apply toward a major or minor in geology. Requires field trips at the option of the instructor.",
                            Professor = "Prof10",
                            Time = "M/W/F 2:15 PM - 3:30 PM"
                        },
                        new
                        {
                            CourseId = 12,
                            CourseCode = "ENGR101",
                            CourseName = "Introduction to Engineering",
                            Credits = 3,
                            Description = "Assists engineering students in exploring engineering careers and opportunities. Provides information on academic and life skills essential to becoming a successful engineering student. Promotes connections to specific engineering majors and provides activities to assist and reinforce the decision to major in engineering.",
                            Professor = "Prof11",
                            Time = "T/TR 11:15 AM - 12:25 PM"
                        },
                        new
                        {
                            CourseId = 13,
                            CourseCode = "CHEM211",
                            CourseName = "General Chemistry I",
                            Credits = 5,
                            Description = "General education math and natural sciences course. Introduces general concepts of chemistry. Includes chemical stoichiometry, atomic and molecular structure, bonding, gas laws, states of matter and chemical periodicity. CHEM 211-212 meets the needs of students who may wish to take more than one course in chemistry. Credit is allowed in only one of the following: CHEM 211 or 110. Course requires a lab fee. This is a Kansas Systemwide Transfer Course",
                            Professor = "Prof12",
                            Time = "T/TR 4:30 PM - 6:00 PM"
                        });
                });

            modelBuilder.Entity("CourseScheduling.Models.Enrollment", b =>
                {
                    b.Property<int>("EnrollmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EnrollmentId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EnrollmentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("EnrollmentId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("Enrollments");

                    b.HasData(
                        new
                        {
                            EnrollmentId = 1,
                            CourseId = 1,
                            EnrollmentDate = new DateTime(2024, 11, 14, 22, 46, 41, 835, DateTimeKind.Local).AddTicks(2190),
                            StudentId = 1
                        });
                });

            modelBuilder.Entity("CourseScheduling.Models.Student", b =>
                {
                    b.Property<int>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentId"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Major")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Year")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            StudentId = 1,
                            Email = "test@student.com",
                            FirstName = "Test Student",
                            LastName = "Onetest Student",
                            Major = "Computer Science",
                            Password = "test123",
                            Year = "Sophomore"
                        });
                });

            modelBuilder.Entity("CourseScheduling.Models.StudentCourse", b =>
                {
                    b.Property<int>("StudentCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StudentCourseId"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("RegisteredAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.HasKey("StudentCourseId");

                    b.HasIndex("CourseId");

                    b.HasIndex("StudentId");

                    b.ToTable("StudentCourses");
                });

            modelBuilder.Entity("CourseScheduling.Models.Enrollment", b =>
                {
                    b.HasOne("CourseScheduling.Models.Course", "Course")
                        .WithMany("Enrollments")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseScheduling.Models.Student", "Student")
                        .WithMany("Enrollments")
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("CourseScheduling.Models.StudentCourse", b =>
                {
                    b.HasOne("CourseScheduling.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CourseScheduling.Models.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("CourseScheduling.Models.Course", b =>
                {
                    b.Navigation("Enrollments");
                });

            modelBuilder.Entity("CourseScheduling.Models.Student", b =>
                {
                    b.Navigation("Enrollments");
                });
#pragma warning restore 612, 618
        }
    }
}
