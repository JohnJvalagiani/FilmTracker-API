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
    public class MarkMovieAsWatchedCommandHandler(IWatchlistRepository watchlistRepository) : IRequestHandler<MarkMovieAsWatchedCommand, Unit>
    {
        public async Task<Unit> Handle(MarkMovieAsWatchedCommand request, CancellationToken cancellationToken)
        {
            await watchlistRepository.MarkMovieAsWatchedAsync(request.UserId, request.UserId, request.MovieId);
            return Unit.Value;
        }
    }  
}
