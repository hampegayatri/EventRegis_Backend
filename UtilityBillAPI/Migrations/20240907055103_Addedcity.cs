using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addedcity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Venues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7b96d209-f5b3-44c5-b3cd-8f151392341f", null, "Admin", "ADMIN" },
                    { "aac2fee7-9026-4941-819e-ea1043a27a2d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b96d209-f5b3-44c5-b3cd-8f151392341f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aac2fee7-9026-4941-819e-ea1043a27a2d");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Venues");

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
    }
}
