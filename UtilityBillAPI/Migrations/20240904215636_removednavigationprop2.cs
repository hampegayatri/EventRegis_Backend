using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class removednavigationprop2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_EventDetails_EventId",
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

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4564e8cf-6753-4d90-8cf3-e6fb81fa46d1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ca3398a1-dbc6-4dfe-bdb8-036f03e31de1");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4564e8cf-6753-4d90-8cf3-e6fb81fa46d1", null, "User", "USER" },
                    { "ca3398a1-dbc6-4dfe-bdb8-036f03e31de1", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_EventId",
                table: "EventRegistrations",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_TicketTypeId",
                table: "EventRegistrations",
                column: "TicketTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_EventDetails_EventId",
                table: "EventRegistrations",
                column: "EventId",
                principalTable: "EventDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_TicketTypes_TicketTypeId",
                table: "EventRegistrations",
                column: "TicketTypeId",
                principalTable: "TicketTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
