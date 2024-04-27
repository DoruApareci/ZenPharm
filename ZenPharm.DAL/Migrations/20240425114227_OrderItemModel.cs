using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _3.ZenPharm.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderItemModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderItemID = table.Column<Guid>(type: "TEXT", nullable: false),
                    OrderItemProductID = table.Column<Guid>(type: "TEXT", nullable: false),
                    Quantity = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.OrderItemID);
                    table.ForeignKey(
                        name: "FK_OrderItems_Products_OrderItemProductID",
                        column: x => x.OrderItemProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a706e54c-306f-41ce-9726-dad2eee83667", null, "Moderator", "MODERATOR" },
                    { "bac15993-b1cc-4da8-98e2-641556571d20", null, "Buyer", "BUYER" },
                    { "c79ea684-632d-45d7-945a-c52c6a0a0de2", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderItemProductID",
                table: "OrderItems",
                column: "OrderItemProductID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a706e54c-306f-41ce-9726-dad2eee83667");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bac15993-b1cc-4da8-98e2-641556571d20");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c79ea684-632d-45d7-945a-c52c6a0a0de2");

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
    }
}
