using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _3.ZenPharm.DAL.Migrations
{
    /// <inheritdoc />
    public partial class OrderUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<DateTime>(
                name: "Placed",
                table: "Orders",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1c384f02-f7df-4b68-9732-fec7ba8fef02", null, "Moderator", "MODERATOR" },
                    { "1d263131-20f8-4a76-9167-535b3e89f399", null, "Buyer", "BUYER" },
                    { "4dd0b7d6-6d2c-453b-8234-81b49d5b8082", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1c384f02-f7df-4b68-9732-fec7ba8fef02");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1d263131-20f8-4a76-9167-535b3e89f399");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4dd0b7d6-6d2c-453b-8234-81b49d5b8082");

            migrationBuilder.DropColumn(
                name: "Placed",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Orders");

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
    }
}
