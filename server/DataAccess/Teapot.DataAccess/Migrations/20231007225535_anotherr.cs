using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teapot.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class anotherr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "image_url",
                table: "projects");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "projects",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
