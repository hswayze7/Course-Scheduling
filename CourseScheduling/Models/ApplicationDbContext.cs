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

        public DbSet<Waitlist> Waitlists { get; set; }

        public DbSet<DegreeRequirement> DegreeRequirements { get; set; }

        public DbSet<CoursePrerequisite> CoursePrerequisites { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Course>().HasData(
                new Course { CourseId = 1, CourseCode = "CS101", CourseName = "Introduction to Computer Science", Credits = 3, Time = "M/W/F 10:00 AM - 12:00 PM", Professor = "Prof1", Description = "Into to Computer Science subjects.", MaxCapacity = 25, CurrentEnrollment = 2 },
                new Course { CourseId = 2, CourseCode = "MATH243", CourseName = "Calculus II", Credits = 4, Time = "T/TR 1:00 PM - 3:00 PM", Professor = "Prof2", Description = "General education math and natural sciences course. Analytic geometry and the calculus in an interrelated form. Students may receive credit for only one of these courses: MATH 144, 242 or 251. This is a Kansas Systemwide Transfer Course.", MaxCapacity = 25, CurrentEnrollment = 5 },
                new Course { CourseId = 3, CourseCode = "CS400", CourseName = "Data Structures", Credits = 4, Time = "T/TR 2:15 PM - 3:30 PM", Professor = "Prof3", Description = "Introduces basic data structures and covers their implementations using classes in C++. Includes lists, stacks, queues, binary trees and hash tables.", MaxCapacity = 35, CurrentEnrollment = 2 },
                new Course { CourseId = 4, CourseCode = "CS510", CourseName = "Programming Language Concepts", Credits = 3, Time = "T/TR 8:30 AM - 9:50 AM", Professor = "Prof13", Description = "Theoretical concepts in the design and use of programming languages. Formal syntax, including Backus Normal Form (BNF), Extended Backus-Naur Form (EBNF), and syntax diagrams. Semantics, including declaration, allocation and evaluation, symbol table and runtime environment; data types and type checking, procedure activation and parameter passing, modules and abstract data types.", MaxCapacity = 40, CurrentEnrollment = 15 },
                new Course { CourseId = 5, CourseCode = "MATH321", CourseName = "Discrete Structures I", Credits = 3, Time = "M/W/F 1:00 PM - 3:00 PM", Professor = "Prof4", Description = "A study of some of the basic topics of discrete mathematics, including elementary logic, properties of sets, mathematical induction, counting problems using permutations and combinations, trees, elementary probability, and an introduction to graph theory.", MaxCapacity = 25, CurrentEnrollment = 25 },
                new Course { CourseId = 6, CourseCode = "PSY325", CourseName = "Developmental Psychology", Credits = 3, Time = "M/T/F 12:30 PM - 1:45 PM", Professor = "Prof5", Description = "Studies systems of formal logic including sentential and predicate logic. Emphasizes the uses of these systems in the analysis of arguments.", MaxCapacity = 50, CurrentEnrollment = 25 },
                new Course { CourseId = 7, CourseCode = "SOC338", CourseName = "Health & Lifestyle", Credits = 3, Time = "M/W/F 2:15 PM - 3:30 PM", Professor = "Prof6", Description = "General education social and behavioral sciences course. Examines the component dimensions of health and the societal-level factors and lifestyle choices that influence health across the life span.", MaxCapacity = 30, CurrentEnrollment = 10 },
                new Course { CourseId = 8, CourseCode = "MKT690J", CourseName = "Social Media Marketing", Credits = 3, Time = "T/TR 9:30 AM - 10:45 AM", Professor = "Prof7", Description = "Social media is an essential part of today’s digital marketing mix and integral to a successful digital strategy. This course provides an introduction to social media marketing and lays the foundation for developing an effective social media campaign. Students learn what social media marketing entails, including the various platforms that exist, selecting the appropriate channels to fit their needs, setting goals and success metrics, and constructing social media strategies that achieve the desired marketing goals. Students also are introduced to quantitative and qualitative measurement tools to evaluate social media initiatives and assess their return on investment for an organization.", MaxCapacity = 20, CurrentEnrollment = 12 },
                new Course { CourseId = 9, CourseCode = "MGMT681", CourseName = "Strategic Management", Credits = 3, Time = "M/F/W 3:30 PM - 4:45 PM", Professor = "Prof8", Description = "Choosing and executing the right strategy at the right time in the right way is the most important element of business success. This is a capstone course which integrates the functional areas of business, including management, marketing, finance, accounting and production. Students learn the tools to develop and implement strategies in organizations. Students are challenged through various projects, simulations and case studies to explore domestic and international policy issues, large and small firms, various sources of competitive advantage, and learn to effectively implement a successful strategy. For undergraduate credit only", MaxCapacity = 15, CurrentEnrollment = 7 },
                new Course { CourseId = 10, CourseCode = "NURS362", CourseName = "Clinical Care Lab", Credits = 1, Time = "F 1:00 PM - 4:00 PM", Professor = "Prof9", Description = "Focuses on progression of nursing skills.", MaxCapacity = 25, CurrentEnrollment = 0 },
                new Course { CourseId = 11, CourseCode = "GEOG235", CourseName = "Meteorology", Credits = 3, Time = "M/W/F 2:15 PM - 3:30 PM", Professor = "Prof10", Description = "General education math and natural sciences course. Cross-listed as GEOL 235. Introductory study of the atmosphere and its properties and the various phenomena of weather. Includes a brief survey of important principles of physical, dynamic, synoptic and applied meteorology. Does not apply toward a major or minor in geology. Requires field trips at the option of the instructor.", MaxCapacity = 40, CurrentEnrollment = 25 },
                new Course { CourseId = 12, CourseCode = "ENGR101", CourseName = "Introduction to Engineering", Credits = 3, Time = "T/TR 11:15 AM - 12:25 PM", Professor = "Prof11", Description = "Assists engineering students in exploring engineering careers and opportunities. Provides information on academic and life skills essential to becoming a successful engineering student. Promotes connections to specific engineering majors and provides activities to assist and reinforce the decision to major in engineering.", MaxCapacity = 15, CurrentEnrollment = 9 },
                new Course { CourseId = 13, CourseCode = "CHEM211", CourseName = "General Chemistry I", Credits = 5, Time = "T/TR 4:30 PM - 6:00 PM", Professor = "Prof12", Description = "General education math and natural sciences course. Introduces general concepts of chemistry. Includes chemical stoichiometry, atomic and molecular structure, bonding, gas laws, states of matter and chemical periodicity. CHEM 211-212 meets the needs of students who may wish to take more than one course in chemistry. Credit is allowed in only one of the following: CHEM 211 or 110. Course requires a lab fee. This is a Kansas Systemwide Transfer Course", MaxCapacity = 25, CurrentEnrollment = 2 },
                new Course { CourseId = 14, CourseCode = "PHIL125", CourseName = "Introductory Logic", Credits = 3, Time = "M/W/F 10:30 AM - 11:45 AM", Professor = "Prof13", Description = "General education humanities course. Introduces students to the use of formal logic as a tool for understanding and evaluating patterns of reasoning. Focuses on deductive validity, logical equivalence and proving soundness. The formal systems introduced in this course are topic-neutral—i.e., they apply to patterns of reasoning on any topic. These formal systems are particularly useful for future studies in areas such as computer science, law, engineering and philosophy.", MaxCapacity = 25, CurrentEnrollment = 7 },
                new Course { CourseId = 15, CourseCode = "PHIL354", CourseName = "Ethics and Computers", Credits = 3, Time = "M/W/F 9:30 AM - 10:45 AM", Professor = "Prof14", Description = "General education humanities course. Ethics with application to the ethical issues which may arise from the use of computers, including the moral responsibility of computer professionals for the effect their work has on persons and society; the moral obligations of a computer professional to clients, employer and society; the conceptual and ethical issues surrounding the control and ownership of software; and the justifiability of regulation of the design, use and marketing of computer technology. Course includes diversity content. Prerequisite(s): junior standing or departmental consent.", MaxCapacity = 25, CurrentEnrollment = 5 },
                new Course { CourseId = 16, CourseCode = "MATH242", CourseName = "Calculus I", Credits = 5, Time = "M/W/F 5:45 PM - 7:15 PM", Professor = "Prof15", Description = "General education math and natural sciences course. Analytic geometry and the calculus in an interrelated form. Students may receive credit for only one of these courses: MATH 144, 242 or 251. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 112 with a C or better, or two units of high school algebra, one unit of high school geometry and one-half unit of high school trigonometry, or MATH 123 and 111 with a C or better in each.", MaxCapacity = 35, CurrentEnrollment = 17 },
                new Course { CourseId = 17, CourseCode = "PHYS314", CourseName = "Physics for Scientists II", Credits = 4, Time = "M/W/F 4:30 PM - 5:15 PM", Professor = "Prof16", Description = "General education math and natural sciences course. The second semester of a calculus-based physics sequence. Topics include electricity, magnetism, circuits, EM waves, light and selections from modern physics. Credit is only given for one of PHYS 214 or 314. Natural sciences majors are required to take the lab, PHYS 316, that accompanies this course. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 243 with a grade of C or better and PHYS 313.", MaxCapacity = 30, CurrentEnrollment = 15 },
                new Course { CourseId = 18, CourseCode = "PHYS316", CourseName = "University Physics Lab II", Credits = 1, Time = "T/TR 9:30 AM - 12:15 PM", Professor = "Prof17", Description = "General education math and natural sciences course. Lab experiments in electricity, magnetism and optics. Required for natural sciences majors taking PHYS 314. This is a Kansas Systemwide Transfer Course. Pre- or corequisite(s): PHYS 314.", MaxCapacity = 30, CurrentEnrollment = 15 },
                new Course { CourseId = 19, CourseCode = "MATH322", CourseName = "Discrete Structures II", Credits = 3, Time = "T/TR 9:30 AM - 11:15 AM", Professor = "Prof18", Description = "Cross-listed as CS 322. Continuation of Discrete Structures I. Includes relations, graphs, trees, Boolean algebra and automata. Prerequisite(s): MATH 321 or CS 321.", MaxCapacity = 25, CurrentEnrollment = 21 },
                new Course { CourseId = 20, CourseCode = "PHYS313", CourseName = "Physics for Scientists I", Credits = 4, Time = "M/W/F 8:30 AM - 10:45 AM", Professor = "Prof19", Description = "General education math and natural sciences course. The first semester of a calculus-based physics sequence. Topics include motion, forces, energy, fluids, oscillations, waves and thermodynamics. Natural sciences majors are required to take the lab, PHYS 315, that accompanies this course. Credit is given for only one of PHYS 213 or 313. This is a Kansas Systemwide Transfer Course. Pre- or Corequisite(s): MATH 243 with a grade of C or better.", MaxCapacity = 50, CurrentEnrollment = 21 },
                new Course { CourseId = 21, CourseCode = "IME254", CourseName = "Engineering Probability and Statistics I", Credits = 3, Time = "M/W/F 8:30 AM - 10:45 AM", Professor = "Prof20", Description = "Designed for undergraduate students majoring in engineering. It reviews graphical and numerical methods for summarizing and describing datasets, discusses basic concepts of probability, introduces discrete and continuous random variables, and presents statistical methods for making inferences about population parameters. Prerequisite(s): MATH 242.", MaxCapacity = 75, CurrentEnrollment = 57 },
                new Course { CourseId = 22, CourseCode = "ECE194", CourseName = "Introduction to Digital Design", Credits = 4, Time = "T/TR 8:30 AM - 9:45 AM", Professor = "Prof22", Description = "Introduces digital design concepts. Includes number systems, Boolean algebra, Karnaugh maps, combinational circuit design, adders, multiplexers, decoders, sequential circuit design, state diagram, flip flops, sequence detectors and test different combinational and sequential circuits. Uses CAD tools for circuit simulation. Prerequisite(s): MATH 111 or equivalent. Corequisite(s): ECE 194L.", MaxCapacity = 45, CurrentEnrollment = 40 },
                new Course { CourseId = 23, CourseCode = "CS211", CourseName = "Introduction to Programming", Credits = 4, Time = "T/TR 12:30 PM - 1:45 PM", Professor = "Prof23", Description = "First course in computer programming in a high-level language. Emphasizes analyzing problems, designing solutions and expressing them in the form of a well-structured program using the procedural aspects of C++. Prerequisite(s): MATH 111. Corequisite(s): CS 211L.", MaxCapacity = 50, CurrentEnrollment = 40 },
                new Course { CourseId = 24, CourseCode = "ECE238", CourseName = "Assesmbly Language Programming for Engineering", Credits = 3, Time = "T/TR 1:30 PM - 2:45 PM", Professor = "Prof24", Description = "Introduces basic concepts of computer organization and operation. Studies machine and assembly language programming concepts that illustrate basic principles and techniques. Laboratory exercises given for experience using personal computers. Prerequisite(s): CS 211.", MaxCapacity = 50, CurrentEnrollment = 27 },
                new Course { CourseId = 25, CourseCode = "CS311", CourseName = "Object-Oriented Programming", Credits = 4, Time = "T/TR 3:30 PM - 5:30 PM", Professor = "Prof25", Description = "Concepts of object-oriented programming. Covers data abstractions, classes and objects, methods, inheritance, polymorphism, dynamically-bound method calls and data encapsulation. Includes programming assignments in C++. Prerequisite(s): CS 211. Corequisite(s): CS 311L.", MaxCapacity = 30, CurrentEnrollment = 27 },
                new Course { CourseId = 26, CourseCode = "ECE394", CourseName = "Introduction to Computer Architecture", Credits = 3, Time = "T/TR 8:30 AM - 9:55 AM", Professor = "Prof26", Description = "Introduces multilevel approach to computer systems, with an emphasis on micro architecture and instruction set architecture levels. Also introduces techniques to improve performance such as cache memory and instruction level parallelism. Prerequisite(s): ECE 194 and CS 211.", MaxCapacity = 45, CurrentEnrollment = 27 },
                new Course { CourseId = 27, CourseCode = "CS410", CourseName = "Programming Paradigms", Credits = 3, Time = "T/TR 9:30 AM - 10:45 AM", Professor = "Prof27", Description = "Overview of different programming paradigms, including their philosophies, uses and relative advantages/disadvantages. Covers the procedural/imperative, functional, logic and object-oriented paradigms. Includes programming assignments in the functional and logic paradigms. Prerequisite(s): CS 311.", MaxCapacity = 50, CurrentEnrollment = 17 },
                new Course { CourseId = 28, CourseCode = "CS664", CourseName = "Computer Networks", Credits = 3, Time = "T/TR 4:45 PM - 5:45 PM", Professor = "Prof28", Description = "Introductory course on computer networking. Introduces concepts and protocols in various network layers with emphasis on the internet. Topics covered include: physical layer (wired and wireless), medium access control and data link layers, packet switching and routing (IP), routing protocols, transport layer (TCP, UDP), congestion and flow control, basic network security, and network applications. Prerequisite(s): undergraduate students: IME 254 and CS 311; graduate students: object oriented programming and statistics/probability knowledge.", MaxCapacity = 50, CurrentEnrollment = 10 },
                new Course { CourseId = 29, CourseCode = "CS580", CourseName = "Introduction to Software Engineering", Credits = 3, Time = "T/TR 10:45 AM - 12:05 PM", Professor = "Prof29", Description = "Introduces the processes, methods and tools used in software development and maintenance. Topics include software development life cycle and processes, configuration management, requirements gathering, OOA/D with UML, cohesion and coupling, and unit testing. Prerequisite(s): CS 311.", MaxCapacity = 50, CurrentEnrollment = 23 },
                new Course { CourseId = 30, CourseCode = "CS540", CourseName = "Operating Systems", Credits = 3, Time = "T/TR 10:45 AM - 12:15 PM", Professor = "Prof30", Description = "Fundamental principles of modern operating systems. CPU management including processes, threads, scheduling, synchronization, resource allocation and deadlocks. Memory management including paging and virtual memory. Storage management and file systems. Prerequisite(s): ECE 238 and CS 311.", MaxCapacity = 50, CurrentEnrollment = 45 },
                new Course { CourseId = 31, CourseCode = "CS560", CourseName = "Design and Analysis of Algorithms", Credits = 3, Time = "T/TR 12:30 PM - 1:45 PM", Professor = "Prof31", Description = "Design of various algorithms including several sorting algorithms. Analysis of their space and time complexities. Data structures include heaps, hash tables and binary search trees. Prerequisite(s): CS 322, 400; STAT 460 or IME 254.", MaxCapacity = 25, CurrentEnrollment = 17 },
                new Course { CourseId = 32, CourseCode = "CS665", CourseName = "Introduction to Database Systems", Credits = 3, Time = "T/TR 5:30 PM - 6:45 PM", Professor = "Prof32", Description = "Fundamental aspects of relational database systems, conceptual database design and entity-relationship modeling; the relational data model and its foundations, relational languages and SQL, functional dependencies and logical database design; views, constraints and triggers. Course includes a group project involving the design and implementation of a relational database and embedded SQL programming. Prerequisite(s): CS 311, MATH 322.", MaxCapacity = 75, CurrentEnrollment = 53 },
                new Course { CourseId = 33, CourseCode = "CS356", CourseName = "Introduction to Computer Security", Credits = 3, Time = "M/W 2:00 PM - 3:15 PM", Professor = "Prof33", Description = "Provides a first approach to the security mindset. Covers how adversaries exploit common software vulnerabilities such as buffer overflows and race conditions. Students learn secure coding techniques and countermeasures. Topics also include cryptography principles, web security, and legal and ethical aspects. Prerequisite(s): CS 211.", MaxCapacity = 50, CurrentEnrollment = 43 },
                new Course { CourseId = 34, CourseCode = "CS598", CourseName = "Senior Design Project I", Credits = 2, Time = "F 9:30 AM - 12:15 PM", Professor = "Prof34", Description = "Cross-listed as ECE 585. Design project under faculty supervision chosen according to the student's interest. Does not count toward a graduate degree in electrical engineering, computer engineering or computer science. This class should be taken in the semester prior to the one in which the student is going to graduate. For undergraduate credit only. Prerequisite(s): senior standing, ECE 492 or CS 580. Pre- or corequisite(s): PHIL 354 or PHIL 385.", MaxCapacity = 75, CurrentEnrollment = 43 },
                new Course { CourseId = 35, CourseCode = "CS599", CourseName = "Senior Design Project II", Credits = 2, Time = "F 2:00 PM - 5:45 PM", Professor = "Prof35", Description = "This is the second part of a sequence of two courses (CS 598 and CS 599) that have to be taken in two consecutive semesters. Students failing this course must retake the CS 598 course. For undergraduate credit only. Prerequisite(s): CS 598. Pre- or corequisite(s): PHYS 314 and PHYS 316.", MaxCapacity = 75, CurrentEnrollment = 43 },
                new Course { CourseId = 36, CourseCode = "PSY111", CourseName = "General Psychology", Credits = 3, Time = "M/W/F 1:45 PM - 3:15 PM", Professor = "Prof37", Description = "General education social and behavioral sciences course. Introduces the general principles and areas of psychology. Includes learning, perceiving, thinking, behavioral development, intelligence, personality and abnormalities of behavior. Course is a prerequisite for advanced and specialized courses in psychology. This is a Kansas Systemwide Transfer Course.", MaxCapacity = 50, CurrentEnrollment = 45 },
                new Course { CourseId = 37, CourseCode = "ECON201", CourseName = "Principles of Macroeconomics", Credits = 3, Time = "T/TR 1:45 PM - 3:15 PM", Professor = "Prof38", Description = "General education social and behavioral sciences course. Introduces economic concepts of scarcity, markets and prices. Emphasizes business cycles, recessions and recoveries, unemployment, inflation, monetary and fiscal policy. Discusses money and the banking system, the Federal Reserve, and trade and the impact of the global economy. This is a Kansas Systemwide Transfer Course.", MaxCapacity = 45, CurrentEnrollment = 30 },
                new Course { CourseId = 38, CourseCode = "MATH123", CourseName = "College Trigonometry", Credits = 3, Time = "M/W/F 12:30 PM - 1:55 PM", Professor = "Prof39", Description = "Studies the trigonometric functions and their applications. Credit in both MATH 123 and 112 is not allowed. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 111 with C or better or equivalent high school preparation and one unit of high school geometry.", MaxCapacity = 30, CurrentEnrollment = 4 },
                new Course { CourseId = 39, CourseCode = "PSY323", CourseName = "Social Psychology", Credits = 3, Time = "M/W/F 9:30 AM - 10:45 AM", Professor = "Prof40", Description = "General education social and behavioral sciences course. Studies perception of self, others and groups. Includes attitude formation and change, group processes like conformity, compliance and conflict, and interpersonal processes such as attraction and the formation of close relationships. Also includes the application of social psychological principles to the study of prosocial and aggressive behavior. Prerequisite(s): PSY 111.", MaxCapacity = 30, CurrentEnrollment = 8 },
                new Course { CourseId = 40, CourseCode = "PSY405", CourseName = "Human Factors Psychology", Credits = 3, Time = "T/TH 9:45 AM - 11:00 AM", Professor = "Prof41", Description = "The study of how people respond to the demands of complex machines and the varied environments of workplace, home and other settings. Introduces the tools and methods of machine, task and environment design to achieve the matching of human capabilities and the demands of machines and environments so as to enhance human performance and well being. Prerequisite(s): PSY 111.", MaxCapacity = 45, CurrentEnrollment = 30 },
                new Course { CourseId = 41, CourseCode = "STAT370", CourseName = "Elementary Statistics", Credits = 3, Time = "M/W/F 1:45 PM - 3:15 PM", Professor = "Prof42", Description = "General education math and natural sciences course. Surveys elementary descriptive statistics, binomial and normal distributions, elementary problems of statistical inference, linear correlation and regression. Not open to mathematics majors. Students cannot receive credit for both STAT 171 and STAT 370. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 111 with a C or better or equivalent.", MaxCapacity = 30, CurrentEnrollment = 17 },
                new Course { CourseId = 42, CourseCode = "AC121", CourseName = "Cybersecurity Awareness", Credits = 3, Time = "T/TR 8:30 AM - 10:00 AM", Professor = "Prof43", Description = "The ability to secure information and systems within a modern enterprise in this modern globalized environment is a growing challenge. Ever-present human threats are global, persistent and increasingly sophisticated. Natural threats are unpredictable but inevitable. Vulnerabilities within the complex and interdependent system of systems continue to be discovered with many more yet to become common knowledge. Exploited vulnerabilities can have a devastating impact on an organization or even a society. This course is designed to familiarize users with information, cyberspace and security principles needed to understand these threats. To this end, the course addresses a range of topics, including information infrastructures, social engineering, information system exploitation techniques and countermeasures to the threats discussed. Pre- or corequisite(s): PHIL 125 or PHIL 105.", MaxCapacity = 30, CurrentEnrollment = 30 },
                new Course { CourseId = 43, CourseCode = "AC201", CourseName = "Introductory Design Project", Credits = 1, Time = "M/W/F 4:15 PM - 5:45 PM", Professor = "Prof44", Description = "The first of the three-course project design series. The course introduces students to project design, prototyping, engineering standards and professional reports. Students are part of teams, learn prototyping skills and have hands on experiences in a maker-space. Students learn project management tools, team working tools, how to perform market research and develop videos, and prototype development. Prerequisite(s): FYET 102A, FYET 102B, ENGR 302, ID 300 or instructor's consent.", MaxCapacity = 30, CurrentEnrollment = 2 },
                new Course { CourseId = 44, CourseCode = "AC222", CourseName = "Applied Computing Fundamentals", Credits = 3, Time = "M/W/F 11:45 AM - 1:20 PM", Professor = "Prof45", Description = "Information technology (IT) virtually connects people and businesses in the world. The daily operations of every organization in the public and private sector heavily rely on the internet. This course allows students to gain vital concepts on computer hardware, computer systems, networking and security to solve real-world computing challenges. This course is a key for anyone who wants to gain basic skills in the computing sector. Students collaborate effectively and think critically to develop skills in computing and networking. Students learn to use industry-standard tools through hands-on class projects.", MaxCapacity = 30, CurrentEnrollment = 12 },
                new Course { CourseId = 45, CourseCode = "AC301", CourseName = "Junior Project", Credits = 2, Time = "M/W/F 1:45 PM - 3:15 PM", Professor = "Prof46", Description = "Second course in four-course project sequence. Introduces students to engineering design concepts with an entrepreneurial mindset. This includes customer discovery and value creation techniques as well as engineering design and project management tools. Prerequisite(s): AC 201 or ENGR 205 or instructor's consent.", MaxCapacity = 50, CurrentEnrollment = 30 },
                new Course { CourseId = 46, CourseCode = "AC321", CourseName = "Applied Networking", Credits = 3, Time = "M/W/F 3:45 PM - 5:15 PM", Professor = "Prof47", Description = "Information technology (IT) virtually connects people and businesses in the world. The daily operations of every organization in the public and private sector heavily rely on the internet. This course allows students to gain vital concepts on computer networking and security to solve real-world computing challenges. This course is a key for anyone who wants to gain advanced skills in the computing sector. Students collaborate effectively and think critically to develop skills in computer networking. Students learn to use industry-standard tools through hands-on class projects.", MaxCapacity = 30, CurrentEnrollment = 22 },
                new Course { CourseId = 47, CourseCode = "AC322", CourseName = "Applied Programming and Scripting", Credits = 3, Time = "F 1:45 PM - 3:15 PM", Professor = "Prof48", Description = "Good scripting skills are vital to IT experts in the fields of information security. This course is designed for cybersecurity professionals who are interested in learning basic coding skills to perform the cybersecurity tasks more efficiently. The course assists students in taking their cybersecurity career to the next level by teaching the vital skills needed to develop as well as customize applications that interact with file systems, databases, networks and websites. Covers command shell scripting (cmd, powershell, bash) in Windows and Linux operating systems. Emphasizes scripting cybersecurity tasks such as system configuration, system auditing and penetration testing. Also covers Arduino microcontrollers, coding Arduino in Python and coding TCP Traceroute. Python language is used in this course. Prerequisite(s): AC 222 or MIS 325.", MaxCapacity = 30, CurrentEnrollment = 21 },
                new Course { CourseId = 48, CourseCode = "AC324", CourseName = "Applied Web Applications and Database Development", Credits = 3, Time = "F 12:45 PM - 2:15 PM", Professor = "Prof49", Description = "When browsing on a web application, look for two things: how user-friendly the web app is and how the information is stored, controlled and used. Each web application has a set of requirements such as financial transaction, customer information, etc. The course covers web and database technologies, services, protocols, design and operation. Students learn a variety of languages including HTML, CSS, Apache and MySQL. Course is designed to apply the languages through hands-on projects. Prerequisite(s): AC 222 or MIS 325 or CS 664. Pre- or corequisite(s): ECON 201 or IME 255.", MaxCapacity = 30, CurrentEnrollment = 14 },
                new Course { CourseId = 49, CourseCode = "AC326", CourseName = "Cyber Operations", Credits = 3, Time = "M/W/F 1:45 PM - 3:15 PM", Professor = "Prof50", Description = "Covers concepts related to cyber attack, penetration testing, cyber intelligence, cryptography and cyber defense. Students learn the attacker's perspective and how security infrastructure integrates with the rest of the business and IT infrastructure through the use of hands-on projects. Prerequisite(s): AC 121, AC 222, AC 321 and AC 322 .", MaxCapacity = 30, CurrentEnrollment = 1 },
                new Course { CourseId = 50, CourseCode = "AC352", CourseName = "Competitive Ethical Hacking", Credits = 3, Time = "M/W/F 1:45 PM - 3:15 PM", Professor = "Prof51", Description = "Kevin Mitnick, who popularized the term “social engineering,” explained that it is much easier to trick someone into revealing a password for a system than to exert the effort of hacking into the system. Mitnick claims that this social engineering tactic was the single-most effective method in his arsenal. This course covers human threats to cybersecurity in political, social and economic contexts. It includes targeted exploitation/manipulation of individuals, small groups and larger groups through social engineering, marketing, propaganda, psychological operations by personal contact, email, social networking, web and RF transmission. Prerequisite(s): AC 121 .", MaxCapacity = 25, CurrentEnrollment = 9 },
                new Course { CourseId = 51, CourseCode = "AC363", CourseName = "Human Threats to Cybersecurity", Credits = 3, Time = "T/TR 2:45 PM - 4:15 PM", Professor = "Prof52", Description = "Cross-listed as CS 352. Presents fundamental concepts of competitive ethical hacking in computer and network security. The course introduces the command line interface, open-source intelligence, cryptography, digital forensics, web application security, software reverse engineering, secure programming and log analysis. Assignments include participating in capture the flag competitions. Prerequisite(s): CS 211 or (AC 121 and AC 322).", MaxCapacity = 30, CurrentEnrollment = 9 },
                new Course { CourseId = 52, CourseCode = "AC401", CourseName = "Senior Project I", Credits = 3, Time = "F 1:45 PM - 4:15 PM", Professor = "Prof53", Description = "The third of the four-course project design series. In this intermediate course, students learn the importance of the voice of the customer, the customer/product market fit through using the business model canvas, and engineering design tools. Students learn and practice customer interview techniques and, through the feedback, help to develop appropriate solutions and prototypes. Students perform individual observations to discover unmet needs in industry and, after refining the needs, teams form to solve these needs. Comprehensively covers the student’s concentration in applied computing and its applications. Students work with faculty and external consultants and industry to refine their team based senior project. Prerequisite(s): AC 301 and PHYS 213. Pre- or corequisite(s): PHIL 354.", MaxCapacity = 75, CurrentEnrollment = 39 },
                new Course { CourseId = 53, CourseCode = "AC402", CourseName = "Senior Project II", Credits = 3, Time = "F 1:45 PM - 4:15 PM", Professor = "Prof54", Description = "Comprehensively covers the student’s concentration in applied computing and its applications. Students continue to work in their teams with faculty and external consultants and industry to refine and develop a final solution for their team based senior project. Prerequisite(s): AC 401.", MaxCapacity = 75, CurrentEnrollment = 27 },
                new Course { CourseId = 54, CourseCode = "AC461", CourseName = "Digital Forensics", Credits = 3, Time = "M/W/F 9:30 AM - 11:15 AM", Professor = "Prof55", Description = "Covers concepts related to hardware and software forensics, incident response, cyber crime and cyber law enforcement. Students learn different aspects of computer and cyber crime and ways to uncover, protect, exploit and document digital evidence. Students are exposed to different types of tools (both software and hardware), techniques and procedures, and are able to use them to perform rudimentary forensic investigations. Focuses on the entire life cycle of incident response including preparation, data collection, data analysis and remediation. Real world case studies reveal the methods behind and remediation strategies for today's most insidious attacks. Prerequisite(s): AC 326 .", MaxCapacity = 30, CurrentEnrollment = 20 },
                new Course { CourseId = 55, CourseCode = "AC462", CourseName = "Cyber Physical Systems", Credits = 4, Time = "M/W/F 11:15 AM - 12:45 PM", Professor = "Prof56", Description = "Focuses on trustworthy and resilient CPS, starting with NIST's CPS Framework. Students learn about common IoT infrastructures, integrate CPS into organizational risk management, and conduct cybersecurity risk assessments for critical cyber physical systems. Prerequisite(s): ENGR 220 and AC 326, or instructor’s consent.", MaxCapacity = 35, CurrentEnrollment = 15 },
                new Course { CourseId = 56, CourseCode = "AC463", CourseName = "Cyber Risk Management", Credits = 3, Time = "M/W/F 10:45 AM - 12:45 PM", Professor = "Prof57", Description = "This course covers application of risk and information security management to improve organizational resilience. Concepts include business impact analysis, incident response planning, disaster recovery planning, business continuity planning and security auditing. Prerequisite(s): AC 326.", MaxCapacity = 35, CurrentEnrollment = 16 },
                new Course { CourseId = 57, CourseCode = "AC464", CourseName = "Web Application Security", Credits = 3, Time = "M/W/F 11:15 AM - 12:45 PM", Professor = "Prof58", Description = "Develops an understanding of common web-based vulnerabilities and their impacts. Concepts include development and management of secure web-based systems, security mitigation strategies and penetration testing. Prerequisite(s): AC 324 and AC 326 .", MaxCapacity = 35, CurrentEnrollment = 21 },
                new Course { CourseId = 58, CourseCode = "ENGR220", CourseName = "Applied Analog and Digital Electronics", Credits = 3, Time = "T/TR 11:15 AM - 12:45 PM", Professor = "Prof59", Description = "Provides a fundamental understanding of electronics and programming through content and active learning. Introduces basic electronic components and principles, sensors, actuators and electronic diagnostic tools. Builds confidence and creativity by designing, constructing and debugging circuits as well as programming a micro-controller to perform desired tasks. Introduces students to semiconductors and integrated circuits such as op-amps, combinational logic circuits and flip-flops. Students learn methods to interact with the physical world. At the end of the course, students should be comfortable developing simple electronic prototypes for future projects. Prerequisite(s): MATH 111.", MaxCapacity = 35, CurrentEnrollment = 14 },
                new Course { CourseId = 59, CourseCode = "MATH511", CourseName = "Linear Algebra", Credits = 3, Time = "T/TR 12:30 PM - 1:45 PM", Professor = "Prof60", Description = "An elementary study of linear algebra, including an examination of linear transformations and matrices over finite dimensional spaces. Prerequisite(s): MATH 243 with a grade point of 2.000 or better.", MaxCapacity = 45, CurrentEnrollment = 38 }





            );

            modelBuilder.Entity<DegreeRequirement>().HasData(
                    new DegreeRequirement { DegreeRequirementId = 1, DegreeId = 1, Major = "Computer Science", CourseId = 1, CourseCode = "CS101", IsRequired = true, SemesterSuggestion = 1 },
                    new DegreeRequirement { DegreeRequirementId = 2, DegreeId = 1, Major = "Computer Science", CourseId = 3, CourseCode = "CS400", IsRequired = true, SemesterSuggestion = 2 },
                    new DegreeRequirement { DegreeRequirementId = 3, DegreeId = 1, Major = "Computer Science", CourseId = 4, CourseCode = "CS510", IsRequired = true, SemesterSuggestion = 3 },
                    new DegreeRequirement { DegreeRequirementId = 4, DegreeId = 1, Major = "Computer Science", CourseId = 23, CourseCode = "CS211", IsRequired = true, SemesterSuggestion = 4 },
                    new DegreeRequirement { DegreeRequirementId = 5, DegreeId = 1, Major = "Computer Science", CourseId = 25, CourseCode = "CS311", IsRequired = true, SemesterSuggestion = 5 },
                    new DegreeRequirement { DegreeRequirementId = 6, DegreeId = 1, Major = "Computer Science", CourseId = 27, CourseCode = "CS410", IsRequired = true, SemesterSuggestion = 6 },
                    new DegreeRequirement { DegreeRequirementId = 7, DegreeId = 1, Major = "Computer Science", CourseId = 28, CourseCode = "CS664", IsRequired = true, SemesterSuggestion = 7 },
                    new DegreeRequirement { DegreeRequirementId = 8, DegreeId = 1, Major = "Computer Science", CourseId = 29, CourseCode = "CS580", IsRequired = true, SemesterSuggestion = 8 },
                    new DegreeRequirement { DegreeRequirementId = 9, DegreeId = 1, Major = "Computer Science", CourseId = 30, CourseCode = "CS540", IsRequired = true, SemesterSuggestion = 9 },
                    new DegreeRequirement { DegreeRequirementId = 10, DegreeId = 1, Major = "Computer Science", CourseId = 31, CourseCode = "CS560", IsRequired = true, SemesterSuggestion = 10 },
                    new DegreeRequirement { DegreeRequirementId = 11, DegreeId = 1, Major = "Computer Science", CourseId = 32, CourseCode = "CS665", IsRequired = true, SemesterSuggestion = 11 },
                    new DegreeRequirement { DegreeRequirementId = 12, DegreeId = 1, Major = "Computer Science", CourseId = 33, CourseCode = "CS356", IsRequired = true, SemesterSuggestion = 12 },
                    new DegreeRequirement { DegreeRequirementId = 13, DegreeId = 1, Major = "Computer Science", CourseId = 34, CourseCode = "CS598", IsRequired = true, SemesterSuggestion = 13 },
                    new DegreeRequirement { DegreeRequirementId = 14, DegreeId = 1, Major = "Computer Science", CourseId = 35, CourseCode = "CS599", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 15, DegreeId = 1, Major = "Computer Science", CourseId = 2, CourseCode = "MATH243", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 16, DegreeId = 1, Major = "Computer Science", CourseId = 5, CourseCode = "MATH321", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 17, DegreeId = 1, Major = "Computer Science", CourseId = 16, CourseCode = "MATH242", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 18, DegreeId = 1, Major = "Computer Science", CourseId = 14, CourseCode = "PHIL125", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 19, DegreeId = 1, Major = "Computer Science", CourseId = 17, CourseCode = "PHYS314", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 20, DegreeId = 1, Major = "Computer Science", CourseId = 18, CourseCode = "PHYS316", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 21, DegreeId = 1, Major = "Computer Science", CourseId = 20, CourseCode = "PHYS313", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 22, DegreeId = 1, Major = "Computer Science", CourseId = 15, CourseCode = "PHIL354", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 23, DegreeId = 1, Major = "Computer Science", CourseId = 19, CourseCode = "MATH322", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 24, DegreeId = 1, Major = "Computer Science", CourseId = 59, CourseCode = "MATH511", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 25, DegreeId = 1, Major = "Computer Science", CourseId = 21, CourseCode = "IME254", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 26, DegreeId = 1, Major = "Computer Science", CourseId = 22, CourseCode = "ECE194", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 27, DegreeId = 1, Major = "Computer Science", CourseId = 24, CourseCode = "ECE238", IsRequired = true, SemesterSuggestion = 14 },
                    new DegreeRequirement { DegreeRequirementId = 28, DegreeId = 1, Major = "Computer Science", CourseId = 26, CourseCode = "ECE394", IsRequired = true, SemesterSuggestion = 14 }
            );

            modelBuilder.Entity<Degree>().HasData(
                new Degree { DegreeId = 1, MajorName = "Computer Science" }
            );



            modelBuilder.Entity<Student>().HasData(
               new Student
               {
                   StudentId = 1,  // Set a unique ID for the student
                   Username = "Tstudent",
                   FirstName = "Test Student",
                   LastName = "Onetest Student",
                   Email = "test@student.com",
                   Password = "test123",  
                   Major = "Computer Science",
                   Year = "Sophomore",
                   DegreeId = 1
               }
           );

            modelBuilder.Entity<Enrollment>().HasData(
            new Enrollment
                {
                    EnrollmentId = 1,
                    CourseId = 1,
                    StudentId = 1,
                EnrollmentDate = new DateTime(2025, 5, 7),
                    Grade = "A" 
                },
            new Enrollment
                {
                    EnrollmentId = 2,
                    CourseId = 3,
                    StudentId = 1,
                    EnrollmentDate = new DateTime(2025, 5, 7),
                    Grade = null 
                },
            new Enrollment
                {
                    EnrollmentId = 3,
                    CourseId = 4,
                    StudentId = 1,
                    EnrollmentDate = new DateTime(2025, 5, 7),
                    Grade = "B+" 
            },
            new Enrollment
            {
                EnrollmentId = 4, 
                CourseId = 16,    // MATH242 (Calculus I)
                StudentId = 1,
                EnrollmentDate = new DateTime(2024, 8, 20), 
                Grade = "B+"     // indicate completion
            }
            );

            modelBuilder.Entity<CoursePrerequisite>().HasData(
                 new CoursePrerequisite
                  {
                        CoursePrerequisiteId = 1,
                        CourseId = 2,                // MATH243 - Calculus II
                        PrerequisiteCourseId = 16    // MATH242 - Calculus I
                  },
                 new CoursePrerequisite
                  {
                        CoursePrerequisiteId = 2,
                        CourseId = 17,               // PHYS314 - Physics II
                        PrerequisiteCourseId = 20    // PHYS313 - Physics I
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

        

            // Define relationships
            modelBuilder.Entity<Waitlist>()
                .HasOne(w => w.Course)
                .WithMany(c => c.Waitlists)
                .HasForeignKey(w => w.CourseId);

            modelBuilder.Entity<Waitlist>()
                .HasOne(w => w.Student)
                .WithMany()
                .HasForeignKey(w => w.StudentId);


            modelBuilder.Entity<CoursePrerequisite>()
                .HasKey(cp => new { cp.CourseId, cp.PrerequisiteCourseId });

            modelBuilder.Entity<CoursePrerequisite>()
                .HasOne(cp => cp.Course)
                .WithMany(c => c.Prerequisites)
                .HasForeignKey(cp => cp.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CoursePrerequisite>()
                .HasOne(cp => cp.PrerequisiteCourse)
                .WithMany()
                .HasForeignKey(cp => cp.PrerequisiteCourseId)
                .OnDelete(DeleteBehavior.Restrict);

        }





    }



}
