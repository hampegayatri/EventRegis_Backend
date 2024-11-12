using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class paymentfield2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39971a95-c545-432f-bcb6-bf49a06fab8f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "991bbe63-c66d-4395-b313-d4b4850ad174");

            migrationBuilder.AddColumn<int>(
                name: "EventRegistrationId",
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

            migrationBuilder.CreateIndex(
                name: "IX_Payments_EventRegistrationId",
                table: "Payments",
                column: "EventRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payments_EventRegistrations_EventRegistrationId",
                table: "Payments",
                column: "EventRegistrationId",
                principalTable: "EventRegistrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payments_EventRegistrations_EventRegistrationId",
                table: "Payments");

            migrationBuilder.DropIndex(
                name: "IX_Payments_EventRegistrationId",
                table: "Payments");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0b177e53-43f2-4331-b0da-db52c05a4e49");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "256e45b9-d99b-440a-85f4-804c79425e48");

            migrationBuilder.DropColumn(
                name: "EventRegistrationId",
                table: "Payments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39971a95-c545-432f-bcb6-bf49a06fab8f", null, "User", "USER" },
                    { "991bbe63-c66d-4395-b313-d4b4850ad174", null, "Admin", "ADMIN" }
                });
        }
    }
}
