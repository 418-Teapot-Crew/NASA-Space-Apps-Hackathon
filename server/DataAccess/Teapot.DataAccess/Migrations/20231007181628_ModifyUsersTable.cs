using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teapot.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyUsersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_project_contributor_projects_project_id",
                table: "project_contributor");

            migrationBuilder.DropForeignKey(
                name: "fk_project_contributor_users_contributor_id",
                table: "project_contributor");

            migrationBuilder.DropPrimaryKey(
                name: "pk_project_contributor",
                table: "project_contributor");

            migrationBuilder.RenameTable(
                name: "project_contributor",
                newName: "project_contributors");

            migrationBuilder.RenameIndex(
                name: "ix_project_contributor_project_id",
                table: "project_contributors",
                newName: "ix_project_contributors_project_id");

            migrationBuilder.RenameIndex(
                name: "ix_project_contributor_contributor_id",
                table: "project_contributors",
                newName: "ix_project_contributors_contributor_id");

            migrationBuilder.AlterColumn<byte[]>(
                name: "password_salt",
                table: "users",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AlterColumn<byte[]>(
                name: "password_hash",
                table: "users",
                type: "bytea",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "bytea");

            migrationBuilder.AddColumn<int>(
                name: "register_type_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_project_contributors",
                table: "project_contributors",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_contributors_projects_project_id",
                table: "project_contributors",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_project_contributors_users_contributor_id",
                table: "project_contributors",
                column: "contributor_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_project_contributors_projects_project_id",
                table: "project_contributors");

            migrationBuilder.DropForeignKey(
                name: "fk_project_contributors_users_contributor_id",
                table: "project_contributors");

            migrationBuilder.DropPrimaryKey(
                name: "pk_project_contributors",
                table: "project_contributors");

            migrationBuilder.DropColumn(
                name: "register_type_id",
                table: "users");

            migrationBuilder.RenameTable(
                name: "project_contributors",
                newName: "project_contributor");

            migrationBuilder.RenameIndex(
                name: "ix_project_contributors_project_id",
                table: "project_contributor",
                newName: "ix_project_contributor_project_id");

            migrationBuilder.RenameIndex(
                name: "ix_project_contributors_contributor_id",
                table: "project_contributor",
                newName: "ix_project_contributor_contributor_id");

            migrationBuilder.AlterColumn<byte[]>(
                name: "password_salt",
                table: "users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "password_hash",
                table: "users",
                type: "bytea",
                nullable: false,
                defaultValue: new byte[0],
                oldClrType: typeof(byte[]),
                oldType: "bytea",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_project_contributor",
                table: "project_contributor",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_project_contributor_projects_project_id",
                table: "project_contributor",
                column: "project_id",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_project_contributor_users_contributor_id",
                table: "project_contributor",
                column: "contributor_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
