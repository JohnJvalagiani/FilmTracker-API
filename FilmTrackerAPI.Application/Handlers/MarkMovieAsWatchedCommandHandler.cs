using FilmTrackerAPI.Application.Commands;
using FilmTrackerAPI.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Application.Handlers
{
    public class MarkMovieAsWatchedCommandHandler(IMovieRepository _movieRepository, IWatchlistRepository _watchlistRepository) : IRequestHandler<MarkMovieAsWatchedCommand, Unit>
    {
        public async Task<Unit> Handle(MarkMovieAsWatchedCommand request, CancellationToken cancellationToken)
        {
            // Get the movie from the database
            var movie = await _movieRepository.GetByIdAsync(request.MovieId);
            if (movie == null)
            {
                throw new KeyNotFoundException($"No movie found with ID {request.MovieId}.");
            }

            // Ensure the movie is in the user's watchlist
            var watchlist = await _watchlistRepository.GetByIdAsync(movie.WatchlistId);
            if (watchlist == null || watchlist.UserId != request.UserId)
            {
                throw new InvalidOperationException("Movie is not in the user's watchlist.");
            }

            // Mark the movie as watched
            movie.IsWatched = true;
            await _movieRepository.UpdateAsync(movie);

            return Unit.Value;
        }
    }  
}
