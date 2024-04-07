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
    : IRequestHandler<AddMovieToWatchlistCommand, bool>
    {
        public async Task<bool> Handle(AddMovieToWatchlistCommand request, CancellationToken cancellationToken)
        {
            var watchlist = await watchlistRepository.GetByIdAsync(request.WatchlistId);
            if (watchlist == null || watchlist.UserId != request.UserId)
            {
                return false;
            }

            var movie = await movieRepository.GetByIdAsync(request.MovieId);
            if (movie == null)
            {
                return false;
            }

            watchlist.Movies.Add(movie);
            await watchlistRepository.UpdateAsync(watchlist);
            return true;
        }
    }
}
