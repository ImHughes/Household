using Microsoft.EntityFrameworkCore.Migrations;

namespace Household.Data.Migrations
{
    public partial class roomImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Room",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Room_UserId",
                table: "Room",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Room_AspNetUsers_UserId",
                table: "Room",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Room_AspNetUsers_UserId",
                table: "Room");

            migrationBuilder.DropIndex(
                name: "IX_Room_UserId",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Room");
        }
    }
}
