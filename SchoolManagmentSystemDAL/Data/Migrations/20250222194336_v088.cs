using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolManagmentSystem.PL.Data.Migrations
{
    /// <inheritdoc />
    public partial class v088 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ParentName",
                table: "Students");

            migrationBuilder.CreateTable(
                name: "classesAndSubjects",
                columns: table => new
                {
                    classId = table.Column<int>(type: "int", nullable: false),
                    SubjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classesAndSubjects", x => new { x.classId, x.SubjectId });
                    table.ForeignKey(
                        name: "FK_classesAndSubjects_Classes_classId",
                        column: x => x.classId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_classesAndSubjects_Subjects_SubjectId",
                        column: x => x.SubjectId,
                        principalTable: "Subjects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classesAndSubjects_SubjectId",
                table: "classesAndSubjects",
                column: "SubjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "classesAndSubjects");

            migrationBuilder.AddColumn<string>(
                name: "ParentName",
                table: "Students",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }
    }
}
