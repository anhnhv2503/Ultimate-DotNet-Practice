using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateNetFiApi.Migrations
{
    /// <inheritdoc />
    public partial class InsertRefreshToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "308a17f2-da34-48a1-a6d8-cae48e8914fe", "d4f14573-9a86-4941-9fc3-55d6b6aa31da", "Manager", "MANAGER" },
                    { "5a1f9cf8-dcdc-4ef1-9b31-3d6faecb3164", "d7113c25-ec0d-4c20-8b0a-3709f2f6e718", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "308a17f2-da34-48a1-a6d8-cae48e8914fe");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a1f9cf8-dcdc-4ef1-9b31-3d6faecb3164");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "12c9fa4e-a802-4ea1-850f-57760429c28f", "cb42ca7c-7d97-47c8-9171-77f7fc8ceeef", "Manager", "MANAGER" },
                    { "c0ce036f-1d28-4f9c-9c7f-72af57e3960d", "6e513202-cf53-4d79-b709-6067d6934cbe", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
