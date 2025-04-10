using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class SeedDegreeRequirements : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DegreeRequirements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Major = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    SemesterSuggestion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DegreeRequirements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DegreeRequirements_Courses_CourseId",
                        column: x => x.CourseId,
                        principalTable: "Courses",
                        principalColumn: "CourseId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "DegreeRequirements",
                columns: new[] { "Id", "CourseId", "IsRequired", "Major", "SemesterSuggestion" },
                values: new object[,]
                {
                    { 1, 1, true, "Computer Science", 1 },
                    { 2, 3, true, "Computer Science", 2 },
                    { 3, 4, true, "Computer Science", 3 },
                    { 4, 25, true, "Computer Science", 4 },
                    { 5, 30, true, "Computer Science", 5 }
                });

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 4, 10, 9, 4, 15, 500, DateTimeKind.Local).AddTicks(4293));

            migrationBuilder.CreateIndex(
                name: "IX_DegreeRequirements_CourseId",
                table: "DegreeRequirements",
                column: "CourseId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DegreeRequirements");

            migrationBuilder.UpdateData(
                table: "Enrollments",
                keyColumn: "EnrollmentId",
                keyValue: 1,
                column: "EnrollmentDate",
                value: new DateTime(2025, 2, 27, 19, 50, 29, 541, DateTimeKind.Local).AddTicks(867));
        }
    }
}
