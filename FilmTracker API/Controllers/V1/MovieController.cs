using FilmTracker_API.Controllers.Base;
using FilmTrackerAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmTracker_API.Controllers.V1
{
    public class MovieController(IMediator mediator) : BaseController
    {
        [HttpGet("search")]
        public async Task<IActionResult> SearchByName([FromQuery] string movieName)
        {
            var query = new SearchMovieByNameQuery(movieName);
            var result = await mediator.Send(query);
            return Ok(result);
        }
    }
}
