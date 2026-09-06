using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SalesApp.db.Migrations
{
    /// <inheritdoc />
    public partial class userRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "76ada224-eeeb-4aff-babd-a6e0f3a72043", null, "User", "USER" },
                    { "a0170da8-8a37-4235-af6d-5cc82ad0fe4b", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "76ada224-eeeb-4aff-babd-a6e0f3a72043");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a0170da8-8a37-4235-af6d-5cc82ad0fe4b");
        }
    }
}
