using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class AdditionOfClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 36,
                columns: new[] { "CourseCode", "CourseName", "CurrentEnrollment", "Description", "MaxCapacity", "Professor" },
                values: new object[] { "PSY111", "General Psychology", 45, "General education social and behavioral sciences course. Introduces the general principles and areas of psychology. Includes learning, perceiving, thinking, behavioral development, intelligence, personality and abnormalities of behavior. Course is a prerequisite for advanced and specialized courses in psychology. This is a Kansas Systemwide Transfer Course.", 14, "Prof37" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseCode", "CourseName", "Credits", "CurrentEnrollment", "Description", "MaxCapacity", "Professor", "Time" },
                values: new object[,]
                {
                    { 37, "ECON201", "Principles of Macroeconomics", 3, 30, "General education social and behavioral sciences course. Introduces economic concepts of scarcity, markets and prices. Emphasizes business cycles, recessions and recoveries, unemployment, inflation, monetary and fiscal policy. Discusses money and the banking system, the Federal Reserve, and trade and the impact of the global economy. This is a Kansas Systemwide Transfer Course.", 25, "Prof38", "T/TR 1:45 PM - 3:15 PM" },
                    { 38, "MATH123", "College Trigonometry", 3, 30, "Studies the trigonometric functions and their applications. Credit in both MATH 123 and 112 is not allowed. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 111 with C or better or equivalent high school preparation and one unit of high school geometry.", 4, "Prof39", "M/W/F 12:30 PM - 1:55 PM" },
                    { 39, "PSY323", "Social Psychology", 3, 30, "General education social and behavioral sciences course. Studies perception of self, others and groups. Includes attitude formation and change, group processes like conformity, compliance and conflict, and interpersonal processes such as attraction and the formation of close relationships. Also includes the application of social psychological principles to the study of prosocial and aggressive behavior. Prerequisite(s): PSY 111.", 8, "Prof40", "M/W/F 9:30 AM - 10:45 AM" },
                    { 40, "PSY405", "Human Factors Psychology", 3, 30, "The study of how people respond to the demands of complex machines and the varied environments of workplace, home and other settings. Introduces the tools and methods of machine, task and environment design to achieve the matching of human capabilities and the demands of machines and environments so as to enhance human performance and well being. Prerequisite(s): PSY 111.", 10, "Prof41", "T/TH 9:45 AM - 11:00 AM" },
                    { 41, "STAT370", "Elementary Statistics", 3, 30, "General education math and natural sciences course. Surveys elementary descriptive statistics, binomial and normal distributions, elementary problems of statistical inference, linear correlation and regression. Not open to mathematics majors. Students cannot receive credit for both STAT 171 and STAT 370. This is a Kansas Systemwide Transfer Course. Prerequisite(s): MATH 111 with a C or better or equivalent.", 17, "Prof42", "M/W/F 1:45 PM - 3:15 PM" },
                    { 42, "AC121", "Cybersecurity Awareness", 3, 30, "The ability to secure information and systems within a modern enterprise in this modern globalized environment is a growing challenge. Ever-present human threats are global, persistent and increasingly sophisticated. Natural threats are unpredictable but inevitable. Vulnerabilities within the complex and interdependent system of systems continue to be discovered with many more yet to become common knowledge. Exploited vulnerabilities can have a devastating impact on an organization or even a society. This course is designed to familiarize users with information, cyberspace and security principles needed to understand these threats. To this end, the course addresses a range of topics, including information infrastructures, social engineering, information system exploitation techniques and countermeasures to the threats discussed. Pre- or corequisite(s): PHIL 125 or PHIL 105.", 30, "Prof43", "T/TR 8:30 AM - 10:00 AM" },
                    { 43, "AC201", "Introductory Design Project", 1, 30, "The first of the three-course project design series. The course introduces students to project design, prototyping, engineering standards and professional reports. Students are part of teams, learn prototyping skills and have hands on experiences in a maker-space. Students learn project management tools, team working tools, how to perform market research and develop videos, and prototype development. Prerequisite(s): FYET 102A, FYET 102B, ENGR 302, ID 300 or instructor's consent.", 2, "Prof44", "M/W/F 4:15 PM - 5:45 PM" },
                    { 44, "AC222", "Applied Computing Fundamentals", 3, 30, "Information technology (IT) virtually connects people and businesses in the world. The daily operations of every organization in the public and private sector heavily rely on the internet. This course allows students to gain vital concepts on computer hardware, computer systems, networking and security to solve real-world computing challenges. This course is a key for anyone who wants to gain basic skills in the computing sector. Students collaborate effectively and think critically to develop skills in computing and networking. Students learn to use industry-standard tools through hands-on class projects.", 12, "Prof45", "M/W/F 11:45 AM - 1:20 PM" },
                    { 45, "AC301", "Junior Project", 2, 30, "Second course in four-course project sequence. Introduces students to engineering design concepts with an entrepreneurial mindset. This includes customer discovery and value creation techniques as well as engineering design and project management tools. Prerequisite(s): AC 201 or ENGR 205 or instructor's consent.", 18, "Prof46", "M/W/F 1:45 PM - 3:15 PM" },
                    { 46, "AC321", "Applied Networking", 3, 30, "Information technology (IT) virtually connects people and businesses in the world. The daily operations of every organization in the public and private sector heavily rely on the internet. This course allows students to gain vital concepts on computer networking and security to solve real-world computing challenges. This course is a key for anyone who wants to gain advanced skills in the computing sector. Students collaborate effectively and think critically to develop skills in computer networking. Students learn to use industry-standard tools through hands-on class projects.", 22, "Prof47", "M/W/F 3:45 PM - 5:15 PM" },
                    { 47, "AC322", "Applied Programming and Scripting", 3, 30, "Good scripting skills are vital to IT experts in the fields of information security. This course is designed for cybersecurity professionals who are interested in learning basic coding skills to perform the cybersecurity tasks more efficiently. The course assists students in taking their cybersecurity career to the next level by teaching the vital skills needed to develop as well as customize applications that interact with file systems, databases, networks and websites. Covers command shell scripting (cmd, powershell, bash) in Windows and Linux operating systems. Emphasizes scripting cybersecurity tasks such as system configuration, system auditing and penetration testing. Also covers Arduino microcontrollers, coding Arduino in Python and coding TCP Traceroute. Python language is used in this course. Prerequisite(s): AC 222 or MIS 325.", 21, "Prof48", "F 1:45 PM - 3:15 PM" },
                    { 48, "AC324", "Applied Web Applications and Database Development", 3, 30, "When browsing on a web application, look for two things: how user-friendly the web app is and how the information is stored, controlled and used. Each web application has a set of requirements such as financial transaction, customer information, etc. The course covers web and database technologies, services, protocols, design and operation. Students learn a variety of languages including HTML, CSS, Apache and MySQL. Course is designed to apply the languages through hands-on projects. Prerequisite(s): AC 222 or MIS 325 or CS 664. Pre- or corequisite(s): ECON 201 or IME 255.", 14, "Prof49", "F 12:45 PM - 2:15 PM" },
                    { 49, "AC326", "Cyber Operations", 3, 30, "Covers concepts related to cyber attack, penetration testing, cyber intelligence, cryptography and cyber defense. Students learn the attacker's perspective and how security infrastructure integrates with the rest of the business and IT infrastructure through the use of hands-on projects. Prerequisite(s): AC 121, AC 222, AC 321 and AC 322 .", 15, "Prof50", "M/W/F 1:45 PM - 3:15 PM" },
                    { 50, "AC352", "Competitive Ethical Hacking", 3, 25, "Kevin Mitnick, who popularized the term “social engineering,” explained that it is much easier to trick someone into revealing a password for a system than to exert the effort of hacking into the system. Mitnick claims that this social engineering tactic was the single-most effective method in his arsenal. This course covers human threats to cybersecurity in political, social and economic contexts. It includes targeted exploitation/manipulation of individuals, small groups and larger groups through social engineering, marketing, propaganda, psychological operations by personal contact, email, social networking, web and RF transmission. Prerequisite(s): AC 121 .", 9, "Prof51", "M/W/F 1:45 PM - 3:15 PM" },
                    { 51, "AC363", "Human Threats to Cybersecurity", 3, 30, "Cross-listed as CS 352. Presents fundamental concepts of competitive ethical hacking in computer and network security. The course introduces the command line interface, open-source intelligence, cryptography, digital forensics, web application security, software reverse engineering, secure programming and log analysis. Assignments include participating in capture the flag competitions. Prerequisite(s): CS 211 or (AC 121 and AC 322).", 9, "Prof52", "T/TR 2:45 PM - 4:15 PM" },
                    { 52, "AC401", "Senior Project I", 3, 75, "The third of the four-course project design series. In this intermediate course, students learn the importance of the voice of the customer, the customer/product market fit through using the business model canvas, and engineering design tools. Students learn and practice customer interview techniques and, through the feedback, help to develop appropriate solutions and prototypes. Students perform individual observations to discover unmet needs in industry and, after refining the needs, teams form to solve these needs. Comprehensively covers the student’s concentration in applied computing and its applications. Students work with faculty and external consultants and industry to refine their team based senior project. Prerequisite(s): AC 301 and PHYS 213. Pre- or corequisite(s): PHIL 354.", 39, "Prof53", "F 1:45 PM - 4:15 PM" },
                    { 53, "AC402", "Senior Project II", 3, 75, "Comprehensively covers the student’s concentration in applied computing and its applications. Students continue to work in their teams with faculty and external consultants and industry to refine and develop a final solution for their team based senior project. Prerequisite(s): AC 401.", 27, "Prof54", "F 1:45 PM - 4:15 PM" },
                    { 54, "AC461", "Digital Forensics", 3, 30, "Covers concepts related to hardware and software forensics, incident response, cyber crime and cyber law enforcement. Students learn different aspects of computer and cyber crime and ways to uncover, protect, exploit and document digital evidence. Students are exposed to different types of tools (both software and hardware), techniques and procedures, and are able to use them to perform rudimentary forensic investigations. Focuses on the entire life cycle of incident response including preparation, data collection, data analysis and remediation. Real world case studies reveal the methods behind and remediation strategies for today's most insidious attacks. Prerequisite(s): AC 326 .", 12, "Prof55", "M/W/F 9:30 AM - 11:15 AM" },
                    { 55, "AC462", "Cyber Physical Systems", 4, 35, "Focuses on trustworthy and resilient CPS, starting with NIST's CPS Framework. Students learn about common IoT infrastructures, integrate CPS into organizational risk management, and conduct cybersecurity risk assessments for critical cyber physical systems. Prerequisite(s): ENGR 220 and AC 326, or instructor’s consent.", 16, "Prof56", "M/W/F 11:15 AM - 12:45 PM" },
                    { 56, "AC463", "Cyber Risk Management", 3, 35, "This course covers application of risk and information security management to improve organizational resilience. Concepts include business impact analysis, incident response planning, disaster recovery planning, business continuity planning and security auditing. Prerequisite(s): AC 326.", 16, "Prof56", "M/W/F 10:45 AM - 12:45 PM" },
                    { 57, "AC464", "Web Application Security", 3, 35, "Develops an understanding of common web-based vulnerabilities and their impacts. Concepts include development and management of secure web-based systems, security mitigation strategies and penetration testing. Prerequisite(s): AC 324 and AC 326 .", 21, "Prof56", "M/W/F 11:15 AM - 12:45 PM" },
                    { 58, "ENGR220", "Applied Analog and Digital Electronics", 3, 35, "Provides a fundamental understanding of electronics and programming through content and active learning. Introduces basic electronic components and principles, sensors, actuators and electronic diagnostic tools. Builds confidence and creativity by designing, constructing and debugging circuits as well as programming a micro-controller to perform desired tasks. Introduces students to semiconductors and integrated circuits such as op-amps, combinational logic circuits and flip-flops. Students learn methods to interact with the physical world. At the end of the course, students should be comfortable developing simple electronic prototypes for future projects. Prerequisite(s): MATH 111.", 14, "Prof56", "T/TR 11:15 AM - 12:45 PM" }
                });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 2, 27, 19, 17, 7, 480, DateTimeKind.Local).AddTicks(1333));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 58);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 36,
                columns: new[] { "CourseCode", "CourseName", "CurrentEnrollment", "Description", "MaxCapacity", "Professor" },
                values: new object[] { "MATH511", "Linear Algebra", 30, "An elementary study of linear algebra, including an examination of linear transformations and matrices over finite dimensional spaces. Prerequisite(s): MATH 243 with a grade point of 2.000 or better.", 35, "Prof36" });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 12, 5, 12, 59, 13, 575, DateTimeKind.Local).AddTicks(1183));
        }
    }
}
