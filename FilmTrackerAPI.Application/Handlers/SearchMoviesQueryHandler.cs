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
    internal class SearchMoviesQueryHandler(IMovieRepository _movieRepository)
        :IRequestHandler<SearchMovieByNameQuery, IEnumerable<Movie>>
    {
        public async Task<IEnumerable<Movie>> Handle(SearchMovieByNameQuery request, CancellationToken cancellationToken)
        {
            return await _movieRepository.SearchByNameAsync(request.MovieName);
        }
    }
}
