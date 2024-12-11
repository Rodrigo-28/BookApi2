using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookApi.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Genredata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "genre_id", "name" },
                values: new object[,]
                {
                    { 1, "fantasy" },
                    { 2, "Science Fiction" },
                    { 3, "Mystery" },
                    { 4, "Horror" },
                    { 5, "Fiction" },
                    { 6, "Romance" },
                    { 7, "Short Story" },
                    { 8, "Biography" },
                    { 9, "self-help" },
                    { 10, "History" },
                    { 11, "Technology" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 11);
        }
    }
}
