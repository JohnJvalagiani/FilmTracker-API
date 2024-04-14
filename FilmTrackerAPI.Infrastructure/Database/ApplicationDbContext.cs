using Microsoft.EntityFrameworkCore;
using FilmTrackerAPI.Domain.Entities;

namespace FilmTrackerAPI.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieWatchlist> MovieWatchlists { get; set; } // For many-to-many join table


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasMany(u => u.Watchlists)
                .WithOne(w => w.User)
                .HasForeignKey(w => w.UserId);

            // Many-to-Many relationship between Movie and Watchlist
            modelBuilder.Entity<MovieWatchlist>()
                .HasKey(mw => new { mw.MovieId, mw.WatchlistId });

            modelBuilder.Entity<MovieWatchlist>()
                .HasOne(mw => mw.Movie)
                .WithMany(m => m.MovieWatchlists)
                .HasForeignKey(mw => mw.MovieId);

            modelBuilder.Entity<MovieWatchlist>()
                .HasOne(mw => mw.Watchlist)
                .WithMany(w => w.MovieWatchlists)
                .HasForeignKey(mw => mw.WatchlistId);

            modelBuilder.Entity<User>().HasData(
         new User { Id = 1, Name = "John Doe" }
     );

            modelBuilder.Entity<Watchlist>().HasData(
                new Watchlist { Id = 1, Name = "John's Favorite Movies", UserId = 1 }
            );

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "Inception", Description = "A thief who steals corporate secrets through dream-sharing technology.", ReleaseDate = DateTime.Parse("2010-07-16"), Genre = "Sci-Fi", IsWatched = false },
                new Movie { Id = 2, Title = "The Matrix", Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", ReleaseDate = DateTime.Parse("1999-03-31"), Genre = "Action", IsWatched = false }
            );

            modelBuilder.Entity<MovieWatchlist>().HasData(
                new MovieWatchlist { MovieId = 1, WatchlistId = 1 }
            );
        }
    }
}
