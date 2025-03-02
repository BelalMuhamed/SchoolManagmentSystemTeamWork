using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagmentSystemDAL.Migrations
{
    /// <inheritdoc />
    public partial class v05 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "ClassExams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClassExams_SubjectId",
                table: "ClassExams",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassExams_Subjects_SubjectId",
                table: "ClassExams",
                column: "SubjectId",
                principalTable: "Subjects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassExams_Subjects_SubjectId",
                table: "ClassExams");

            migrationBuilder.DropIndex(
                name: "IX_ClassExams_SubjectId",
                table: "ClassExams");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "ClassExams");
        }
    }
}
