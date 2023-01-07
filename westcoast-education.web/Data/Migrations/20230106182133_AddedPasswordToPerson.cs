using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace westcoasteducation.web.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedPasswordToPerson : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Persons",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Persons");
        }
    }
}
