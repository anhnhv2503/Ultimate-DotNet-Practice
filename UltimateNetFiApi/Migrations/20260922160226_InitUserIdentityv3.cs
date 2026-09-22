using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateNetFiApi.Migrations
{
    /// <inheritdoc />
    public partial class InitUserIdentityv3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "b3ffb4fc-e12c-40e6-a4f3-4ff2755d8217", "ce334fe3-145c-48a4-b6f9-231418197c49", "Manager", "MANAGER" },
                    { "fa325708-91ab-49b9-8472-9e45bb0383c2", "2b01b19c-643e-49ad-b983-3103f8692bda", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b3ffb4fc-e12c-40e6-a4f3-4ff2755d8217");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa325708-91ab-49b9-8472-9e45bb0383c2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "c555102d-fac1-45c5-9691-f4cfb43f2dd1", "86323e6f-8318-4660-a7d5-f098af0161d2", "Administrator", "ADMINISTRATOR" },
                    { "e47e76db-d0b0-4304-967b-4233897d8440", "a4f7dd2b-e076-4439-9bee-a6d1112be8c6", "Manager", "MANAGER" }
                });
        }
    }
}
