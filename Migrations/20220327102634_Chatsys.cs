using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreventDeskTool.Migrations
{
    public partial class Chatsys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    ChatId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MessageText = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MessageTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.ChatId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");
        }
    }
}
