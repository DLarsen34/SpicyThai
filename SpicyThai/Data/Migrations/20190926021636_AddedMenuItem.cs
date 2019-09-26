using Microsoft.EntityFrameworkCore.Migrations;

namespace SpicyThai.Data.Migrations
{
    public partial class AddedMenuItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Category",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Category",
                newName: "id");
        }
    }
}
