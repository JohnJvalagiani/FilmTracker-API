using FilmTrackerAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Application.Queries
{
    public record GetAllWatchlistsQuery(string UserId) : IRequest<IEnumerable<Watchlist>>;
}
