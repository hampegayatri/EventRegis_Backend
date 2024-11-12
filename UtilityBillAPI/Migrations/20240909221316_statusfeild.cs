using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class statusfeild : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2162ebb9-a952-4789-a7e8-3ac7fc35e13b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9075c18e-2c1b-422f-80bd-7a86ced1f79e");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "EventRegistrations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6cc24423-6439-40ec-8a7a-9120c20a9c08", null, "Admin", "ADMIN" },
                    { "cf84d832-9eda-4de1-a8e6-578faa340c24", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6cc24423-6439-40ec-8a7a-9120c20a9c08");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cf84d832-9eda-4de1-a8e6-578faa340c24");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EventRegistrations");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2162ebb9-a952-4789-a7e8-3ac7fc35e13b", null, "User", "USER" },
                    { "9075c18e-2c1b-422f-80bd-7a86ced1f79e", null, "Admin", "ADMIN" }
                });
        }
    }
}
