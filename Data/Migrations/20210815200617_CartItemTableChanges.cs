using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_Project_Online_Shop.Data.Migrations
{
    public partial class CartItemTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "ShoppingCartItems");

            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "ShoppingCartItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemId",
                table: "ShoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "ShoppingCartItems",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
