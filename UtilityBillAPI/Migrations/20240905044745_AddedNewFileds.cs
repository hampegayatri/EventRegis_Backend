using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedNewFileds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ac7886c-47a7-4b23-a1e0-36daa9c6ac34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6539a8da-f969-4f3d-82dd-ef6a429a9c8a");

            migrationBuilder.AddColumn<bool>(
                name: "IsWaitlisted",
                table: "EventRegistrations",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Tags",
                table: "EventDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "348e83bc-da16-4cb7-a090-56b17a11a304", null, "Admin", "ADMIN" },
                    { "fe03517a-a9b4-4332-a36e-fad992f37ea0", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "348e83bc-da16-4cb7-a090-56b17a11a304");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fe03517a-a9b4-4332-a36e-fad992f37ea0");

            migrationBuilder.DropColumn(
                name: "IsWaitlisted",
                table: "EventRegistrations");

            migrationBuilder.DropColumn(
                name: "Tags",
                table: "EventDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ac7886c-47a7-4b23-a1e0-36daa9c6ac34", null, "User", "USER" },
                    { "6539a8da-f969-4f3d-82dd-ef6a429a9c8a", null, "Admin", "ADMIN" }
                });
        }
    }
}
