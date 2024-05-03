using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _3.ZenPharm.DAL.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeedbackModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Placed",
                table: "FeedBacks",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placed",
                table: "FeedBacks");
        }
    }
}
