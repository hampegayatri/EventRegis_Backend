using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class paymentfield1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9466c678-a943-440c-a23b-615fc5889acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98e525f0-453e-41b3-9f76-2b9c59803f50");

            migrationBuilder.RenameColumn(
                name: "EventRegistrationId",
                table: "Payments",
                newName: "EventRegistrationsId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39971a95-c545-432f-bcb6-bf49a06fab8f", null, "User", "USER" },
                    { "991bbe63-c66d-4395-b313-d4b4850ad174", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39971a95-c545-432f-bcb6-bf49a06fab8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "991bbe63-c66d-4395-b313-d4b4850ad174");

            migrationBuilder.RenameColumn(
                name: "EventRegistrationsId",
                table: "Payments",
                newName: "EventRegistrationId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9466c678-a943-440c-a23b-615fc5889acb", null, "User", "USER" },
                    { "98e525f0-453e-41b3-9f76-2b9c59803f50", null, "Admin", "ADMIN" }
                });
        }
    }
}
