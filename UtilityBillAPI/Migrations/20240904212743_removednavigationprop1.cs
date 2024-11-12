using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class removednavigationprop1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "82cc2f0c-9eed-402a-90d5-757b94ad207c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b9b56f20-8927-4d5b-8224-e54b4b5c764f");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4564e8cf-6753-4d90-8cf3-e6fb81fa46d1", null, "User", "USER" },
                    { "ca3398a1-dbc6-4dfe-bdb8-036f03e31de1", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4564e8cf-6753-4d90-8cf3-e6fb81fa46d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca3398a1-dbc6-4dfe-bdb8-036f03e31de1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82cc2f0c-9eed-402a-90d5-757b94ad207c", null, "Admin", "ADMIN" },
                    { "b9b56f20-8927-4d5b-8224-e54b4b5c764f", null, "User", "USER" }
                });
        }
    }
}
