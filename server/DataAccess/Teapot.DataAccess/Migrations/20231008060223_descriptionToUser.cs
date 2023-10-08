using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teapot.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class descriptionToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "description",
                table: "users",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "description",
                table: "users");
        }
    }
}
