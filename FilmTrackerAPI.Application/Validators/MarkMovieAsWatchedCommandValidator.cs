using FilmTrackerAPI.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Application.Validators
{
    public class MarkMovieAsWatchedCommandValidator : AbstractValidator<MarkMovieAsWatchedCommand>
    {
        public MarkMovieAsWatchedCommandValidator()
        {
            RuleFor(command => command.MovieId)
                .GreaterThan(0)
                .WithMessage("Movie ID must be greater than 0.");

            RuleFor(command => command.UserId)
                .GreaterThan(0)
                .WithMessage("User ID must be greater than 0.");
        }
    }
}
