using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateNetFiApi.Migrations
{
    /// <inheritdoc />
    public partial class ReInitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "44367819-c890-4332-9069-f71896bc16df");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "855067ee-f3f9-4f97-be33-4121d9635e9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "16294da6-ac47-447f-8e26-7ac1a6330c81", "66fe8e09-cc78-4b13-a28c-617582038ee4", "Manager", "MANAGER" },
                    { "51b06706-9e46-4d72-a623-e83aea5a8fed", "5b00c707-284c-4ae7-bd4b-dca9ee4ae8f0", "Administrator", "ADMINISTRATOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                    { "44367819-c890-4332-9069-f71896bc16df", "358900bd-0e27-4726-be22-88067238807d", "Administrator", "ADMINISTRATOR" },
                    { "855067ee-f3f9-4f97-be33-4121d9635e9d", "9953d307-5040-4e01-aa90-30d40c4326e7", "Manager", "MANAGER" }
                });
        }
    }
}
