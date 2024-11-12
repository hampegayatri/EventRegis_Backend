using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class paymentfield3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b177e53-43f2-4331-b0da-db52c05a4e49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "256e45b9-d99b-440a-85f4-804c79425e48");

            migrationBuilder.DropColumn(
                name: "EventRegistrationsId",
                table: "Payments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2162ebb9-a952-4789-a7e8-3ac7fc35e13b", null, "User", "USER" },
                    { "9075c18e-2c1b-422f-80bd-7a86ced1f79e", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2162ebb9-a952-4789-a7e8-3ac7fc35e13b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9075c18e-2c1b-422f-80bd-7a86ced1f79e");

            migrationBuilder.AddColumn<int>(
                name: "EventRegistrationsId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0b177e53-43f2-4331-b0da-db52c05a4e49", null, "Admin", "ADMIN" },
                    { "256e45b9-d99b-440a-85f4-804c79425e48", null, "User", "USER" }
                });
        }
    }
}
