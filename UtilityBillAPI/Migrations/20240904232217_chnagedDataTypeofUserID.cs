using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class chnagedDataTypeofUserID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Registers_UserId1",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_UserId1",
                table: "EventRegistrations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0bc98eb1-87d3-47b6-baab-6c2e5db1c861");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "40156523-3512-450b-9fcf-c0eb95d5dde6");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "EventRegistrations");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "EventRegistrations",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5ac7886c-47a7-4b23-a1e0-36daa9c6ac34", null, "User", "USER" },
                    { "6539a8da-f969-4f3d-82dd-ef6a429a9c8a", null, "Admin", "ADMIN" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_UserId",
                table: "EventRegistrations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Registers_UserId",
                table: "EventRegistrations",
                column: "UserId",
                principalTable: "Registers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRegistrations_Registers_UserId",
                table: "EventRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_EventRegistrations_UserId",
                table: "EventRegistrations");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ac7886c-47a7-4b23-a1e0-36daa9c6ac34");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6539a8da-f969-4f3d-82dd-ef6a429a9c8a");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "EventRegistrations",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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
                    { "0bc98eb1-87d3-47b6-baab-6c2e5db1c861", null, "Admin", "ADMIN" },
                    { "40156523-3512-450b-9fcf-c0eb95d5dde6", null, "User", "USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventRegistrations_UserId1",
                table: "EventRegistrations",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRegistrations_Registers_UserId1",
                table: "EventRegistrations",
                column: "UserId1",
                principalTable: "Registers",
                principalColumn: "Id");
        }
    }
}
