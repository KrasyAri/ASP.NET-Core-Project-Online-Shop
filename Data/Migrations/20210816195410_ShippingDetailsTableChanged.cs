using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_Project_Online_Shop.Data.Migrations
{
    public partial class ShippingDetailsTableChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ShippingDetails_ShippingDetailsId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ShippingDetailsId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippingDetailsId",
                table: "Orders");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShippingDetails",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDetails_UserId",
                table: "ShippingDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingDetails_AspNetUsers_UserId",
                table: "ShippingDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingDetails_AspNetUsers_UserId",
                table: "ShippingDetails");

            migrationBuilder.DropIndex(
                name: "IX_ShippingDetails_UserId",
                table: "ShippingDetails");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "ShippingDetails",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "ShippingDetailsId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ShippingDetailsId",
                table: "Orders",
                column: "ShippingDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ShippingDetails_ShippingDetailsId",
                table: "Orders",
                column: "ShippingDetailsId",
                principalTable: "ShippingDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
