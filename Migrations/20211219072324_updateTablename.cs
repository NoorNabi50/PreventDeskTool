using Microsoft.EntityFrameworkCore.Migrations;

namespace PreventDeskTool.Migrations
{
    public partial class updateTablename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videoAnomalies_Videos_VideosVideoId",
                table: "videoAnomalies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_videoAnomalies",
                table: "videoAnomalies");

            migrationBuilder.RenameTable(
                name: "videoAnomalies",
                newName: "VideoAnomalies");

            migrationBuilder.RenameIndex(
                name: "IX_videoAnomalies_VideosVideoId",
                table: "VideoAnomalies",
                newName: "IX_VideoAnomalies_VideosVideoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoAnomalies",
                table: "VideoAnomalies",
                column: "AnomalyId");

            migrationBuilder.AddForeignKey(
                name: "FK_VideoAnomalies_Videos_VideosVideoId",
                table: "VideoAnomalies",
                column: "VideosVideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VideoAnomalies_Videos_VideosVideoId",
                table: "VideoAnomalies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoAnomalies",
                table: "VideoAnomalies");

            migrationBuilder.RenameTable(
                name: "VideoAnomalies",
                newName: "videoAnomalies");

            migrationBuilder.RenameIndex(
                name: "IX_VideoAnomalies_VideosVideoId",
                table: "videoAnomalies",
                newName: "IX_videoAnomalies_VideosVideoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_videoAnomalies",
                table: "videoAnomalies",
                column: "AnomalyId");

            migrationBuilder.AddForeignKey(
                name: "FK_videoAnomalies_Videos_VideosVideoId",
                table: "videoAnomalies",
                column: "VideosVideoId",
                principalTable: "Videos",
                principalColumn: "VideoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
