using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                keyValue: 36,
                column: "MaxCapacity",
                value: 50);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 37,
                column: "MaxCapacity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 38,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 4, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 39,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 8, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 40,
                column: "MaxCapacity",
                value: 45);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 41,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 17, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 44,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 12, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 47,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 21, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 48,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 14, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 49,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 1, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 50,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 9, 25 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 51,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 9, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 52,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 39, 75 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 53,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 27, 75 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 54,
                column: "MaxCapacity",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 55,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 15, 35 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 56,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 16, 35 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 57,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 21, 35 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 58,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 14, 35 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 2, 27, 19, 45, 35, 880, DateTimeKind.Local).AddTicks(7934));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                keyValue: 36,
                column: "MaxCapacity",
                value: 14);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 37,
                column: "MaxCapacity",
                value: 25);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 38,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 4 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 39,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 8 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 40,
                column: "MaxCapacity",
                value: 10);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 41,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 17 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 44,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 12 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 47,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 21 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 48,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 14 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 49,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 15 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 50,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 25, 9 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 51,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 30, 9 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 52,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 75, 39 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 53,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 75, 27 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 54,
                column: "MaxCapacity",
                value: 12);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 55,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 35, 16 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 56,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 35, 16 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 57,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 35, 21 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 58,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 35, 14 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 2, 27, 19, 17, 7, 480, DateTimeKind.Local).AddTicks(1333));
        }
    }
}
