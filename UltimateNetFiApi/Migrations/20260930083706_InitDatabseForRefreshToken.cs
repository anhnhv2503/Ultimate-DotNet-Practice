using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateNetFiApi.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabseForRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "64521a57-4129-4b3b-bbab-d8630a6d222a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9cc33d39-9f08-4bff-a31f-ea967ef0cf52");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12c9fa4e-a802-4ea1-850f-57760429c28f", "cb42ca7c-7d97-47c8-9171-77f7fc8ceeef", "Manager", "MANAGER" },
                    { "c0ce036f-1d28-4f9c-9c7f-72af57e3960d", "6e513202-cf53-4d79-b709-6067d6934cbe", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12c9fa4e-a802-4ea1-850f-57760429c28f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0ce036f-1d28-4f9c-9c7f-72af57e3960d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "64521a57-4129-4b3b-bbab-d8630a6d222a", "f379a736-6203-4b5a-9c1f-4e367475a9af", "Administrator", "ADMINISTRATOR" },
                    { "9cc33d39-9f08-4bff-a31f-ea967ef0cf52", "f77538d9-dbe7-4f83-ac04-b761f327a7a6", "Manager", "MANAGER" }
                });
        }
    }
}
