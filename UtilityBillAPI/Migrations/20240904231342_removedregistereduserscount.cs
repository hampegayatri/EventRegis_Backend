using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class removedregistereduserscount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "879d59bc-58d1-4289-88e6-8215632af2e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ccb9c2ad-1f9f-4c66-af2c-25ad0dd5137d");

            migrationBuilder.DropColumn(
                name: "RegisteredUsersCount",
                table: "EventDetails");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0bc98eb1-87d3-47b6-baab-6c2e5db1c861", null, "Admin", "ADMIN" },
                    { "40156523-3512-450b-9fcf-c0eb95d5dde6", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bc98eb1-87d3-47b6-baab-6c2e5db1c861");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40156523-3512-450b-9fcf-c0eb95d5dde6");

            migrationBuilder.AddColumn<int>(
                name: "RegisteredUsersCount",
                table: "EventDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "879d59bc-58d1-4289-88e6-8215632af2e0", null, "Admin", "ADMIN" },
                    { "ccb9c2ad-1f9f-4c66-af2c-25ad0dd5137d", null, "User", "USER" }
                });
        }
    }
}
