using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookApi.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "users",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(3131));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5083));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5088));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5090));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5224));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 7,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5227));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 8,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5255));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 9,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5258));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 10,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5261));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 11,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5263));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 12,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5266));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 13,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5275));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 14,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5276));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 15,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5278));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 16,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5280));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 17,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5282));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 18,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5471));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 19,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5473));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 20,
                column: "created_at",
                value: new DateTime(2025, 1, 26, 0, 22, 56, 221, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 1, 26, 0, 22, 55, 817, DateTimeKind.Utc).AddTicks(6865), "$2a$11$woipR5cXLRe/yuKxw2z2heEb0FiZuls2qFV6dtCkYUCDmuDU7LDmK", new DateTime(2025, 1, 26, 0, 22, 55, 817, DateTimeKind.Utc).AddTicks(6868) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 1, 26, 0, 22, 56, 61, DateTimeKind.Utc).AddTicks(2200), "$2a$11$HtF99yjoYQ.Pg9RHOZZj0eJ8xH0M.gPjLgUZ7LZ.x0r4FZtS9vKkK", new DateTime(2025, 1, 26, 0, 22, 56, 61, DateTimeKind.Utc).AddTicks(2205) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "users");

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 788, DateTimeKind.Utc).AddTicks(8779));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1359));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1367));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1418));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1420));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1422));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 7,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1424));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 8,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1464));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 9,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1466));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 10,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1468));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 11,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 12,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 13,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1478));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 14,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1480));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 15,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 16,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 17,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1486));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 18,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1488));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 19,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 20,
                column: "created_at",
                value: new DateTime(2025, 1, 13, 23, 52, 1, 789, DateTimeKind.Utc).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "created_at", "password" },
                values: new object[] { new DateTime(2025, 1, 13, 23, 52, 1, 259, DateTimeKind.Utc).AddTicks(5655), "$2a$11$AQrd1aVuW8EiqzWICPrhIOIukaWvq3Xn9nAqkPGIn2Q/B1mnSSYoe" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "created_at", "password" },
                values: new object[] { new DateTime(2025, 1, 13, 23, 52, 1, 589, DateTimeKind.Utc).AddTicks(6521), "$2a$11$UPOLDB/hbHfSS4qyiWVhjutW2Q8bj8RpD/oZRnbO4RYicpKGhSMti" });
        }
    }
}
