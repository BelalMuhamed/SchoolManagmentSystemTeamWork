using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagmentSystem.PL.Data.Migrations
{
    /// <inheritdoc />
    public partial class init11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_classesAndSubjects_Teachers_TeacherId",
                table: "classesAndSubjects");

            migrationBuilder.DropIndex(
                name: "IX_classesAndSubjects_TeacherId",
                table: "classesAndSubjects");

            migrationBuilder.DropColumn(
                name: "TeacherId",
                table: "classesAndSubjects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TeacherId",
                table: "classesAndSubjects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_classesAndSubjects_TeacherId",
                table: "classesAndSubjects",
                column: "TeacherId");

            migrationBuilder.AddForeignKey(
                name: "FK_classesAndSubjects_Teachers_TeacherId",
                table: "classesAndSubjects",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
