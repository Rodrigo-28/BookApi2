using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bookApi.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 336, DateTimeKind.Utc).AddTicks(9302));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1147));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1152));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1155));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1157));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1253));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 7,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1256));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 8,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1259));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 9,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1470));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 10,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1472));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 11,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1475));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 12,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1477));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 13,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1482));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 14,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1484));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 15,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1490));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 16,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1492));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 17,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 18,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1496));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 19,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1499));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 20,
                column: "created_at",
                value: new DateTime(2025, 9, 11, 15, 16, 30, 337, DateTimeKind.Utc).AddTicks(1501));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 9, 11, 15, 16, 29, 844, DateTimeKind.Utc).AddTicks(3775), "$2a$11$XXRbyOYg8x0AD9gjAZo2yOP945FZcArrKw7PipzXAgRmd2YCeMhyO", new DateTime(2025, 9, 11, 15, 16, 29, 844, DateTimeKind.Utc).AddTicks(3777) });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "created_at", "password", "updated_at" },
                values: new object[] { new DateTime(2025, 9, 11, 15, 16, 30, 179, DateTimeKind.Utc).AddTicks(9417), "$2a$11$/TQJLOG1.0LtAWkl7WRIjevA6EItYec.5cbYyey8zJHEqhF3GLtvK", new DateTime(2025, 9, 11, 15, 16, 30, 179, DateTimeKind.Utc).AddTicks(9424) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
