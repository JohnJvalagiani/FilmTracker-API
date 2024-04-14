using AutoMapper;
using FilmTrackerAPI.Application.Dtos;
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
    public class GetWatchListsHandler(IWatchlistRepository watchlistRepository,IMapper mapper) : IRequestHandler<GetWatchLists, IEnumerable<WatchListDto>>
    {
        public async Task<IEnumerable<WatchListDto>> Handle(GetWatchLists request, CancellationToken cancellationToken)
        {
            var watchlists = await watchlistRepository.GetWatchListsAsync(request.UserId);

            return mapper.Map<IEnumerable<WatchListDto>>(watchlists);
        }
    }
}
