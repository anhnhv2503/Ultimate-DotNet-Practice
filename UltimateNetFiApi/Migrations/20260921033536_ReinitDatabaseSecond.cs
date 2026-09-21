using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateNetFiApi.Migrations
{
    /// <inheritdoc />
    public partial class ReinitDatabaseSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "16294da6-ac47-447f-8e26-7ac1a6330c81");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "51b06706-9e46-4d72-a623-e83aea5a8fed");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "431860d1-6a4f-4ef3-9042-a911a9947dc3", "18e16cff-52dc-4949-9fc6-86a2f8ffe19d", "Administrator", "ADMINISTRATOR" },
                    { "ae5af489-21cd-4e83-8cad-a65b92e7c620", "f6492468-65ae-4c51-b445-facf4edc830e", "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "431860d1-6a4f-4ef3-9042-a911a9947dc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae5af489-21cd-4e83-8cad-a65b92e7c620");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16294da6-ac47-447f-8e26-7ac1a6330c81", "66fe8e09-cc78-4b13-a28c-617582038ee4", "Manager", "MANAGER" },
                    { "51b06706-9e46-4d72-a623-e83aea5a8fed", "5b00c707-284c-4ae7-bd4b-dca9ee4ae8f0", "Administrator", "ADMINISTRATOR" }
                });
        }
    }
}
