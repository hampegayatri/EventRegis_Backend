using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class validation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f7976ba-91ca-4042-9eee-0b32c1cee47b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4397cafc-7c25-461f-80d3-cc5b25d4058a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a97f6c3-e692-4747-8cab-2b20fefdb742", null, "Admin", "ADMIN" },
                    { "904d1b0b-ebb7-4bec-904d-dfb27b896552", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a97f6c3-e692-4747-8cab-2b20fefdb742");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904d1b0b-ebb7-4bec-904d-dfb27b896552");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f7976ba-91ca-4042-9eee-0b32c1cee47b", null, "User", "USER" },
                    { "4397cafc-7c25-461f-80d3-cc5b25d4058a", null, "Admin", "ADMIN" }
                });
        }
    }
}
