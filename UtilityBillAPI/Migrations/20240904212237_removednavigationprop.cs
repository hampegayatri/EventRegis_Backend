using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class removednavigationprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2deeb406-4f1d-40e1-87c9-e9beb97dd6b4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a4be489a-6292-4d01-8ed1-96fa51d9e1dd");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "82cc2f0c-9eed-402a-90d5-757b94ad207c", null, "Admin", "ADMIN" },
                    { "b9b56f20-8927-4d5b-8224-e54b4b5c764f", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "2deeb406-4f1d-40e1-87c9-e9beb97dd6b4", null, "User", "USER" },
                    { "a4be489a-6292-4d01-8ed1-96fa51d9e1dd", null, "Admin", "ADMIN" }
                });
        }
    }
}
