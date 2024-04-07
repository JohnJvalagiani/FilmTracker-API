using MediatR;

namespace FilmTrackerAPI.Application.Commands
{
    public record AddMovieCommand(
        string Title,
        string Description,
        DateTime ReleaseDate,
        string Genre,
        string WatchlistId
    ) : IRequest<int>;
}
