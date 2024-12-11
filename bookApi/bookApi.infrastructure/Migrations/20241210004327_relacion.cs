using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookApi.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class relacion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 4, 4 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 5, 6 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 6, 5 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 7, 2 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 8, 7 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 9, 8 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 10, 10 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 11, 9 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 12, 10 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 13, 1 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 14, 4 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 15, 3 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 16, 10 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 17, 1 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 18, 1 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 19, 10 });

            migrationBuilder.DeleteData(
                table: "book_genre",
                keyColumns: new[] { "book_id", "genre_id" },
                keyValues: new object[] { 20, 2 });

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "books",
                keyColumn: "book_id",
                keyValue: 20);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "book_id", "author", "cover_url", "created_at", "deleted", "description", "pages", "publish_year", "title" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", "https://example.com/hobbit.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(1292), false, "A fantasy novel about a hobbit's adventure.", 310, 1937, "The Hobbit" },
                    { 2, "Frank Herbert", "https://example.com/dune.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3381), false, "A science fiction novel set on a desert planet.", 412, 1965, "Dune" },
                    { 3, "Arthur Conan Doyle", "https://example.com/hound.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3385), false, "A mystery novel featuring Sherlock Holmes.", 256, 1902, "The Hound of the Baskervilles" },
                    { 4, "Bram Stoker", "https://example.com/dracula.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3387), false, "A horror novel about Count Dracula.", 418, 1897, "Dracula" },
                    { 5, "Jane Austen", "https://example.com/pride.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3389), false, "A classic romance novel about Elizabeth Bennet.", 279, 1813, "Pride and Prejudice" },
                    { 6, "F. Scott Fitzgerald", "https://example.com/gatsby.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3391), false, "A fiction novel about the American dream.", 180, 1925, "The Great Gatsby" },
                    { 7, "George Orwell", "https://example.com/1984.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3392), false, "A dystopian novel about totalitarianism.", 328, 1949, "1984" },
                    { 8, "Cormac McCarthy", "https://example.com/road.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3394), false, "A novel about a father and son surviving in a post-apocalyptic world.", 241, 2006, "The Road" },
                    { 9, "Walter Isaacson", "https://example.com/jobs.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3396), false, "A biography of the co-founder of Apple.", 656, 2011, "Steve Jobs" },
                    { 10, "Yuval Noah Harari", "https://example.com/sapiens.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3397), false, "A history of humankind.", 443, 2011, "Sapiens" },
                    { 11, "Dale Carnegie", "https://example.com/win.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3429), false, "A classic self-help book on communication.", 288, 1936, "How to Win Friends and Influence People" },
                    { 12, "Eric Ries", "https://example.com/lean.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3431), false, "A guide to startups and innovation.", 336, 2011, "The Lean Startup" },
                    { 13, "Paulo Coelho", "https://example.com/alchemist.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3432), false, "A novel about following dreams.", 208, 1988, "The Alchemist" },
                    { 14, "Stephen King", "https://example.com/shining.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3436), false, "A horror novel about a haunted hotel.", 447, 1977, "The Shining" },
                    { 15, "Gillian Flynn", "https://example.com/gonegirl.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3438), false, "A thriller about a woman's disappearance.", 432, 2012, "Gone Girl" },
                    { 16, "Stephen Hawking", "https://example.com/briefhistory.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3439), false, "A book on cosmology and black holes.", 256, 1988, "A Brief History of Time" },
                    { 17, "Harper Lee", "https://example.com/mockingbird.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3441), false, "A novel about racial injustice in the South.", 281, 1960, "To Kill a Mockingbird" },
                    { 18, "J.D. Salinger", "https://example.com/catcher.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3443), false, "A novel about adolescent angst.", 234, 1951, "The Catcher in the Rye" },
                    { 19, "Sun Tzu", "https://example.com/artofwar.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3444), false, "An ancient Chinese text on military strategy.", 68, -500, "The Art of War" },
                    { 20, "Andy Weir", "https://example.com/martian.jpg", new DateTime(2024, 12, 10, 0, 22, 43, 734, DateTimeKind.Utc).AddTicks(3446), false, "A science fiction novel about survival on Mars.", 369, 2011, "The Martian" }
                });

            migrationBuilder.InsertData(
                table: "book_genre",
                columns: new[] { "book_id", "genre_id" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 },
                    { 5, 6 },
                    { 6, 5 },
                    { 7, 2 },
                    { 8, 7 },
                    { 9, 8 },
                    { 10, 10 },
                    { 11, 9 },
                    { 12, 10 },
                    { 13, 1 },
                    { 14, 4 },
                    { 15, 3 },
                    { 16, 10 },
                    { 17, 1 },
                    { 18, 1 },
                    { 19, 10 },
                    { 20, 2 }
                });
        }
    }
}
