using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateNetFiApi.Migrations
{
    /// <inheritdoc />
    public partial class InitUserIdentityv2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "c555102d-fac1-45c5-9691-f4cfb43f2dd1", "86323e6f-8318-4660-a7d5-f098af0161d2", "Administrator", "ADMINISTRATOR" },
                    { "e47e76db-d0b0-4304-967b-4233897d8440", "a4f7dd2b-e076-4439-9bee-a6d1112be8c6", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c555102d-fac1-45c5-9691-f4cfb43f2dd1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e47e76db-d0b0-4304-967b-4233897d8440");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "80b1e7af-ab1f-4ad0-b9fb-1b80adb09e4f", "e33589dd-9510-453a-9dfa-15a1aef4991f", "Administrator", "ADMINISTRATOR" },
                    { "f2637ef0-7d5c-4a5f-96b0-bebbd07cb698", "81ff82c2-a7a4-46ca-a18f-8086f70d3d49", "Manager", "MANAGER" }
                });
        }
    }
}
