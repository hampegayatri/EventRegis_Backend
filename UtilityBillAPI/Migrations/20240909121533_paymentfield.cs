using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class paymentfield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84518fd5-93c1-42c4-9295-322963ebd018");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ba541d2-bbe9-4673-9ce0-c7088843a5b3");

            migrationBuilder.DropColumn(
                name: "NumberOfTickets",
                table: "Payments");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9466c678-a943-440c-a23b-615fc5889acb", null, "User", "USER" },
                    { "98e525f0-453e-41b3-9f76-2b9c59803f50", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9466c678-a943-440c-a23b-615fc5889acb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "98e525f0-453e-41b3-9f76-2b9c59803f50");

            migrationBuilder.AddColumn<int>(
                name: "NumberOfTickets",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "84518fd5-93c1-42c4-9295-322963ebd018", null, "Admin", "ADMIN" },
                    { "8ba541d2-bbe9-4673-9ce0-c7088843a5b3", null, "User", "USER" }
                });
        }
    }
}
