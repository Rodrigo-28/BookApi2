using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookApi.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class user : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "created_at", "deleted", "email", "password", "role_id", "username" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 24, 0, 38, 51, 964, DateTimeKind.Utc).AddTicks(6494), false, "admin@admin.com", "$2a$11$.J0o3kbmT/86zABdHCPQjeEckPXihB58fXw67ht0Ut7x7MGUxHalC", 1, "admin" },
                    { 2, new DateTime(2024, 12, 24, 0, 38, 52, 219, DateTimeKind.Utc).AddTicks(9742), false, "user@user.com", "$2a$11$nI7n.OohCdbkbHaQJysurexMUVPKFnInWaYb6vNJ13XvL2aTZckyy", 2, "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2);
        }
    }
}
