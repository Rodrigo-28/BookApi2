using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace bookApi.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class likeAndReview : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "reviews",
                columns: table => new
                {
                    review_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    content = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    book_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reviews", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_reviews_books_book_id",
                        column: x => x.book_id,
                        principalTable: "books",
                        principalColumn: "book_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_reviews_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "likes",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    review_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_likes", x => new { x.user_id, x.review_id });
                    table.ForeignKey(
                        name: "FK_likes_reviews_review_id",
                        column: x => x.review_id,
                        principalTable: "reviews",
                        principalColumn: "review_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_likes_users_user_id",
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

            migrationBuilder.CreateIndex(
                name: "IX_likes_review_id",
                table: "likes",
                column: "review_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_book_id",
                table: "reviews",
                column: "book_id");

            migrationBuilder.CreateIndex(
                name: "IX_reviews_user_id_book_id",
                table: "reviews",
                columns: new[] { "user_id", "book_id" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "likes");

            migrationBuilder.DropTable(
                name: "reviews");

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 1,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(1509));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 2,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3508));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 3,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3514));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 4,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3516));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 5,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3564));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 6,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 7,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3568));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 8,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3604));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 9,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3606));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 10,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3608));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 11,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3610));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 12,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3612));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 13,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3616));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 14,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3619));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 15,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3620));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 16,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3623));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 17,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3624));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 18,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3626));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 19,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3629));

            migrationBuilder.UpdateData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 20,
                column: "created_at",
                value: new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3631));

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "created_at", "password" },
                values: new object[] { new DateTime(2024, 12, 24, 0, 53, 24, 25, DateTimeKind.Utc).AddTicks(5761), "$2a$11$lpOgwTwEsaM8tDlPqimRr.En7QFH6uAGOF6PHyEAzpNXlNIMCnllm" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "created_at", "password" },
                values: new object[] { new DateTime(2024, 12, 24, 0, 53, 24, 378, DateTimeKind.Utc).AddTicks(8120), "$2a$11$4KJVsjTSzEgvwKXAmzcrKeir1AjiqWhQnnvpq4T06gzEK.yJyqYs6" });
        }
    }
}
