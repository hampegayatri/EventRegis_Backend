using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class addedvirtualproperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_EventDetails_EventDetailId",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_EventDetailId",
                table: "EventRegistrations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8bc58d1a-acf6-4d07-93c3-daf653121db9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b94abc79-cf6b-453c-93ab-3d31b3596dc1");

            migrationBuilder.DropColumn(
                name: "EventDetailId",
                table: "EventRegistrations");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "EventRegistrations",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0069dd40-695e-4c4a-ba98-ad5b6c722072", null, "Admin", "ADMIN" },
                    { "355dae81-1544-4193-960a-4cfbc40b951a", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventId",
                table: "EventRegistrations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_TicketTypeId",
                table: "EventRegistrations",
                column: "TicketTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_UserId1",
                table: "EventRegistrations",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_EventDetails_EventId",
                table: "EventRegistrations",
                column: "EventId",
                principalTable: "EventDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Registers_UserId1",
                table: "EventRegistrations",
                column: "UserId1",
                principalTable: "Registers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_TicketTypes_TicketTypeId",
                table: "EventRegistrations",
                column: "TicketTypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_EventDetails_EventId",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Registers_UserId1",
                table: "EventRegistrations");

            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_TicketTypes_TicketTypeId",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_EventId",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_TicketTypeId",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_UserId1",
                table: "EventRegistrations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0069dd40-695e-4c4a-ba98-ad5b6c722072");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "355dae81-1544-4193-960a-4cfbc40b951a");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "EventRegistrations");

            migrationBuilder.AddColumn<int>(
                name: "EventDetailId",
                table: "EventRegistrations",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8bc58d1a-acf6-4d07-93c3-daf653121db9", null, "User", "USER" },
                    { "b94abc79-cf6b-453c-93ab-3d31b3596dc1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventDetailId",
                table: "EventRegistrations",
                column: "EventDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_EventDetails_EventDetailId",
                table: "EventRegistrations",
                column: "EventDetailId",
                principalTable: "EventDetails",
                principalColumn: "Id");
        }
    }
}
