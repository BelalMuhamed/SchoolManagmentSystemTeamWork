using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagementSystemDAL.Migrations
{
    /// <inheritdoc />
    public partial class v03 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherAttendances",
                table: "TeacherAttendances");

            migrationBuilder.AlterColumn<DateOnly>(
                name: "Date",
                table: "TeacherAttendances",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherAttendances",
                table: "TeacherAttendances",
                column: "TeacherId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TeacherAttendances",
                table: "TeacherAttendances");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "TeacherAttendances",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateOnly),
                oldType: "date");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TeacherAttendances",
                table: "TeacherAttendances",
                columns: new[] { "TeacherId", "Date" });
        }
    }
}
