using FilmTrackerAPI.Application.Queries;
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
    public class GetAllWatchlistsQuery(IWatchlistRepository watchlistRepository) 
        : IRequestHandler<GetWatchlistQuery, Watchlist>
    {
        public async Task<IEnumerable<Watchlist>> Handle(GetAllWatchlistsQuery request, CancellationToken cancellationToken)
        {
            return await watchlistRepository.GetAllByUserIdAsync(request.UserId);
        }

    }
}
