using Microsoft.EntityFrameworkCore;
using FilmTrackerAPI.Domain.Entities;
using FilmTrackerAPI.Infrastructure.Data.Seed;

namespace FilmTrackerAPI.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Watchlist> Watchlists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Movie>(entity =>
            {
                entity.HasOne(m => m.Watchlist)
                      .WithMany(w => w.Movies)
                      .HasForeignKey(m => m.WatchlistId)
                      .OnDelete(DeleteBehavior.Cascade); 
            });

            modelBuilder.Entity<Watchlist>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

                // Assuming you have a User entity, you would configure it similarly
                // entity.HasOne(w => w.User)
                //     .WithMany(u => u.Watchlists)
                //     .HasForeignKey(w => w.UserId);
            });

            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new WatchlistConfiguration());
        }
    }
}
