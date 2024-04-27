using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _3.ZenPharm.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "10607a30-03a6-43bb-ae99-2a07764138c3", null, "Buyer", "BUYER" },
                    { "366e8ade-ca53-4648-a5c6-e8fc9a5906ac", null, "Admin", "ADMIN" },
                    { "e6ff59e5-d9a0-4bd6-bcd1-512b1ab7cf35", null, "Moderator", "MODERATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "10607a30-03a6-43bb-ae99-2a07764138c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "366e8ade-ca53-4648-a5c6-e8fc9a5906ac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e6ff59e5-d9a0-4bd6-bcd1-512b1ab7cf35");
        }
    }
}
