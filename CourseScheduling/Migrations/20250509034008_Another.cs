using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CourseScheduling.Migrations
{
    /// <inheritdoc />
    public partial class Another : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeRequirements_Degree_DegreeId",
                table: "DegreeRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Degree_DegreeId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degree",
                table: "Degree");

            migrationBuilder.RenameTable(
                name: "Degree",
                newName: "Degrees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees",
                column: "DegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeRequirements_Degrees_DegreeId",
                table: "DegreeRequirements",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "DegreeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Degrees_DegreeId",
                table: "Students",
                column: "DegreeId",
                principalTable: "Degrees",
                principalColumn: "DegreeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DegreeRequirements_Degrees_DegreeId",
                table: "DegreeRequirements");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Degrees_DegreeId",
                table: "Students");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Degrees",
                table: "Degrees");

            migrationBuilder.RenameTable(
                name: "Degrees",
                newName: "Degree");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Degree",
                table: "Degree",
                column: "DegreeId");

            migrationBuilder.AddForeignKey(
                name: "FK_DegreeRequirements_Degree_DegreeId",
                table: "DegreeRequirements",
                column: "DegreeId",
                principalTable: "Degree",
                principalColumn: "DegreeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Degree_DegreeId",
                table: "Students",
                column: "DegreeId",
                principalTable: "Degree",
                principalColumn: "DegreeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
