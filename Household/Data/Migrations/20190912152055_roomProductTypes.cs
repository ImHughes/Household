using Microsoft.EntityFrameworkCore.Migrations;

namespace Household.Data.Migrations
{
    public partial class roomProductTypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductType_ProductType_ProductTypeId",
                table: "ProductType");

            migrationBuilder.DropForeignKey(
                name: "FK_Room_Room_RoomId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_RoomId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_ProductType_ProductTypeId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "ProductTypeId",
                table: "ProductType");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_RoomId",
                table: "Products",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductType_ProductTypeId",
                table: "Products",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Room_RoomId",
                table: "Products",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductType_ProductTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Room_RoomId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_RoomId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Room",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductTypeId",
                table: "ProductType",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomId",
                table: "Room",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductTypeId",
                table: "ProductType",
                column: "ProductTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductType_ProductType_ProductTypeId",
                table: "ProductType",
                column: "ProductTypeId",
                principalTable: "ProductType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Room_Room_RoomId",
                table: "Room",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
