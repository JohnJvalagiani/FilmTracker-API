using FilmTracker_API.Controllers.Base;
using FilmTrackerAPI.Application.Commands;
using FilmTrackerAPI.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FilmTracker_API.Controllers
{
    /// <summary>
    /// Controller responsible for managing operations related to watchlists.
    /// </summary>
    public class WatchlistController(IMediator mediator) : BaseController
    {
        /// <summary>
        /// Adds a movie to a watchlist based on the provided command.
        /// </summary>
        /// <param name="command">The command containing details needed to add a movie to a watchlist.</param>
        /// <returns>An IActionResult that indicates success or failure, along with the operation result.</returns>
        [HttpPost("add")]
        public async Task<IActionResult> AddMovieToWatchlist([FromBody] AddMovieToWatchlistCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves all movies in a user's watchlist.
        /// </summary>
        /// <param name="userId">The user ID for which to retrieve watchlists and their movies.</param>
        /// <returns>A list of all watchlist movies associated with the specified user.</returns>
        [HttpGet("Get-allMovies/{userId}")]
        public async Task<IActionResult> GetAllWatchlistMovies(int userId)
        {
            var query = new GetAllMovieFromWatchlistsQuery(userId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Retrieves all watchlists associated with a specified user.
        /// </summary>
        /// <param name="userId">The ID of the user whose watchlists are to be retrieved.</param>
        /// <returns>A list of watchlists for the specified user.</returns>
        [HttpGet("get-watchlists/{userId}")]
        public async Task<IActionResult> GetAllWatchlist(int userId)
        {
            var query = new GetWatchLists(userId);
            var result = await mediator.Send(query);
            return Ok(result);
        }

        /// <summary>
        /// Marks a specified movie as watched based on the provided command.
        /// </summary>
        /// <param name="addMovieToWatchlistCommand">The command containing details of the movie to mark as watched.</param>
        /// <returns>An IActionResult that indicates success or failure, along with the operation result.</returns>
        [HttpPost("mark-watched")]
        public async Task<IActionResult> MarkMovieAsWatched([FromBody] MarkMovieAsWatchedCommand markMovieAsWatchedCommand)
        {
            var result = await mediator.Send(markMovieAsWatchedCommand);
            return Ok(result);
        }
    }
}