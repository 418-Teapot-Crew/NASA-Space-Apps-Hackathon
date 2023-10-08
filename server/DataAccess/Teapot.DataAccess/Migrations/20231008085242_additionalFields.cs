using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teapot.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class additionalFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fields_of_science",
                table: "projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "geographic_scope",
                table: "projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "keywords",
                table: "projects",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "participant_age",
                table: "projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "participation_tasks",
                table: "projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "project_status",
                table: "projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "project_url_external",
                table: "projects",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "start_date",
                table: "projects",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fields_of_science",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "geographic_scope",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "keywords",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "name",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "participant_age",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "participation_tasks",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "project_status",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "project_url_external",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "projects");
        }
    }
}
