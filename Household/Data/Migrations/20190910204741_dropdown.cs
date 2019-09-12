using Microsoft.EntityFrameworkCore.Migrations;

namespace Household.Data.Migrations
{
    public partial class dropdown : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductType",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Small Kitchen Appliances" },
                    { 2, "Large Kitchen Appliances" },
                    { 3, "Electronics" },
                    { 4, "Utilies" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductType",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
