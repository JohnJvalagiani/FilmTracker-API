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
    public class GetAllMoviesFromWatchlistsQueryHandler(IWatchlistRepository watchlistRepository, IMapper mapper) 
        : IRequestHandler<GetAllMovieFromWatchlistsQuery, IEnumerable<MovieDto>>
    {
        public async Task<IEnumerable<MovieDto>> Handle(GetAllMovieFromWatchlistsQuery request, CancellationToken cancellationToken)
        {
            var movies = await watchlistRepository.GetAllByUserIdAsync(request.UserId);

            return mapper.Map<List<MovieDto>>(movies); 
        }

    }
}
