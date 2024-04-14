using FilmTracker_API.Controllers.Base;
using FilmTrackerAPI.Application.Commands;
using FilmTrackerAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmTracker_API.Controllers.V1
{
    public class WatchlistController(IMediator mediator) : BaseController
    {
        [HttpPost("add")]
        public async Task<IActionResult> AddMovieToWatchlist([FromBody] AddMovieToWatchlistCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllWatchlistMovies(string userId)
        {
            var query = new GetAllWatchlistsQuery(userId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        [HttpPost("mark-watched")]
        public async Task<IActionResult> MarkMovieAsWatched([FromBody] AddMovieToWatchlistCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}