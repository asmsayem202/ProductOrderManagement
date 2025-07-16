using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductOrderManagement.Migrations
{
    /// <inheritdoc />
    public partial class addseeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Brand", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "MugBrand", "Classic Mug", 0 },
                    { 2, "JugPro", "Eco Jug", 1 },
                    { 3, "CupX", "Coffee Cup", 2 }
                });

            migrationBuilder.InsertData(
                table: "Variants",
                columns: new[] { "Id", "Color", "ProductId", "Size", "Specification" },
                values: new object[,]
                {
                    { 1, "White", 1, 1, "Ceramic" },
                    { 2, "Black", 1, 2, "Steel" },
                    { 3, "Blue", 2, 2, "Plastic" },
                    { 4, "Red", 3, 0, "Glass" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Variants",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
