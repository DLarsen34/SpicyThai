using Microsoft.EntityFrameworkCore.Migrations;

namespace SpicyThai.Data.Migrations
{
    public partial class fixedCoupons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscoutAmount",
                table: "Coupon",
                newName: "DiscountAmount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DiscountAmount",
                table: "Coupon",
                newName: "DiscoutAmount");
        }
    }
}
