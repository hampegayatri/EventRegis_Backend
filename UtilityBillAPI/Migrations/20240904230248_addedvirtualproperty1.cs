using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedvirtualproperty1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0069dd40-695e-4c4a-ba98-ad5b6c722072");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355dae81-1544-4193-960a-4cfbc40b951a");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "879d59bc-58d1-4289-88e6-8215632af2e0", null, "Admin", "ADMIN" },
                    { "ccb9c2ad-1f9f-4c66-af2c-25ad0dd5137d", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "879d59bc-58d1-4289-88e6-8215632af2e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccb9c2ad-1f9f-4c66-af2c-25ad0dd5137d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0069dd40-695e-4c4a-ba98-ad5b6c722072", null, "Admin", "ADMIN" },
                    { "355dae81-1544-4193-960a-4cfbc40b951a", null, "User", "USER" }
                });
        }
    }
}
