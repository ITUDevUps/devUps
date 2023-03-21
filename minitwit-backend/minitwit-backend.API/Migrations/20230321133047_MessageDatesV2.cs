using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace minitwitbackend.Migrations
{
    /// <inheritdoc />
    public partial class MessageDatesV2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "date",
                table: "message",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "date",
                table: "message");
        }
    }
}
