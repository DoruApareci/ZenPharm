using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _3.ZenPharm.DAL.Migrations
{
    /// <inheritdoc />
    public partial class SeedDedaultUsersData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1792a101-89ff-452d-bbe1-ed16bf4119e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1cf3b0b2-b394-4258-81be-535065908e17");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c33a1add-420a-4636-906e-5548c9c91333");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1f92b138-a27e-44cd-904e-7c10eff9616e", null, "Buyer", "BUYER" },
                    { "58ff34ee-ed69-4d43-9124-53ac00c07c85", null, "Admin", "ADMIN" },
                    { "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5", null, "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "40d18e53-8fdc-442b-894c-1537e18ee9c0", 0, "ManagerAddress", "0f9969ba-1399-4ff9-aa51-450be39f25fe", "manager@manager.com", true, "ManagerFirstName", "ManagerLastName", false, null, "MANAGER@MANAGER.COM", "MANAGER@MANAGER.COM", "AQAAAAIAAYagAAAAEOTMI0H3acV0qkF+IchdQ5cDZsGyca4sqdyeYLj0o5orIrF9BDXcrnduKa48MhAO0g==", null, false, "42448682-5050-4bf2-921a-e700793fdacb", false, "manager@manager.com" },
                    { "a0b0cd50-7fac-4b4c-9a31-0967103dcb1e", 0, "BuyerAddress", "0c36a19c-678a-4c07-bc5b-c746f83d224c", "buyer@buyer.com", true, "BuyerFirstName", "BuyerLastName", false, null, "BUYER@BUYER.COM", "BUYER@BUYER.COM", "AQAAAAIAAYagAAAAENqzfwVsM8nHMXsySTr6XK+IUn0yyd28iLd73wxaEgLY55sqm15lv3k8Fqa58Odx6A==", null, false, "083918b7-bdaa-4a4c-811f-1536400a27f0", false, "buyer@buyer.com" },
                    { "e6452a0c-6887-4255-a10e-858e857ab2ed", 0, "AdminAddress", "021c949d-d111-4d7b-aba8-17e3cfb9518f", "admin@admin.com", true, "AdminFirstName", "AdminLastName", false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAIAAYagAAAAEG29rs8W7CtnzddHYLEl+A0CAZnkPGEjVYBSI4dVZn/BbMgI+IlSdCd2Q9ud6rGl4g==", null, false, "427ee66b-9cb4-496d-b0ba-48532381484f", false, "admin@admin.com" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5", "40d18e53-8fdc-442b-894c-1537e18ee9c0" },
                    { "1f92b138-a27e-44cd-904e-7c10eff9616e", "a0b0cd50-7fac-4b4c-9a31-0967103dcb1e" },
                    { "58ff34ee-ed69-4d43-9124-53ac00c07c85", "e6452a0c-6887-4255-a10e-858e857ab2ed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5", "40d18e53-8fdc-442b-894c-1537e18ee9c0" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1f92b138-a27e-44cd-904e-7c10eff9616e", "a0b0cd50-7fac-4b4c-9a31-0967103dcb1e" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "58ff34ee-ed69-4d43-9124-53ac00c07c85", "e6452a0c-6887-4255-a10e-858e857ab2ed" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1f92b138-a27e-44cd-904e-7c10eff9616e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "58ff34ee-ed69-4d43-9124-53ac00c07c85");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af3c4ceb-2c5f-4b07-abcc-e2cd010de7f5");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "40d18e53-8fdc-442b-894c-1537e18ee9c0");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a0b0cd50-7fac-4b4c-9a31-0967103dcb1e");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e6452a0c-6887-4255-a10e-858e857ab2ed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1792a101-89ff-452d-bbe1-ed16bf4119e0", null, "Buyer", "BUYER" },
                    { "1cf3b0b2-b394-4258-81be-535065908e17", null, "Admin", "ADMIN" },
                    { "c33a1add-420a-4636-906e-5548c9c91333", null, "Moderator", "MODERATOR" }
                });
        }
    }
}
