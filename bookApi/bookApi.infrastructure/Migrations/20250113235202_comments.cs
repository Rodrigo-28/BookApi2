using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bookApi.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class comments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    comment_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    review_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.comment_id);
                    table.ForeignKey(
                        name: "FK_comments_reviews_review_id",
                        column: x => x.review_id,
                        principalTable: "reviews",
                        principalColumn: "review_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comments_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_comments_review_id",
                table: "comments",
                column: "review_id");

            migrationBuilder.CreateIndex(
                name: "IX_comments_user_id",
                table: "comments",
                column: "user_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 678, DateTimeKind.Utc).AddTicks(8255));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1604));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1616));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1619));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1621));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1624));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 7,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 8,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1641));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 9,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1643));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 10,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1698));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 11,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1701));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 12,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 13,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1710));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 14,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1713));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 15,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1715));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 16,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1717));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 17,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1720));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 18,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1722));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 19,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1724));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 20,
                column: "created_at",
                value: new DateTime(2025, 1, 10, 0, 44, 43, 679, DateTimeKind.Utc).AddTicks(1726));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "created_at", "password" },
                values: new object[] { new DateTime(2025, 1, 10, 0, 44, 43, 124, DateTimeKind.Utc).AddTicks(7504), "$2a$11$y2MyLcGp554ZFAQoo1Z19uHmsYERPyGB/UHp7RJYPVpxdm1rwpvnW" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "created_at", "password" },
                values: new object[] { new DateTime(2025, 1, 10, 0, 44, 43, 474, DateTimeKind.Utc).AddTicks(4328), "$2a$11$7j/hHQknwz4pYckgyYS.I.Ir/n0ibxzZuKqx3yf2epGsx8JLSkevi" });
        }
    }
}
