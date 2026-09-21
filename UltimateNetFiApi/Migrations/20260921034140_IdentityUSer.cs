using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UltimateNetFiApi.Migrations
{
    /// <inheritdoc />
    public partial class IdentityUSer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "431860d1-6a4f-4ef3-9042-a911a9947dc3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae5af489-21cd-4e83-8cad-a65b92e7c620");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "431860d1-6a4f-4ef3-9042-a911a9947dc3", "18e16cff-52dc-4949-9fc6-86a2f8ffe19d", "Administrator", "ADMINISTRATOR" },
                    { "ae5af489-21cd-4e83-8cad-a65b92e7c620", "f6492468-65ae-4c51-b445-facf4edc830e", "Manager", "MANAGER" }
                });
        }
    }
}
