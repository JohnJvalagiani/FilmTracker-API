using FilmTrackerAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Domain.Interfaces
{
    public interface IWatchlistRepository
    {
        public Task MarkMovieAsWatchedAsync(int userId, int watchlistId, int movieId);
        public Task AddMovieToWatchlistAsync(int userId, int watchlistId, int movieId);
        public Task<IEnumerable<Movie>> GetAllByUserIdAsync(int userId);
        public Task<IEnumerable<Watchlist>> GetWatchListsAsync(int userId);
    }
}
