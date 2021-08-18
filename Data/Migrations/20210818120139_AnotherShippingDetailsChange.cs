﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ASP.NET_Core_Project_Online_Shop.Data.Migrations
{
    public partial class AnotherShippingDetailsChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ShippingDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ShippingDetails");
        }
    }
}
