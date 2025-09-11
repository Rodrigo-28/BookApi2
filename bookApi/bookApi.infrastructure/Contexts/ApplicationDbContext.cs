using bookApi.Domian.Models;
using Microsoft.EntityFrameworkCore;

namespace bookApi.infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {


        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<UserBook> UserBooks { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }


        public DbSet<ReadingStatus> ReadingStatuses { get; set; }



        public DbSet<BookGenre> BookGenres { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Book)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(b => b.BookId);
            modelBuilder.Entity<BookGenre>()
                .HasOne(bg => bg.Genre)
                .WithMany(b => b.BookGenres)
                .HasForeignKey(b => b.GenreId);
            //user books

            modelBuilder.Entity<UserBook>()
                 .HasOne(ub => ub.User)
                 .WithMany(b => b.UserBooks)
                 .HasForeignKey(ub => ub.UserId);


            modelBuilder.Entity<UserBook>()
              .HasOne(ub => ub.Book)
              .WithMany(b => b.UserBooks)
              .HasForeignKey(ub => ub.BookId);

            modelBuilder.Entity<UserBook>()
                .HasOne(ub => ub.ReadingStatus)
                .WithMany(rs => rs.UserBooks)
                .HasForeignKey(ub => ub.ReadingStatusId);
            //Configure relationships
            modelBuilder.Entity<Like>()
                .HasOne(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId);
            modelBuilder.Entity<Like>()
                .HasOne(l => l.Review)
                .WithMany(r => r.Likes)
                .HasForeignKey(l => l.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);
            // composite key for like table
            modelBuilder.Entity<Like>()
                .HasKey(l => new { l.UserId, l.ReviewId });


            // configure the composite key for the bookGenre join table
            modelBuilder.Entity<BookGenre>()
             .HasKey(bg => new { bg.BookId, bg.GenreId });
            modelBuilder.Entity<BookGenre>()
            .HasIndex(bg => new { bg.BookId, bg.GenreId });

            // configure the composite key for userbook table
            modelBuilder.Entity<UserBook>()
                .HasKey(ub => new { ub.UserId, ub.BookId });
            // Composite index for UserBook to optimize queries on UserId and BookId
            modelBuilder.Entity<UserBook>()
            .HasIndex(ub => new { ub.UserId, ub.BookId });

            //review
            modelBuilder.Entity<Review>()
               .HasIndex(r => new { r.UserId, r.BookId })
               .IsUnique();

            //comment
            modelBuilder.Entity<Comment>()
           .HasOne(c => c.Review)
           .WithMany(r => r.Comments)
           .HasForeignKey(c => c.ReviewId)
           .OnDelete(DeleteBehavior.Cascade);


            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
              new Role { Id = 1, Name = "admin" },
              new Role { Id = 2, Name = "user" }

         );

            modelBuilder.Entity<User>().HasData(
                   new User { Id = 1, Username = "admin", Email = "admin@admin.com", Password = _passwordEncryptionService.HashPassword("123456$Admin"), RoleId = (int)UserRole.Admin },
                   new User { Id = 2, Username = "user", Email = "user@user.com", Password = _passwordEncryptionService.HashPassword("123456$User"), RoleId = (int)UserRole.User }
                );
            modelBuilder.Entity<Genre>().HasData(
            new Genre { Id = 1, Name = "fantasy" },
            new Genre { Id = 2, Name = "Science Fiction" },
            new Genre { Id = 3, Name = "Mystery" },
            new Genre { Id = 4, Name = "Horror" },
            new Genre { Id = 5, Name = "Fiction" },
            new Genre { Id = 6, Name = "Romance" },
            new Genre { Id = 7, Name = "Short Story" },
            new Genre { Id = 8, Name = "Biography" },
            new Genre { Id = 9, Name = "self-help" },
            new Genre { Id = 10, Name = "History" },
            new Genre { Id = 11, Name = "Technology" }
           );

            modelBuilder.Entity<ReadingStatus>().HasData(
          new ReadingStatus { Id = 1, Name = "Want to read" },
          new ReadingStatus { Id = 2, Name = "Reading" },
          new ReadingStatus { Id = 3, Name = "Read" }
            );
            modelBuilder.Entity<Book>().HasData(
     new Book { Id = 1, Title = "The Hobbit", Author = "J.R.R. Tolkien", PublishYear = 1937, Description = "A fantasy novel about a hobbit's adventure.", CoverUrl = "https://example.com/hobbit.jpg", PageCount = 310 },
     new Book { Id = 2, Title = "Dune", Author = "Frank Herbert", PublishYear = 1965, Description = "A science fiction novel set on a desert planet.", CoverUrl = "https://example.com/dune.jpg", PageCount = 412 },
     new Book { Id = 3, Title = "The Hound of the Baskervilles", Author = "Arthur Conan Doyle", PublishYear = 1902, Description = "A mystery novel featuring Sherlock Holmes.", CoverUrl = "https://example.com/hound.jpg", PageCount = 256 },
     new Book { Id = 4, Title = "Dracula", Author = "Bram Stoker", PublishYear = 1897, Description = "A horror novel about Count Dracula.", CoverUrl = "https://example.com/dracula.jpg", PageCount = 418 },
     new Book { Id = 5, Title = "Pride and Prejudice", Author = "Jane Austen", PublishYear = 1813, Description = "A classic romance novel about Elizabeth Bennet.", CoverUrl = "https://example.com/pride.jpg", PageCount = 279 },
     new Book { Id = 6, Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", PublishYear = 1925, Description = "A fiction novel about the American dream.", CoverUrl = "https://example.com/gatsby.jpg", PageCount = 180 },
     new Book { Id = 7, Title = "1984", Author = "George Orwell", PublishYear = 1949, Description = "A dystopian novel about totalitarianism.", CoverUrl = "https://example.com/1984.jpg", PageCount = 328 },
     new Book { Id = 8, Title = "The Road", Author = "Cormac McCarthy", PublishYear = 2006, Description = "A novel about a father and son surviving in a post-apocalyptic world.", CoverUrl = "https://example.com/road.jpg", PageCount = 241 },
     new Book { Id = 9, Title = "Steve Jobs", Author = "Walter Isaacson", PublishYear = 2011, Description = "A biography of the co-founder of Apple.", CoverUrl = "https://example.com/jobs.jpg", PageCount = 656 },
     new Book { Id = 10, Title = "Sapiens", Author = "Yuval Noah Harari", PublishYear = 2011, Description = "A history of humankind.", CoverUrl = "https://example.com/sapiens.jpg", PageCount = 443 },
     new Book { Id = 11, Title = "How to Win Friends and Influence People", Author = "Dale Carnegie", PublishYear = 1936, Description = "A classic self-help book on communication.", CoverUrl = "https://example.com/win.jpg", PageCount = 288 },
     new Book { Id = 12, Title = "The Lean Startup", Author = "Eric Ries", PublishYear = 2011, Description = "A guide to startups and innovation.", CoverUrl = "https://example.com/lean.jpg", PageCount = 336 },
     new Book { Id = 13, Title = "The Alchemist", Author = "Paulo Coelho", PublishYear = 1988, Description = "A novel about following dreams.", CoverUrl = "https://example.com/alchemist.jpg", PageCount = 208 },
     new Book { Id = 14, Title = "The Shining", Author = "Stephen King", PublishYear = 1977, Description = "A horror novel about a haunted hotel.", CoverUrl = "https://example.com/shining.jpg", PageCount = 447 },
     new Book { Id = 15, Title = "Gone Girl", Author = "Gillian Flynn", PublishYear = 2012, Description = "A thriller about a woman's disappearance.", CoverUrl = "https://example.com/gonegirl.jpg", PageCount = 432 },
     new Book { Id = 16, Title = "A Brief History of Time", Author = "Stephen Hawking", PublishYear = 1988, Description = "A book on cosmology and black holes.", CoverUrl = "https://example.com/briefhistory.jpg", PageCount = 256 },
     new Book { Id = 17, Title = "To Kill a Mockingbird", Author = "Harper Lee", PublishYear = 1960, Description = "A novel about racial injustice in the South.", CoverUrl = "https://example.com/mockingbird.jpg", PageCount = 281 },
     new Book { Id = 18, Title = "The Catcher in the Rye", Author = "J.D. Salinger", PublishYear = 1951, Description = "A novel about adolescent angst.", CoverUrl = "https://example.com/catcher.jpg", PageCount = 234 },
     new Book { Id = 19, Title = "The Art of War", Author = "Sun Tzu", PublishYear = -500, Description = "An ancient Chinese text on military strategy.", CoverUrl = "https://example.com/artofwar.jpg", PageCount = 68 },
     new Book { Id = 20, Title = "The Martian", Author = "Andy Weir", PublishYear = 2011, Description = "A science fiction novel about survival on Mars.", CoverUrl = "https://example.com/martian.jpg", PageCount = 369 }
 // Add more books as needed
 );
            modelBuilder.Entity<BookGenre>().HasData(
                // Linking Books to Genres
                new BookGenre { BookId = 1, GenreId = 1 }, // The Hobbit - Fantasy
                new BookGenre { BookId = 2, GenreId = 2 }, // Dune - Science Fiction
                new BookGenre { BookId = 3, GenreId = 3 }, // The Hound of the Baskervilles - Mystery
                new BookGenre { BookId = 4, GenreId = 4 }, // Dracula - Horror
                new BookGenre { BookId = 5, GenreId = 6 }, // Pride and Prejudice - Romance
                new BookGenre { BookId = 6, GenreId = 5 }, // The Great Gatsby - Fiction
                new BookGenre { BookId = 7, GenreId = 2 }, // 1984 - Science Fiction
                new BookGenre { BookId = 8, GenreId = 7 }, // The Road - Short Story
                new BookGenre { BookId = 9, GenreId = 8 }, // Steve Jobs - Biography
                new BookGenre { BookId = 10, GenreId = 10 }, // Sapiens - History
                new BookGenre { BookId = 11, GenreId = 9 }, // How to Win Friends and Influence People - Self-help
                new BookGenre { BookId = 12, GenreId = 10 }, // The Lean Startup - History
                new BookGenre { BookId = 13, GenreId = 1 }, // The Alchemist - Fantasy
                new BookGenre { BookId = 14, GenreId = 4 }, // The Shining - Horror
                new BookGenre { BookId = 15, GenreId = 3 }, // Gone Girl - Mystery
                new BookGenre { BookId = 16, GenreId = 10 }, // A Brief History of Time - History
                new BookGenre { BookId = 17, GenreId = 1 }, // To Kill a Mockingbird - Fantasy
                new BookGenre { BookId = 18, GenreId = 1 }, // The Catcher in the Rye - Fantasy
                new BookGenre { BookId = 19, GenreId = 10 }, // The Art of War - History
                new BookGenre { BookId = 20, GenreId = 2 }  // The Martian - Science Fiction
            );



        }
    }

