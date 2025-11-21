using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StoreApp.Migrations
{
    /// <inheritdoc />
    public partial class IdentityRoleSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7179438c-8613-4eb6-89d2-9161e2de863b", null, "Editor", "EDITOR" },
                    { "b062b766-7462-425c-aac3-3c3d8a327757", null, "Admin", "ADMIN" },
                    { "e28cc0fe-b4c5-4d59-9402-5c1d669267b2", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7179438c-8613-4eb6-89d2-9161e2de863b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b062b766-7462-425c-aac3-3c3d8a327757");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e28cc0fe-b4c5-4d59-9402-5c1d669267b2");
        }
    }
}
