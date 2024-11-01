using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTimes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "Time",
                value: "M/W/F 10:00 AM - 12:00 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "Time",
                value: "T/TR 1:00 PM - 3:00 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5,
                column: "Time",
                value: "M/W/F 1:00 PM - 3:00 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6,
                column: "Time",
                value: "M/T/F 12:30 PM - 1:45 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 7,
                column: "Time",
                value: "M/W/F 2:15 PM - 3:30 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 9,
                column: "Time",
                value: "M/F/W 3:30 PM - 4:45 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 11,
                column: "Time",
                value: "M/W/F 2:15 PM - 3:30 PM");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 11, 1, 16, 5, 39, 531, DateTimeKind.Local).AddTicks(1512));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                column: "Time",
                value: "Mon 10:00 AM - 12:00 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                column: "Time",
                value: "Tue 1:00 PM - 3:00 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5,
                column: "Time",
                value: "MWF 1:00 PM - 3:00 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6,
                column: "Time",
                value: "MTF 12:30 PM - 1:45 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 7,
                column: "Time",
                value: "MWF 2:15 PM - 3:30 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 9,
                column: "Time",
                value: "MFW 3:30 PM - 4:45 PM");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 11,
                column: "Time",
                value: "MWF 2:15 PM - 3:30 PM");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 11, 1, 15, 36, 9, 838, DateTimeKind.Local).AddTicks(3435));
        }
    }
}
