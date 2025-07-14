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



            base.OnModelCreating(modelBuilder);
        }




    }
}

