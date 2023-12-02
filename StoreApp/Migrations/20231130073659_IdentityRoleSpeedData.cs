using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSpeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "53983fd5-337f-4fe8-9b9e-12a3e757434e", null, "User", "USER" },
                    { "5dbf9c1d-b21d-4016-b7af-f94ced3218fd", null, "Admin", "ADMIN" },
                    { "72fecb1d-dc9f-4d2a-9962-4c678dacb6ca", null, "Editor", "EDITOR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "53983fd5-337f-4fe8-9b9e-12a3e757434e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5dbf9c1d-b21d-4016-b7af-f94ced3218fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72fecb1d-dc9f-4d2a-9962-4c678dacb6ca");
        }
    }
}
