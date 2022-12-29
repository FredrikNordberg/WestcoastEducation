using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace westcoasteducation.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemovedStudentAndTeacherClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.RenameColumn(
                name: "CouseLanguage",
                table: "Courses",
                newName: "CourseLanguage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseLanguage",
                table: "Courses",
                newName: "CouseLanguage");

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    StudentEmail = table.Column<string>(type: "TEXT", nullable: false),
                    StudentFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    StudentLastName = table.Column<string>(type: "TEXT", nullable: false),
                    StudentPhone = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    TeacherId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TeacherEmail = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherFirstName = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherLastName = table.Column<string>(type: "TEXT", nullable: false),
                    TeacherPhone = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.TeacherId);
                });
        }
    }
}
