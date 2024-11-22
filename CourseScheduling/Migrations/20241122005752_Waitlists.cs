using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class Waitlists : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentEnrollment",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxCapacity",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 2, 25 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 5, 25 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 2, 35 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 4,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 15, 40 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 5,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 25, 25 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 6,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 25, 50 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 7,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 10, 30 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 8,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 12, 20 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 9,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 7, 15 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 10,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 0, 25 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 11,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 25, 40 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 12,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 9, 15 });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 13,
                columns: new[] { "CurrentEnrollment", "MaxCapacity" },
                values: new object[] { 2, 25 });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 11, 21, 18, 57, 51, 421, DateTimeKind.Local).AddTicks(3376));

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
                name: "Waitlists");

            migrationBuilder.DropColumn(
                name: "CurrentEnrollment",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "Courses");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2024, 11, 14, 22, 46, 41, 835, DateTimeKind.Local).AddTicks(2190));
        }
    }
}
