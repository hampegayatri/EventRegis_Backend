using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class Addedfileds1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "348e83bc-da16-4cb7-a090-56b17a11a304");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe03517a-a9b4-4332-a36e-fad992f37ea0");

            migrationBuilder.AddColumn<int>(
                name: "RegisteredCount",
                table: "EventDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2f7976ba-91ca-4042-9eee-0b32c1cee47b", null, "User", "USER" },
                    { "4397cafc-7c25-461f-80d3-cc5b25d4058a", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2f7976ba-91ca-4042-9eee-0b32c1cee47b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4397cafc-7c25-461f-80d3-cc5b25d4058a");

            migrationBuilder.DropColumn(
                name: "RegisteredCount",
                table: "EventDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "348e83bc-da16-4cb7-a090-56b17a11a304", null, "Admin", "ADMIN" },
                    { "fe03517a-a9b4-4332-a36e-fad992f37ea0", null, "User", "USER" }
                });
        }
    }
}
