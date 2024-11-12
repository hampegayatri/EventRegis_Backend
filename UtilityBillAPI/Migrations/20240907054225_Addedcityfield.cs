using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addedcityfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6a97f6c3-e692-4747-8cab-2b20fefdb742");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "904d1b0b-ebb7-4bec-904d-dfb27b896552");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "EventDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4205a9f0-175f-45d5-b42f-cce7e4f6623c", null, "User", "USER" },
                    { "893bbef0-5630-4c67-b5cf-b63fcc785318", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4205a9f0-175f-45d5-b42f-cce7e4f6623c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "893bbef0-5630-4c67-b5cf-b63fcc785318");

            migrationBuilder.DropColumn(
                name: "City",
                table: "EventDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6a97f6c3-e692-4747-8cab-2b20fefdb742", null, "Admin", "ADMIN" },
                    { "904d1b0b-ebb7-4bec-904d-dfb27b896552", null, "User", "USER" }
                });
        }
    }
}
