using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class MoreClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5,
                column: "CourseName",
                value: "Discrete Structures I");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseCode", "CourseName", "Credits", "CurrentEnrollment", "Description", "MaxCapacity", "Professor", "Time" },
                values: new object[,]
                {
                    { 14, "PHIL125", "Introductory Logic", 3, 7, "General education humanities course. Introduces students to the use of formal logic as a tool for understanding and evaluating patterns of reasoning. Focuses on deductive validity, logical equivalence and proving soundness. The formal systems introduced in this course are topic-neutral—i.e., they apply to patterns of reasoning on any topic. These formal systems are particularly useful for future studies in areas such as computer science, law, engineering and philosophy.", 25, "Prof13", "M/W/F 10:30 AM - 11:45 AM" },
                    { 15, "PHIL354", "Ethics and Computers", 3, 5, "General education humanities course. Ethics with application to the ethical issues which may arise from the use of computers, including the moral responsibility of computer professionals for the effect their work has on persons and society; the moral obligations of a computer professional to clients, employer and society; the conceptual and ethical issues surrounding the control and ownership of software; and the justifiability of regulation of the design, use and marketing of computer technology. Course includes diversity content. Prerequisite(s): junior standing or departmental consent.", 25, "Prof14", "M/W/F 9:30 AM - 10:45 AM" },
                    { 16, "MATH242", "Calculus I", 5, 17, "General education math and natural sciences course. Analytic geometry and the calculus in an interrelated form. Students may receive credit for only one of these courses: MATH 144, 242 or 251. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 112 with a C or better, or two units of high school algebra, one unit of high school geometry and one-half unit of high school trigonometry, or MATH 123 and 111 with a C or better in each.", 35, "Prof15", "M/W/F 5:45 PM - 7:15 PM" },
                    { 17, "PHYS314", "Physics for Scientists II", 4, 15, "General education math and natural sciences course. The second semester of a calculus-based physics sequence. Topics include electricity, magnetism, circuits, EM waves, light and selections from modern physics. Credit is only given for one of PHYS 214 or 314. Natural sciences majors are required to take the lab, PHYS 316, that accompanies this course. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 243 with a grade of C or better and PHYS 313.", 30, "Prof16", "M/W/F 4:30 PM - 5:15 PM" },
                    { 18, "PHYS316", "University Physics Lab II", 1, 15, "General education math and natural sciences course. Lab experiments in electricity, magnetism and optics. Required for natural sciences majors taking PHYS 314. This is a Kansas Systemwide Transfer Course. Pre- or corequisite(s): PHYS 314.", 30, "Prof17", "T/TR 9:30 AM - 12:15 PM" },
                    { 19, "MATH322", "Discrete Structures II", 3, 21, "Cross-listed as CS 322. Continuation of Discrete Structures I. Includes relations, graphs, trees, Boolean algebra and automata. Prerequisite(s): MATH 321 or CS 321.", 25, "Prof18", "T/TR 9:30 AM - 11:15 AM" },
                    { 20, "PHYS313", "Physics for Scientists I", 4, 21, "General education math and natural sciences course. The first semester of a calculus-based physics sequence. Topics include motion, forces, energy, fluids, oscillations, waves and thermodynamics. Natural sciences majors are required to take the lab, PHYS 315, that accompanies this course. Credit is given for only one of PHYS 213 or 313. This is a Kansas Systemwide Transfer Course. Pre- or Corequisite(s): MATH 243 with a grade of C or better.", 50, "Prof19", "M/W/F 8:30 AM - 10:45 AM" },
                    { 21, "IME254", "Engineering Probability and Statistics I", 3, 57, "Designed for undergraduate students majoring in engineering. It reviews graphical and numerical methods for summarizing and describing datasets, discusses basic concepts of probability, introduces discrete and continuous random variables, and presents statistical methods for making inferences about population parameters. Prerequisite(s): MATH 242.", 75, "Prof20", "M/W/F 8:30 AM - 10:45 AM" },
                    { 22, "ECE194", "Introduction to Digital Design", 4, 40, "Introduces digital design concepts. Includes number systems, Boolean algebra, Karnaugh maps, combinational circuit design, adders, multiplexers, decoders, sequential circuit design, state diagram, flip flops, sequence detectors and test different combinational and sequential circuits. Uses CAD tools for circuit simulation. Prerequisite(s): MATH 111 or equivalent. Corequisite(s): ECE 194L.", 45, "Prof22", "T/TR 8:30 AM - 9:45 AM" },
                    { 23, "CS211", "Introduction to Programming", 4, 40, "First course in computer programming in a high-level language. Emphasizes analyzing problems, designing solutions and expressing them in the form of a well-structured program using the procedural aspects of C++. Prerequisite(s): MATH 111. Corequisite(s): CS 211L.", 50, "Prof23", "T/TR 12:30 PM - 1:45 PM" },
                    { 24, "ECE238", "Assesmbly Language Programming for Engineering", 3, 27, "Introduces basic concepts of computer organization and operation. Studies machine and assembly language programming concepts that illustrate basic principles and techniques. Laboratory exercises given for experience using personal computers. Prerequisite(s): CS 211.", 50, "Prof24", "T/TR 1:30 PM - 2:45 PM" },
                    { 25, "CS311", "Object-Oriented Programming", 4, 27, "Concepts of object-oriented programming. Covers data abstractions, classes and objects, methods, inheritance, polymorphism, dynamically-bound method calls and data encapsulation. Includes programming assignments in C++. Prerequisite(s): CS 211. Corequisite(s): CS 311L.", 30, "Prof25", "T/TR 3:30 PM - 5:30 PM" },
                    { 26, "ECE394", "Introduction to Computer Architecture", 3, 27, "Introduces multilevel approach to computer systems, with an emphasis on micro architecture and instruction set architecture levels. Also introduces techniques to improve performance such as cache memory and instruction level parallelism. Prerequisite(s): ECE 194 and CS 211.", 45, "Prof26", "T/TR 8:30 AM - 9:55 AM" },
                    { 27, "CS410", "Programming Paradigms", 3, 17, "Overview of different programming paradigms, including their philosophies, uses and relative advantages/disadvantages. Covers the procedural/imperative, functional, logic and object-oriented paradigms. Includes programming assignments in the functional and logic paradigms. Prerequisite(s): CS 311.", 50, "Prof27", "T/TR 9:30 AM - 10:45 AM" },
                    { 28, "CS664", "Computer Networks", 3, 10, "Introductory course on computer networking. Introduces concepts and protocols in various network layers with emphasis on the internet. Topics covered include: physical layer (wired and wireless), medium access control and data link layers, packet switching and routing (IP), routing protocols, transport layer (TCP, UDP), congestion and flow control, basic network security, and network applications. Prerequisite(s): undergraduate students: IME 254 and CS 311; graduate students: object oriented programming and statistics/probability knowledge.", 50, "Prof28", "T/TR 4:45 PM - 5:45 PM" },
                    { 29, "CS580", "Introduction to Software Engineering", 3, 23, "Introduces the processes, methods and tools used in software development and maintenance. Topics include software development life cycle and processes, configuration management, requirements gathering, OOA/D with UML, cohesion and coupling, and unit testing. Prerequisite(s): CS 311.", 50, "Prof29", "T/TR 10:45 AM - 12:05 PM" },
                    { 30, "CS540", "Operating Systems", 3, 45, "Fundamental principles of modern operating systems. CPU management including processes, threads, scheduling, synchronization, resource allocation and deadlocks. Memory management including paging and virtual memory. Storage management and file systems. Prerequisite(s): ECE 238 and CS 311.", 50, "Prof30", "T/TR 10:45 AM - 12:15 PM" },
                    { 31, "CS560", "Design and Analysis of Algorithms", 3, 17, "Design of various algorithms including several sorting algorithms. Analysis of their space and time complexities. Data structures include heaps, hash tables and binary search trees. Prerequisite(s): CS 322, 400; STAT 460 or IME 254.", 25, "Prof31", "T/TR 12:30 PM - 1:45 PM" },
                    { 32, "CS665", "Introduction to Database Systems", 3, 53, "Fundamental aspects of relational database systems, conceptual database design and entity-relationship modeling; the relational data model and its foundations, relational languages and SQL, functional dependencies and logical database design; views, constraints and triggers. Course includes a group project involving the design and implementation of a relational database and embedded SQL programming. Prerequisite(s): CS 311, MATH 322.", 75, "Prof32", "T/TR 5:30 PM - 6:45 PM" },
                    { 33, "CS356", "Introduction to Computer Security", 3, 43, "Provides a first approach to the security mindset. Covers how adversaries exploit common software vulnerabilities such as buffer overflows and race conditions. Students learn secure coding techniques and countermeasures. Topics also include cryptography principles, web security, and legal and ethical aspects. Prerequisite(s): CS 211.", 50, "Prof33", "M/W 2:00 PM - 3:15 PM" },
                    { 34, "CS598", "Senior Design Project I", 2, 43, "Cross-listed as ECE 585. Design project under faculty supervision chosen according to the student's interest. Does not count toward a graduate degree in electrical engineering, computer engineering or computer science. This class should be taken in the semester prior to the one in which the student is going to graduate. For undergraduate credit only. Prerequisite(s): senior standing, ECE 492 or CS 580. Pre- or corequisite(s): PHIL 354 or PHIL 385.", 75, "Prof34", "F 9:30 AM - 12:15 PM" },
                    { 35, "CS599", "Senior Design Project II", 2, 43, "This is the second part of a sequence of two courses (CS 598 and CS 599) that have to be taken in two consecutive semesters. Students failing this course must retake the CS 598 course. For undergraduate credit only. Prerequisite(s): CS 598. Pre- or corequisite(s): PHYS 314 and PHYS 316.", 75, "Prof35", "F 2:00 PM - 5:45 PM" },
                    { 36, "MATH511", "Linear Algebra", 3, 30, "An elementary study of linear algebra, including an examination of linear transformations and matrices over finite dimensional spaces. Prerequisite(s): MATH 243 with a grade point of 2.000 or better.", 35, "Prof36", "M/W/F 1:45 PM - 3:15 PM" }
                });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 12, 5, 12, 59, 13, 575, DateTimeKind.Local).AddTicks(1183));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 36);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5,
                column: "CourseName",
                value: "Discrete Math");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 11, 21, 18, 57, 51, 421, DateTimeKind.Local).AddTicks(3376));
        }
    }
}
