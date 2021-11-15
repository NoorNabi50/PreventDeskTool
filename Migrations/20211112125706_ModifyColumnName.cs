using Microsoft.EntityFrameworkCore.Migrations;

namespace PreventDeskTool.Migrations
{
    public partial class ModifyColumnName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemeber",
                table: "Users",
                newName: "IsRemember");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsRemember",
                table: "Users",
                newName: "IsRemeber");
        }
    }
}
