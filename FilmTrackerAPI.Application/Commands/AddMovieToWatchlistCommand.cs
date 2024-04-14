using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace FilmTrackerAPI.Application.Commands
{
    public record AddMovieToWatchlistCommand(int MovieId, int WatchlistId, int UserId) : IRequest<Unit>;

}
