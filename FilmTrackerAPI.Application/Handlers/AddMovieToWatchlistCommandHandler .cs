using FilmTrackerAPI.Application.Commands;
using FilmTrackerAPI.Domain.Entities;
using FilmTrackerAPI.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Application.Handlers
{
    public class AddMovieToWatchlistCommandHandler(IMovieRepository movieRepository, IWatchlistRepository watchlistRepository)
    : IRequestHandler<AddMovieToWatchlistCommand, Unit>
    {
        public async Task<Unit> Handle(AddMovieToWatchlistCommand request, CancellationToken cancellationToken)
        {
            var watchlist = await watchlistRepository.GetByIdAsync(request.WatchlistId);
            if (watchlist == null)
            {
                throw new KeyNotFoundException($"Watchlist with ID {request.WatchlistId} not found.");
            }

            if (watchlist.UserId != request.UserId)
            {
                throw new InvalidOperationException("User ID does not match the owner of the watchlist.");
            }

            var movie = await movieRepository.GetByIdAsync(request.MovieId);
            if (movie == null)
            {
                throw new KeyNotFoundException($"Movie with ID {request.MovieId} not found.");
            }

            watchlist.Movies.Add(movie);
            await watchlistRepository.UpdateAsync(watchlist);

            return Unit.Value;
        }
    }
}
