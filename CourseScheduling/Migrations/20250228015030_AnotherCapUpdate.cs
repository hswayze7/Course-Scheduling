using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class AnotherCapUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 15, 40 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 25, 50 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 43,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 2, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 45,
                column: "MaxCapacity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 46,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 22, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 54,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 20, 30 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 2, 27, 19, 50, 29, 541, DateTimeKind.Local).AddTicks(867));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 40, 15 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 50, 25 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 43,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 2 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 45,
                column: "MaxCapacity",
                value: 18);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 46,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 22 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 54,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 20 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 2, 27, 19, 45, 35, 880, DateTimeKind.Local).AddTicks(7934));
        }
    }
}
