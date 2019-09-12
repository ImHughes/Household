using Microsoft.EntityFrameworkCore.Migrations;

namespace Household.Data.Migrations
{
    public partial class productType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}
