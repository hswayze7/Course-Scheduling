using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class MoreDegreeReqs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5,
                column: "CourseCode",
                value: "MATH321");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 56,
                column: "Professor",
                value: "Prof57");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 57,
                column: "Professor",
                value: "Prof58");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 58,
                column: "Professor",
                value: "Prof59");

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseCode", "CourseName", "Credits", "CurrentEnrollment", "Description", "MaxCapacity", "Professor", "Time" },
                values: new object[] { 59, "MATH511", "Linear Algebra", 3, 38, "An elementary study of linear algebra, including an examination of linear transformations and matrices over finite dimensional spaces. Prerequisite(s): MATH 243 with a grade point of 2.000 or better.", 45, "Prof60", "T/TR 12:30 PM - 1:45 PM" });

            migrationBuilder.InsertData(
                table: "DegreeRequirements",
                columns: new[] { "DegreeRequirementId", "CourseCode", "CourseId", "DegreeId", "IsRequired", "Major", "SemesterSuggestion" },
                values: new object[,]
                {
                    { 15, "MATH243", 2, 1, true, "Computer Science", 14 },
                    { 16, "MATH321", 5, 1, true, "Computer Science", 14 },
                    { 17, "MATH242", 16, 1, true, "Computer Science", 14 },
                    { 18, "PHIL125", 14, 1, true, "Computer Science", 14 },
                    { 19, "PHYS314", 17, 1, true, "Computer Science", 14 },
                    { 20, "PHYS316", 18, 1, true, "Computer Science", 14 },
                    { 21, "PHYS313", 20, 1, true, "Computer Science", 14 },
                    { 22, "PHIL354", 15, 1, true, "Computer Science", 14 },
                    { 23, "MATH322", 19, 1, true, "Computer Science", 14 },
                    { 25, "IME254", 21, 1, true, "Computer Science", 14 },
                    { 26, "ECE194", 22, 1, true, "Computer Science", 14 },
                    { 27, "ECE238", 24, 1, true, "Computer Science", 14 },
                    { 28, "ECE394", 26, 1, true, "Computer Science", 14 },
                    { 24, "MATH511", 59, 1, true, "Computer Science", 14 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "DegreeRequirements",
                keyColumn: "DegreeRequirementId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 59);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5,
                column: "CourseCode",
                value: "MATH231");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 56,
                column: "Professor",
                value: "Prof56");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 57,
                column: "Professor",
                value: "Prof56");

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 58,
                column: "Professor",
                value: "Prof56");
        }
    }
}
