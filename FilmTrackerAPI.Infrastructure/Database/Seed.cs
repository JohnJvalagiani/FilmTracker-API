using FilmTrackerAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FilmTrackerAPI.Infrastructure.Data.Seed
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasData(
                new Movie { Id = 1, Title = "Inception", Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO.", ReleaseDate = new DateTime(2010, 7, 16), Genre = "Sci-Fi", IsWatched = false },
                new Movie { Id = 2, Title = "The Matrix", Description = "A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.", ReleaseDate = new DateTime(1999, 3, 31), Genre = "Action", IsWatched = false }
            );
        }
    }

    public class WatchlistConfiguration : IEntityTypeConfiguration<Watchlist>
    {
        public void Configure(EntityTypeBuilder<Watchlist> builder)
        {
            builder.HasData(
                new Watchlist { Id = 1, Name = "John's Watchlist", UserId = "some-user-id" }
            );
        }
    }
}
