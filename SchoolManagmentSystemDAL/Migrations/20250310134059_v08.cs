using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagmentSystemDAL.Migrations
{
    /// <inheritdoc />
    public partial class v08 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_AspNetUsers_ManagerId",
                table: "Classes");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Teachers_ManagerId",
                table: "Classes",
                column: "ManagerId",
                principalTable: "Teachers",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Teachers_ManagerId",
                table: "Classes");

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_AspNetUsers_ManagerId",
                table: "Classes",
                column: "ManagerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
