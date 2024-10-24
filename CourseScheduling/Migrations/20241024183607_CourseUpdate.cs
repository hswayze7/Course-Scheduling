using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class CourseUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseCode", "CourseName", "Credits", "Time" },
                values: new object[,]
                {
                    { 3, "CS400", "Data Structures", 4, "T/TR 2:15 PM - 3:30 PM" },
                    { 4, "CS510", "Programming Language Concepts", 3, "T/TR 8:30 AM - 9:50 AM" },
                    { 5, "MATH231", "Discrete Math", 3, "MWF 1:00 PM - 3:00 PM" },
                    { 6, "PSY325", "Developmental Psychology", 3, "MTF 12:30 PM - 1:45 PM" },
                    { 7, "SOC338", "Health & Lifestyle", 3, "MWF 2:15 PM - 3:30 PM" },
                    { 8, "MKT690J", "Social Media Marketing", 3, "T/TR 9:30 AM - 10:45 AM" },
                    { 9, "MGMT681", "Strategic Management", 3, "MFW 3:30 PM - 4:45 PM" },
                    { 10, "NURS362", "Clinical Care Lab", 1, "F 1:00 PM - 4:00 PM" },
                    { 11, "GEOG235", "Meteorology", 3, "MWF 2:15 PM - 3:30 PM" },
                    { 12, "ENGR101", "Introduction to Engineering", 3, "T/TR 11:15 AM - 12:25 PM" },
                    { 13, "CHEM221", "General Chemistry I", 5, "T/TR 4:30 PM - 6:00 PM" }
                });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 10, 24, 13, 36, 6, 854, DateTimeKind.Local).AddTicks(8468));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 13);

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 10, 24, 13, 17, 45, 830, DateTimeKind.Local).AddTicks(5644));
        }
    }
}
