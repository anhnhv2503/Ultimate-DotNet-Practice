using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateNetFiApi.Migrations
{
    /// <inheritdoc />
    public partial class InitUserIdentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "93b89105-ae24-461b-8521-109a1f4e5e2d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ada7e5e8-f894-40d1-8139-4aada11ca2c0");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80b1e7af-ab1f-4ad0-b9fb-1b80adb09e4f", "e33589dd-9510-453a-9dfa-15a1aef4991f", "Administrator", "ADMINISTRATOR" },
                    { "f2637ef0-7d5c-4a5f-96b0-bebbd07cb698", "81ff82c2-a7a4-46ca-a18f-8086f70d3d49", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "80b1e7af-ab1f-4ad0-b9fb-1b80adb09e4f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2637ef0-7d5c-4a5f-96b0-bebbd07cb698");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "93b89105-ae24-461b-8521-109a1f4e5e2d", "294b0268-9fa9-4002-9682-b231405fde11", "Administrator", "ADMINISTRATOR" },
                    { "ada7e5e8-f894-40d1-8139-4aada11ca2c0", "d32aef8c-b374-49bb-9cc9-e0f6da19d27c", "Manager", "MANAGER" }
                });
        }
    }
}
