using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace westcoasteducation.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserNameAndCoursName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PersonUserName",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CourseNumber",
                table: "Courses",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PersonUserName",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "CourseNumber",
                table: "Courses");
        }
    }
}
