using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _3.ZenPharm.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProductModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "52d023f4-e1b5-4da9-86e4-98d51b108584");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e28221b-776e-4c11-b726-35b0dbbfc859");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c5c5efac-fff8-4862-9f05-cf2aff4ff7a1");

            migrationBuilder.AddColumn<string>(
                name: "Path",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4a86b1df-c48d-403e-8b27-ecef25400301", null, "Buyer", "BUYER" },
                    { "70667cb5-cbd0-4deb-a0a3-cc1091697f62", null, "Admin", "ADMIN" },
                    { "b7776c54-5e7c-422a-bdbf-2ce06531dec7", null, "Moderator", "MODERATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4a86b1df-c48d-403e-8b27-ecef25400301");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "70667cb5-cbd0-4deb-a0a3-cc1091697f62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b7776c54-5e7c-422a-bdbf-2ce06531dec7");

            migrationBuilder.DropColumn(
                name: "Path",
                table: "Products");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "52d023f4-e1b5-4da9-86e4-98d51b108584", null, "Buyer", "BUYER" },
                    { "7e28221b-776e-4c11-b726-35b0dbbfc859", null, "Admin", "ADMIN" },
                    { "c5c5efac-fff8-4862-9f05-cf2aff4ff7a1", null, "Moderator", "MODERATOR" }
                });
        }
    }
}
