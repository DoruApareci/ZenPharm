using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _3.ZenPharm.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductPubId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "PubId",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "623df552-d759-4e3a-8c02-4497a7f248c8", null, "Moderator", "MODERATOR" },
                    { "75d4ff4c-7b6a-470d-9a83-0a33188467c3", null, "Buyer", "BUYER" },
                    { "f52fbec8-f929-4efa-a48c-107da6fd1d96", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "623df552-d759-4e3a-8c02-4497a7f248c8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75d4ff4c-7b6a-470d-9a83-0a33188467c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f52fbec8-f929-4efa-a48c-107da6fd1d96");

            migrationBuilder.DropColumn(
                name: "PubId",
                table: "Products");

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
    }
}
