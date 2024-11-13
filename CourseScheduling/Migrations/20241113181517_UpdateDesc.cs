using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDesc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "Description",
                value: "Into to Computer Science subjects.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                columns: new[] { "CourseCode", "Description" },
                values: new object[] { "MATH243", "General education math and natural sciences course. Analytic geometry and the calculus in an interrelated form. Students may receive credit for only one of these courses: MATH 144, 242 or 251. This is a Kansas Systemwide Transfer Course." });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3,
                column: "Description",
                value: "Introduces basic data structures and covers their implementations using classes in C++. Includes lists, stacks, queues, binary trees and hash tables.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4,
                column: "Description",
                value: "Theoretical concepts in the design and use of programming languages. Formal syntax, including Backus Normal Form (BNF), Extended Backus-Naur Form (EBNF), and syntax diagrams. Semantics, including declaration, allocation and evaluation, symbol table and runtime environment; data types and type checking, procedure activation and parameter passing, modules and abstract data types.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5,
                column: "Description",
                value: "A study of some of the basic topics of discrete mathematics, including elementary logic, properties of sets, mathematical induction, counting problems using permutations and combinations, trees, elementary probability, and an introduction to graph theory.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6,
                column: "Description",
                value: "Studies systems of formal logic including sentential and predicate logic. Emphasizes the uses of these systems in the analysis of arguments.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 7,
                column: "Description",
                value: "General education social and behavioral sciences course. Examines the component dimensions of health and the societal-level factors and lifestyle choices that influence health across the life span.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 8,
                column: "Description",
                value: "Social media is an essential part of today’s digital marketing mix and integral to a successful digital strategy. This course provides an introduction to social media marketing and lays the foundation for developing an effective social media campaign. Students learn what social media marketing entails, including the various platforms that exist, selecting the appropriate channels to fit their needs, setting goals and success metrics, and constructing social media strategies that achieve the desired marketing goals. Students also are introduced to quantitative and qualitative measurement tools to evaluate social media initiatives and assess their return on investment for an organization.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 9,
                column: "Description",
                value: "Choosing and executing the right strategy at the right time in the right way is the most important element of business success. This is a capstone course which integrates the functional areas of business, including management, marketing, finance, accounting and production. Students learn the tools to develop and implement strategies in organizations. Students are challenged through various projects, simulations and case studies to explore domestic and international policy issues, large and small firms, various sources of competitive advantage, and learn to effectively implement a successful strategy. For undergraduate credit only");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 10,
                column: "Description",
                value: "Focuses on progression of nursing skills.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 11,
                column: "Description",
                value: "General education math and natural sciences course. Cross-listed as GEOL 235. Introductory study of the atmosphere and its properties and the various phenomena of weather. Includes a brief survey of important principles of physical, dynamic, synoptic and applied meteorology. Does not apply toward a major or minor in geology. Requires field trips at the option of the instructor.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 12,
                column: "Description",
                value: "Assists engineering students in exploring engineering careers and opportunities. Provides information on academic and life skills essential to becoming a successful engineering student. Promotes connections to specific engineering majors and provides activities to assist and reinforce the decision to major in engineering.");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 13,
                columns: new[] { "CourseCode", "Description" },
                values: new object[] { "CHEM211", "General education math and natural sciences course. Introduces general concepts of chemistry. Includes chemical stoichiometry, atomic and molecular structure, bonding, gas laws, states of matter and chemical periodicity. CHEM 211-212 meets the needs of students who may wish to take more than one course in chemistry. Credit is allowed in only one of the following: CHEM 211 or 110. Course requires a lab fee. This is a Kansas Systemwide Transfer Course" });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 11, 13, 12, 15, 16, 917, DateTimeKind.Local).AddTicks(9061));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "CourseCode",
                value: "MATH201");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 13,
                column: "CourseCode",
                value: "CHEM221");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 11, 1, 16, 5, 39, 531, DateTimeKind.Local).AddTicks(1512));
        }
    }
}
