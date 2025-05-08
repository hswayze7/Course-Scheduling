using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Professor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxCapacity = table.Column<int>(type: "int", nullable: false),
                    CurrentEnrollment = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Degree",
                columns: table => new
                {
                    DegreeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MajorName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Degree", x => x.DegreeId);
                });

            migrationBuilder.CreateTable(
                name: "DegreeRequirements",
                columns: table => new
                {
                    DegreeRequirementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeId = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    SemesterSuggestion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeRequirements", x => x.DegreeRequirementId);
                    table.ForeignKey(
                        name: "FK_DegreeRequirements_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DegreeRequirements_Degree_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "DegreeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DegreeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Degree_DegreeId",
                        column: x => x.DegreeId,
                        principalTable: "Degree",
                        principalColumn: "DegreeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Enrollments",
                columns: table => new
                {
                    EnrollmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CourseCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollments", x => x.EnrollmentId);
                    table.ForeignKey(
                        name: "FK_Enrollments_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Enrollments_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentCourses",
                columns: table => new
                {
                    StudentCourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    RegisteredAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCourses", x => x.StudentCourseId);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCourses_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Waitlists",
                columns: table => new
                {
                    WaitlistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    AddedToWaitlist = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Waitlists", x => x.WaitlistId);
                    table.ForeignKey(
                        name: "FK_Waitlists_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Waitlists_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "StudentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseCode", "CourseName", "Credits", "CurrentEnrollment", "Description", "MaxCapacity", "Professor", "Time" },
                values: new object[,]
                {
                    { 1, "CS101", "Introduction to Computer Science", 3, 2, "Into to Computer Science subjects.", 25, "Prof1", "M/W/F 10:00 AM - 12:00 PM" },
                    { 2, "MATH243", "Calculus II", 4, 5, "General education math and natural sciences course. Analytic geometry and the calculus in an interrelated form. Students may receive credit for only one of these courses: MATH 144, 242 or 251. This is a Kansas Systemwide Transfer Course.", 25, "Prof2", "T/TR 1:00 PM - 3:00 PM" },
                    { 3, "CS400", "Data Structures", 4, 2, "Introduces basic data structures and covers their implementations using classes in C++. Includes lists, stacks, queues, binary trees and hash tables.", 35, "Prof3", "T/TR 2:15 PM - 3:30 PM" },
                    { 4, "CS510", "Programming Language Concepts", 3, 15, "Theoretical concepts in the design and use of programming languages. Formal syntax, including Backus Normal Form (BNF), Extended Backus-Naur Form (EBNF), and syntax diagrams. Semantics, including declaration, allocation and evaluation, symbol table and runtime environment; data types and type checking, procedure activation and parameter passing, modules and abstract data types.", 40, "Prof13", "T/TR 8:30 AM - 9:50 AM" },
                    { 5, "MATH231", "Discrete Structures I", 3, 25, "A study of some of the basic topics of discrete mathematics, including elementary logic, properties of sets, mathematical induction, counting problems using permutations and combinations, trees, elementary probability, and an introduction to graph theory.", 25, "Prof4", "M/W/F 1:00 PM - 3:00 PM" },
                    { 6, "PSY325", "Developmental Psychology", 3, 25, "Studies systems of formal logic including sentential and predicate logic. Emphasizes the uses of these systems in the analysis of arguments.", 50, "Prof5", "M/T/F 12:30 PM - 1:45 PM" },
                    { 7, "SOC338", "Health & Lifestyle", 3, 10, "General education social and behavioral sciences course. Examines the component dimensions of health and the societal-level factors and lifestyle choices that influence health across the life span.", 30, "Prof6", "M/W/F 2:15 PM - 3:30 PM" },
                    { 8, "MKT690J", "Social Media Marketing", 3, 12, "Social media is an essential part of today’s digital marketing mix and integral to a successful digital strategy. This course provides an introduction to social media marketing and lays the foundation for developing an effective social media campaign. Students learn what social media marketing entails, including the various platforms that exist, selecting the appropriate channels to fit their needs, setting goals and success metrics, and constructing social media strategies that achieve the desired marketing goals. Students also are introduced to quantitative and qualitative measurement tools to evaluate social media initiatives and assess their return on investment for an organization.", 20, "Prof7", "T/TR 9:30 AM - 10:45 AM" },
                    { 9, "MGMT681", "Strategic Management", 3, 7, "Choosing and executing the right strategy at the right time in the right way is the most important element of business success. This is a capstone course which integrates the functional areas of business, including management, marketing, finance, accounting and production. Students learn the tools to develop and implement strategies in organizations. Students are challenged through various projects, simulations and case studies to explore domestic and international policy issues, large and small firms, various sources of competitive advantage, and learn to effectively implement a successful strategy. For undergraduate credit only", 15, "Prof8", "M/F/W 3:30 PM - 4:45 PM" },
                    { 10, "NURS362", "Clinical Care Lab", 1, 0, "Focuses on progression of nursing skills.", 25, "Prof9", "F 1:00 PM - 4:00 PM" },
                    { 11, "GEOG235", "Meteorology", 3, 25, "General education math and natural sciences course. Cross-listed as GEOL 235. Introductory study of the atmosphere and its properties and the various phenomena of weather. Includes a brief survey of important principles of physical, dynamic, synoptic and applied meteorology. Does not apply toward a major or minor in geology. Requires field trips at the option of the instructor.", 40, "Prof10", "M/W/F 2:15 PM - 3:30 PM" },
                    { 12, "ENGR101", "Introduction to Engineering", 3, 9, "Assists engineering students in exploring engineering careers and opportunities. Provides information on academic and life skills essential to becoming a successful engineering student. Promotes connections to specific engineering majors and provides activities to assist and reinforce the decision to major in engineering.", 15, "Prof11", "T/TR 11:15 AM - 12:25 PM" },
                    { 13, "CHEM211", "General Chemistry I", 5, 2, "General education math and natural sciences course. Introduces general concepts of chemistry. Includes chemical stoichiometry, atomic and molecular structure, bonding, gas laws, states of matter and chemical periodicity. CHEM 211-212 meets the needs of students who may wish to take more than one course in chemistry. Credit is allowed in only one of the following: CHEM 211 or 110. Course requires a lab fee. This is a Kansas Systemwide Transfer Course", 25, "Prof12", "T/TR 4:30 PM - 6:00 PM" },
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
                    { 36, "PSY111", "General Psychology", 3, 45, "General education social and behavioral sciences course. Introduces the general principles and areas of psychology. Includes learning, perceiving, thinking, behavioral development, intelligence, personality and abnormalities of behavior. Course is a prerequisite for advanced and specialized courses in psychology. This is a Kansas Systemwide Transfer Course.", 50, "Prof37", "M/W/F 1:45 PM - 3:15 PM" },
                    { 37, "ECON201", "Principles of Macroeconomics", 3, 30, "General education social and behavioral sciences course. Introduces economic concepts of scarcity, markets and prices. Emphasizes business cycles, recessions and recoveries, unemployment, inflation, monetary and fiscal policy. Discusses money and the banking system, the Federal Reserve, and trade and the impact of the global economy. This is a Kansas Systemwide Transfer Course.", 45, "Prof38", "T/TR 1:45 PM - 3:15 PM" },
                    { 38, "MATH123", "College Trigonometry", 3, 4, "Studies the trigonometric functions and their applications. Credit in both MATH 123 and 112 is not allowed. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 111 with C or better or equivalent high school preparation and one unit of high school geometry.", 30, "Prof39", "M/W/F 12:30 PM - 1:55 PM" },
                    { 39, "PSY323", "Social Psychology", 3, 8, "General education social and behavioral sciences course. Studies perception of self, others and groups. Includes attitude formation and change, group processes like conformity, compliance and conflict, and interpersonal processes such as attraction and the formation of close relationships. Also includes the application of social psychological principles to the study of prosocial and aggressive behavior. Prerequisite(s): PSY 111.", 30, "Prof40", "M/W/F 9:30 AM - 10:45 AM" },
                    { 40, "PSY405", "Human Factors Psychology", 3, 30, "The study of how people respond to the demands of complex machines and the varied environments of workplace, home and other settings. Introduces the tools and methods of machine, task and environment design to achieve the matching of human capabilities and the demands of machines and environments so as to enhance human performance and well being. Prerequisite(s): PSY 111.", 45, "Prof41", "T/TH 9:45 AM - 11:00 AM" },
                    { 41, "STAT370", "Elementary Statistics", 3, 17, "General education math and natural sciences course. Surveys elementary descriptive statistics, binomial and normal distributions, elementary problems of statistical inference, linear correlation and regression. Not open to mathematics majors. Students cannot receive credit for both STAT 171 and STAT 370. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 111 with a C or better or equivalent.", 30, "Prof42", "M/W/F 1:45 PM - 3:15 PM" },
                    { 42, "AC121", "Cybersecurity Awareness", 3, 30, "The ability to secure information and systems within a modern enterprise in this modern globalized environment is a growing challenge. Ever-present human threats are global, persistent and increasingly sophisticated. Natural threats are unpredictable but inevitable. Vulnerabilities within the complex and interdependent system of systems continue to be discovered with many more yet to become common knowledge. Exploited vulnerabilities can have a devastating impact on an organization or even a society. This course is designed to familiarize users with information, cyberspace and security principles needed to understand these threats. To this end, the course addresses a range of topics, including information infrastructures, social engineering, information system exploitation techniques and countermeasures to the threats discussed. Pre- or corequisite(s): PHIL 125 or PHIL 105.", 30, "Prof43", "T/TR 8:30 AM - 10:00 AM" },
                    { 43, "AC201", "Introductory Design Project", 1, 2, "The first of the three-course project design series. The course introduces students to project design, prototyping, engineering standards and professional reports. Students are part of teams, learn prototyping skills and have hands on experiences in a maker-space. Students learn project management tools, team working tools, how to perform market research and develop videos, and prototype development. Prerequisite(s): FYET 102A, FYET 102B, ENGR 302, ID 300 or instructor's consent.", 30, "Prof44", "M/W/F 4:15 PM - 5:45 PM" },
                    { 44, "AC222", "Applied Computing Fundamentals", 3, 12, "Information technology (IT) virtually connects people and businesses in the world. The daily operations of every organization in the public and private sector heavily rely on the internet. This course allows students to gain vital concepts on computer hardware, computer systems, networking and security to solve real-world computing challenges. This course is a key for anyone who wants to gain basic skills in the computing sector. Students collaborate effectively and think critically to develop skills in computing and networking. Students learn to use industry-standard tools through hands-on class projects.", 30, "Prof45", "M/W/F 11:45 AM - 1:20 PM" },
                    { 45, "AC301", "Junior Project", 2, 30, "Second course in four-course project sequence. Introduces students to engineering design concepts with an entrepreneurial mindset. This includes customer discovery and value creation techniques as well as engineering design and project management tools. Prerequisite(s): AC 201 or ENGR 205 or instructor's consent.", 50, "Prof46", "M/W/F 1:45 PM - 3:15 PM" },
                    { 46, "AC321", "Applied Networking", 3, 22, "Information technology (IT) virtually connects people and businesses in the world. The daily operations of every organization in the public and private sector heavily rely on the internet. This course allows students to gain vital concepts on computer networking and security to solve real-world computing challenges. This course is a key for anyone who wants to gain advanced skills in the computing sector. Students collaborate effectively and think critically to develop skills in computer networking. Students learn to use industry-standard tools through hands-on class projects.", 30, "Prof47", "M/W/F 3:45 PM - 5:15 PM" },
                    { 47, "AC322", "Applied Programming and Scripting", 3, 21, "Good scripting skills are vital to IT experts in the fields of information security. This course is designed for cybersecurity professionals who are interested in learning basic coding skills to perform the cybersecurity tasks more efficiently. The course assists students in taking their cybersecurity career to the next level by teaching the vital skills needed to develop as well as customize applications that interact with file systems, databases, networks and websites. Covers command shell scripting (cmd, powershell, bash) in Windows and Linux operating systems. Emphasizes scripting cybersecurity tasks such as system configuration, system auditing and penetration testing. Also covers Arduino microcontrollers, coding Arduino in Python and coding TCP Traceroute. Python language is used in this course. Prerequisite(s): AC 222 or MIS 325.", 30, "Prof48", "F 1:45 PM - 3:15 PM" },
                    { 48, "AC324", "Applied Web Applications and Database Development", 3, 14, "When browsing on a web application, look for two things: how user-friendly the web app is and how the information is stored, controlled and used. Each web application has a set of requirements such as financial transaction, customer information, etc. The course covers web and database technologies, services, protocols, design and operation. Students learn a variety of languages including HTML, CSS, Apache and MySQL. Course is designed to apply the languages through hands-on projects. Prerequisite(s): AC 222 or MIS 325 or CS 664. Pre- or corequisite(s): ECON 201 or IME 255.", 30, "Prof49", "F 12:45 PM - 2:15 PM" },
                    { 49, "AC326", "Cyber Operations", 3, 1, "Covers concepts related to cyber attack, penetration testing, cyber intelligence, cryptography and cyber defense. Students learn the attacker's perspective and how security infrastructure integrates with the rest of the business and IT infrastructure through the use of hands-on projects. Prerequisite(s): AC 121, AC 222, AC 321 and AC 322 .", 30, "Prof50", "M/W/F 1:45 PM - 3:15 PM" },
                    { 50, "AC352", "Competitive Ethical Hacking", 3, 9, "Kevin Mitnick, who popularized the term “social engineering,” explained that it is much easier to trick someone into revealing a password for a system than to exert the effort of hacking into the system. Mitnick claims that this social engineering tactic was the single-most effective method in his arsenal. This course covers human threats to cybersecurity in political, social and economic contexts. It includes targeted exploitation/manipulation of individuals, small groups and larger groups through social engineering, marketing, propaganda, psychological operations by personal contact, email, social networking, web and RF transmission. Prerequisite(s): AC 121 .", 25, "Prof51", "M/W/F 1:45 PM - 3:15 PM" },
                    { 51, "AC363", "Human Threats to Cybersecurity", 3, 9, "Cross-listed as CS 352. Presents fundamental concepts of competitive ethical hacking in computer and network security. The course introduces the command line interface, open-source intelligence, cryptography, digital forensics, web application security, software reverse engineering, secure programming and log analysis. Assignments include participating in capture the flag competitions. Prerequisite(s): CS 211 or (AC 121 and AC 322).", 30, "Prof52", "T/TR 2:45 PM - 4:15 PM" },
                    { 52, "AC401", "Senior Project I", 3, 39, "The third of the four-course project design series. In this intermediate course, students learn the importance of the voice of the customer, the customer/product market fit through using the business model canvas, and engineering design tools. Students learn and practice customer interview techniques and, through the feedback, help to develop appropriate solutions and prototypes. Students perform individual observations to discover unmet needs in industry and, after refining the needs, teams form to solve these needs. Comprehensively covers the student’s concentration in applied computing and its applications. Students work with faculty and external consultants and industry to refine their team based senior project. Prerequisite(s): AC 301 and PHYS 213. Pre- or corequisite(s): PHIL 354.", 75, "Prof53", "F 1:45 PM - 4:15 PM" },
                    { 53, "AC402", "Senior Project II", 3, 27, "Comprehensively covers the student’s concentration in applied computing and its applications. Students continue to work in their teams with faculty and external consultants and industry to refine and develop a final solution for their team based senior project. Prerequisite(s): AC 401.", 75, "Prof54", "F 1:45 PM - 4:15 PM" },
                    { 54, "AC461", "Digital Forensics", 3, 20, "Covers concepts related to hardware and software forensics, incident response, cyber crime and cyber law enforcement. Students learn different aspects of computer and cyber crime and ways to uncover, protect, exploit and document digital evidence. Students are exposed to different types of tools (both software and hardware), techniques and procedures, and are able to use them to perform rudimentary forensic investigations. Focuses on the entire life cycle of incident response including preparation, data collection, data analysis and remediation. Real world case studies reveal the methods behind and remediation strategies for today's most insidious attacks. Prerequisite(s): AC 326 .", 30, "Prof55", "M/W/F 9:30 AM - 11:15 AM" },
                    { 55, "AC462", "Cyber Physical Systems", 4, 15, "Focuses on trustworthy and resilient CPS, starting with NIST's CPS Framework. Students learn about common IoT infrastructures, integrate CPS into organizational risk management, and conduct cybersecurity risk assessments for critical cyber physical systems. Prerequisite(s): ENGR 220 and AC 326, or instructor’s consent.", 35, "Prof56", "M/W/F 11:15 AM - 12:45 PM" },
                    { 56, "AC463", "Cyber Risk Management", 3, 16, "This course covers application of risk and information security management to improve organizational resilience. Concepts include business impact analysis, incident response planning, disaster recovery planning, business continuity planning and security auditing. Prerequisite(s): AC 326.", 35, "Prof56", "M/W/F 10:45 AM - 12:45 PM" },
                    { 57, "AC464", "Web Application Security", 3, 21, "Develops an understanding of common web-based vulnerabilities and their impacts. Concepts include development and management of secure web-based systems, security mitigation strategies and penetration testing. Prerequisite(s): AC 324 and AC 326 .", 35, "Prof56", "M/W/F 11:15 AM - 12:45 PM" },
                    { 58, "ENGR220", "Applied Analog and Digital Electronics", 3, 14, "Provides a fundamental understanding of electronics and programming through content and active learning. Introduces basic electronic components and principles, sensors, actuators and electronic diagnostic tools. Builds confidence and creativity by designing, constructing and debugging circuits as well as programming a micro-controller to perform desired tasks. Introduces students to semiconductors and integrated circuits such as op-amps, combinational logic circuits and flip-flops. Students learn methods to interact with the physical world. At the end of the course, students should be comfortable developing simple electronic prototypes for future projects. Prerequisite(s): MATH 111.", 35, "Prof56", "T/TR 11:15 AM - 12:45 PM" }
                });

            migrationBuilder.InsertData(
                table: "Degree",
                columns: new[] { "DegreeId", "MajorName" },
                values: new object[] { 1, "Computer Science" });

            migrationBuilder.InsertData(
                table: "DegreeRequirements",
                columns: new[] { "DegreeRequirementId", "CourseCode", "CourseId", "DegreeId", "IsRequired", "Major", "SemesterSuggestion" },
                values: new object[,]
                {
                    { 1, "CS101", 1, 1, true, "Computer Science", 1 },
                    { 2, "CS400", 3, 1, true, "Computer Science", 2 },
                    { 3, "CS510", 4, 1, true, "Computer Science", 3 },
                    { 4, "CS211", 23, 1, true, "Computer Science", 4 },
                    { 5, "CS311", 25, 1, true, "Computer Science", 5 },
                    { 6, "CS410", 27, 1, true, "Computer Science", 6 },
                    { 7, "CS664", 28, 1, true, "Computer Science", 7 },
                    { 8, "CS580", 29, 1, true, "Computer Science", 8 },
                    { 9, "CS540", 30, 1, true, "Computer Science", 9 },
                    { 10, "CS560", 31, 1, true, "Computer Science", 10 },
                    { 11, "CS665", 32, 1, true, "Computer Science", 11 },
                    { 12, "CS356", 33, 1, true, "Computer Science", 12 },
                    { 13, "CS598", 34, 1, true, "Computer Science", 13 },
                    { 14, "CS599", 35, 1, true, "Computer Science", 14 }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "DegreeId", "Email", "FirstName", "LastName", "Major", "Password", "Username", "Year" },
                values: new object[] { 1, 1, "test@student.com", "Test Student", "Onetest Student", "Computer Science", "test123", "Tstudent", "Sophomore" });

            migrationBuilder.InsertData(
                table: "Enrollments",
                columns: new[] { "EnrollmentId", "CourseCode", "CourseId", "EnrollmentDate", "Grade", "StudentId" },
                values: new object[,]
                {
                    { 1, null, 1, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "A", 1 },
                    { 2, null, 3, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1 },
                    { 3, null, 4, new DateTime(2025, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "B+", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DegreeRequirements_CourseId",
                table: "DegreeRequirements",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_DegreeRequirements_DegreeId",
                table: "DegreeRequirements",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_CourseId",
                table: "Enrollments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Enrollments_StudentId",
                table: "Enrollments",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_CourseId",
                table: "StudentCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCourses_StudentId",
                table: "StudentCourses",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Students_DegreeId",
                table: "Students",
                column: "DegreeId");

            migrationBuilder.CreateIndex(
                name: "IX_Waitlists_CourseId",
                table: "Waitlists",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Waitlists_StudentId",
                table: "Waitlists",
                column: "StudentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeRequirements");

            migrationBuilder.DropTable(
                name: "Enrollments");

            migrationBuilder.DropTable(
                name: "StudentCourses");

            migrationBuilder.DropTable(
                name: "Waitlists");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Degree");
        }
    }
}
