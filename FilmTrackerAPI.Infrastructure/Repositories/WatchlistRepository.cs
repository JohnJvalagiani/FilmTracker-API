using Azure.Core;
using Common.Exceptions;
using FilmTrackerAPI.Domain.Entities;
using FilmTrackerAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Infrastructure.Repositories
{
    public class WatchlistRepository(ApplicationDbContext context) : IWatchlistRepository
    {
        public async Task MarkMovieAsWatchedAsync(int userId, int watchlistId, int movieId)
        {
            var watchlist = await context.Watchlists
                                          .Include(w => w.MovieWatchlists)
                                          .FirstOrDefaultAsync(w => w.Id == watchlistId && w.UserId == userId);

            if (watchlist == null)
            {
                throw new NotFoundException("Watchlist not found.");
            }

            var movieWatchlist = watchlist.MovieWatchlists.FirstOrDefault(mw => mw.MovieId == movieId);
            if (movieWatchlist == null)
            {
                throw new NotFoundException("Movie not found in the specified watchlist.");
            }

            var movie = await context.Movies.FindAsync(movieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found.");
            }

            movie.IsWatched = true;
            await context.SaveChangesAsync();
        }
        public async Task AddMovieToWatchlistAsync(int userId, int watchlistId, int movieId)
        {

            var watchlist = await context.Watchlists
                                          .Include(w => w.MovieWatchlists)
                                          .FirstOrDefaultAsync(w => w.Id == watchlistId);

            if (watchlist == null)
            {
                throw new NotFoundException("Watchlist not found.");
            }

            if (watchlist.UserId != userId)
            {
                throw new UnauthorizedAccessException("User does not have access to this watchlist.");
            }

            var movie = await context.Movies.FindAsync(movieId);
            if (movie == null)
            {
                throw new NotFoundException("Movie not found.");
            }

            if (watchlist.MovieWatchlists.Any(mw => mw.MovieId == movieId))
            {
                throw new InvalidOperationException("Movie already exists in the watchlist.");
            }

            watchlist.MovieWatchlists.Add(new MovieWatchlist { MovieId = movieId, WatchlistId = watchlistId });
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movie>> GetAllByUserIdAsync(int userId)
        {
            var moviesForUser = await context.Users
                  .Where(u => u.Id == userId) 
                  .Include(u => u.Watchlists) 
                  .ThenInclude(w => w.MovieWatchlists) 
                  .ThenInclude(mw => mw.Movie) 
                  .SelectMany(u => u.Watchlists)  
                  .SelectMany(w => w.MovieWatchlists)  
                  .Select(mw => mw.Movie)
                  .Distinct() 
                  .ToListAsync(); 

            return moviesForUser;
        }

        public async Task<IEnumerable<Watchlist>> GetWatchListsAsync(int userId)
        {
            return await context.Watchlists
                 .Where(w => w.UserId == userId)
                 .Select(w => new Watchlist { Id = w.Id, Name = w.Name }) 
                 .ToListAsync();
        }
    }
}
