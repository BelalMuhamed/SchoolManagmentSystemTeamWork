using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystemDAL.Migrations
{
    /// <inheritdoc />
    public partial class v04 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherAttendances",
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherAttendances",
                table: "TeacherAttendances",
                column: "TeacherId");
        }
    }
}
