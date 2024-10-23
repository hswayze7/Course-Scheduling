using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class SeedTestStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Email", "Major", "Name", "Password", "Year" },
                values: new object[] { 1, "test@student.com", "Computer Science", "Test Student", "test123", "Sophomore" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);
        }
    }
}
