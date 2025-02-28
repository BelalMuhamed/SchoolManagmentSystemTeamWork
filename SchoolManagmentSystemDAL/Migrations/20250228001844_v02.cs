using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagmentSystemDAL.Migrations
{
    /// <inheritdoc />
    public partial class v02 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherAttendances",
                table: "TeacherAttendances");

            migrationBuilder.DropIndex(
                name: "IX_TeacherAttendances_TeacherId",
                table: "TeacherAttendances");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "TeacherAttendances");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherAttendances",
                table: "TeacherAttendances",
                columns: new[] { "TeacherId", "Date" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherAttendances",
                table: "TeacherAttendances");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "TeacherAttendances",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherAttendances",
                table: "TeacherAttendances",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherAttendances_TeacherId",
                table: "TeacherAttendances",
                column: "TeacherId");
        }
    }
}
