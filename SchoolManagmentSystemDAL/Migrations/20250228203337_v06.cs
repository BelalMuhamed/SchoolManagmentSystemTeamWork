using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagmentSystemDAL.Migrations
{
    /// <inheritdoc />
    public partial class v06 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_CorrectAnswerId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "CorrectAnswerId",
                table: "Questions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_CorrectAnswerId",
                table: "Questions",
                column: "CorrectAnswerId",
                principalTable: "Answers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Answers_CorrectAnswerId",
                table: "Questions");

            migrationBuilder.AlterColumn<int>(
                name: "CorrectAnswerId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Answers_CorrectAnswerId",
                table: "Questions",
                column: "CorrectAnswerId",
                principalTable: "Answers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
