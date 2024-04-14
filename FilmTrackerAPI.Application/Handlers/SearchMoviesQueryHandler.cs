using AutoMapper;
using Common.Exceptions;
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
    internal class SearchMoviesQueryHandler(IMovieRepository _movieRepository, IMapper mapper)
        :IRequestHandler<SearchMovieByNameQuery, IEnumerable<MovieDto>>
    {
        public async Task<IEnumerable<MovieDto>> Handle(SearchMovieByNameQuery request, CancellationToken cancellationToken)
        {
            var movies = await _movieRepository.SearchByNameAsync(request.MovieName);
           
            return mapper.Map<List<MovieDto>>(movies); ;
        }
    }
}
