using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3.ZenPharm.DAL.Migrations
{
    /// <inheritdoc />
    public partial class ProductTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdTypeID",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    ProdTypeID = table.Column<Guid>(type: "TEXT", nullable: false),
                    TypeName = table.Column<string>(type: "TEXT", nullable: false),
                    TypeDescription = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.ProdTypeID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProdTypeID",
                table: "Products",
                column: "ProdTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductTypes_ProdTypeID",
                table: "Products",
                column: "ProdTypeID",
                principalTable: "ProductTypes",
                principalColumn: "ProdTypeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductTypes_ProdTypeID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProdTypeID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProdTypeID",
                table: "Products");
        }
    }
}
