using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class tickettypetablechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7b96d209-f5b3-44c5-b3cd-8f151392341f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "aac2fee7-9026-4941-819e-ea1043a27a2d");

            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "EventDetails");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "EventDetails");

            migrationBuilder.AddColumn<int>(
                name: "EventId",
                table: "TicketTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MaxCapacity",
                table: "TicketTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d6d688a-ae91-48b3-917c-855e82e88ac2", null, "Admin", "ADMIN" },
                    { "78d0a782-c866-47de-8529-a1e2f2fc72b8", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d6d688a-ae91-48b3-917c-855e82e88ac2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "78d0a782-c866-47de-8529-a1e2f2fc72b8");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "TicketTypes");

            migrationBuilder.DropColumn(
                name: "MaxCapacity",
                table: "TicketTypes");

            migrationBuilder.AddColumn<int>(
                name: "MaxCapacity",
                table: "EventDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "EventDetails",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7b96d209-f5b3-44c5-b3cd-8f151392341f", null, "Admin", "ADMIN" },
                    { "aac2fee7-9026-4941-819e-ea1043a27a2d", null, "User", "USER" }
                });
        }
    }
}
