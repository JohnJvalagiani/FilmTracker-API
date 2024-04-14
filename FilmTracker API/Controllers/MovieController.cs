using FilmTracker_API.Controllers.Base;
using FilmTrackerAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmTracker_API.Controllers
{
    /// <summary>
    /// Controller for handling movie-related operations.
    /// </summary>
    public class MovieController(IMediator mediator) : BaseController
    {
        /// <summary>
        /// Searches for movies by name.
        /// </summary>
        /// <param name="movieName">The name of the movie to search for.</param>
        /// <returns>A list of movies matching the search query.</returns>
        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string movieName)
        {
            var query = new SearchMovieByNameQuery(movieName);
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
