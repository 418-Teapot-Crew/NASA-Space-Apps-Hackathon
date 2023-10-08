using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teapot.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ModifyChatTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "message_time",
                table: "chat_histories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "message_time",
                table: "chat_histories",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
