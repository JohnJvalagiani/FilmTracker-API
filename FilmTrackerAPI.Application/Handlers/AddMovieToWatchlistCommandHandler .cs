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
    public class AddMovieToWatchlistCommandHandler(IWatchlistRepository watchlistRepository)
    : IRequestHandler<AddMovieToWatchlistCommand, Unit>
    {
        public async Task<Unit> Handle(AddMovieToWatchlistCommand request, CancellationToken cancellationToken)
        {
            await watchlistRepository.AddMovieToWatchlistAsync(request.UserId, request.WatchlistId, request.MovieId);
            return Unit.Value;
        }
    }
}
