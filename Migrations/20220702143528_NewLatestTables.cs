using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PreventDeskTool.Migrations
{
    public partial class NewLatestTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GameProgress",
                columns: table => new
                {
                    ProgressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProgress", x => x.ProgressId);
                });

            migrationBuilder.CreateTable(
                name: "GameProgressDetail",
                columns: table => new
                {
                    GameProgressDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GameProgressVideoId = table.Column<int>(type: "int", nullable: false),
                    OptionValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProgressDetail", x => x.GameProgressDetailId);
                });

            migrationBuilder.CreateTable(
                name: "GameProgressVideo",
                columns: table => new
                {
                    GameProgressVideoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProgressId = table.Column<int>(type: "int", nullable: false),
                    VideoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameProgressVideo", x => x.GameProgressVideoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameProgress");

            migrationBuilder.DropTable(
                name: "GameProgressDetail");

            migrationBuilder.DropTable(
                name: "GameProgressVideo");
        }
    }
}
