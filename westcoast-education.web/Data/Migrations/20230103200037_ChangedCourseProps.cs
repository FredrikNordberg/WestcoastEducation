using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace westcoasteducation.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangedCourseProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CourseLocation",
                table: "Courses",
                newName: "CourseTitle");

            migrationBuilder.RenameColumn(
                name: "CourseLanguage",
                table: "Courses",
                newName: "CourseStartDate");

            migrationBuilder.AddColumn<string>(
                name: "CourseEndDate",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseEndDate",
                table: "Courses");

            migrationBuilder.RenameColumn(
                name: "CourseTitle",
                table: "Courses",
                newName: "CourseLocation");

            migrationBuilder.RenameColumn(
                name: "CourseStartDate",
                table: "Courses",
                newName: "CourseLanguage");
        }
    }
}
