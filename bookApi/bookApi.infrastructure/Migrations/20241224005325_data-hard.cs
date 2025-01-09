using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bookApi.infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class datahard : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "book_id", "author", "cover_url", "created_at", "deleted", "description", "pages", "publish_year", "title" },
                values: new object[,]
                {
                    { 1, "J.R.R. Tolkien", "https://example.com/hobbit.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(1509), false, "A fantasy novel about a hobbit's adventure.", 310, 1937, "The Hobbit" },
                    { 2, "Frank Herbert", "https://example.com/dune.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3508), false, "A science fiction novel set on a desert planet.", 412, 1965, "Dune" },
                    { 3, "Arthur Conan Doyle", "https://example.com/hound.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3514), false, "A mystery novel featuring Sherlock Holmes.", 256, 1902, "The Hound of the Baskervilles" },
                    { 4, "Bram Stoker", "https://example.com/dracula.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3516), false, "A horror novel about Count Dracula.", 418, 1897, "Dracula" },
                    { 5, "Jane Austen", "https://example.com/pride.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3564), false, "A classic romance novel about Elizabeth Bennet.", 279, 1813, "Pride and Prejudice" },
                    { 6, "F. Scott Fitzgerald", "https://example.com/gatsby.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3566), false, "A fiction novel about the American dream.", 180, 1925, "The Great Gatsby" },
                    { 7, "George Orwell", "https://example.com/1984.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3568), false, "A dystopian novel about totalitarianism.", 328, 1949, "1984" },
                    { 8, "Cormac McCarthy", "https://example.com/road.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3604), false, "A novel about a father and son surviving in a post-apocalyptic world.", 241, 2006, "The Road" },
                    { 9, "Walter Isaacson", "https://example.com/jobs.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3606), false, "A biography of the co-founder of Apple.", 656, 2011, "Steve Jobs" },
                    { 10, "Yuval Noah Harari", "https://example.com/sapiens.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3608), false, "A history of humankind.", 443, 2011, "Sapiens" },
                    { 11, "Dale Carnegie", "https://example.com/win.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3610), false, "A classic self-help book on communication.", 288, 1936, "How to Win Friends and Influence People" },
                    { 12, "Eric Ries", "https://example.com/lean.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3612), false, "A guide to startups and innovation.", 336, 2011, "The Lean Startup" },
                    { 13, "Paulo Coelho", "https://example.com/alchemist.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3616), false, "A novel about following dreams.", 208, 1988, "The Alchemist" },
                    { 14, "Stephen King", "https://example.com/shining.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3619), false, "A horror novel about a haunted hotel.", 447, 1977, "The Shining" },
                    { 15, "Gillian Flynn", "https://example.com/gonegirl.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3620), false, "A thriller about a woman's disappearance.", 432, 2012, "Gone Girl" },
                    { 16, "Stephen Hawking", "https://example.com/briefhistory.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3623), false, "A book on cosmology and black holes.", 256, 1988, "A Brief History of Time" },
                    { 17, "Harper Lee", "https://example.com/mockingbird.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3624), false, "A novel about racial injustice in the South.", 281, 1960, "To Kill a Mockingbird" },
                    { 18, "J.D. Salinger", "https://example.com/catcher.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3626), false, "A novel about adolescent angst.", 234, 1951, "The Catcher in the Rye" },
                    { 19, "Sun Tzu", "https://example.com/artofwar.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3629), false, "An ancient Chinese text on military strategy.", 68, -500, "The Art of War" },
                    { 20, "Andy Weir", "https://example.com/martian.jpg", new DateTime(2024, 12, 24, 0, 53, 24, 578, DateTimeKind.Utc).AddTicks(3631), false, "A science fiction novel about survival on Mars.", 369, 2011, "The Martian" }
                });

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

            migrationBuilder.InsertData(
                table: "reading_statuses",
                columns: new[] { "reding_status_id", "name" },
                values: new object[,]
                {
                    { 1, "Want to read" },
                    { 2, "Reading" },
                    { 3, "Read" }
                });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                table: "genres",
                keyColumn: "genre_id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "reading_statuses",
                keyColumn: "reding_status_id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "reading_statuses",
                keyColumn: "reding_status_id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "reading_statuses",
                keyColumn: "reding_status_id",
                keyValue: 3);

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

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 1,
                columns: new[] { "created_at", "password" },
                values: new object[] { new DateTime(2024, 12, 24, 0, 38, 51, 964, DateTimeKind.Utc).AddTicks(6494), "$2a$11$.J0o3kbmT/86zABdHCPQjeEckPXihB58fXw67ht0Ut7x7MGUxHalC" });

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "user_id",
                keyValue: 2,
                columns: new[] { "created_at", "password" },
                values: new object[] { new DateTime(2024, 12, 24, 0, 38, 52, 219, DateTimeKind.Utc).AddTicks(9742), "$2a$11$nI7n.OohCdbkbHaQJysurexMUVPKFnInWaYb6vNJ13XvL2aTZckyy" });
        }
    }
}
