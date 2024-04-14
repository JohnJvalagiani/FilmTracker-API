using FilmTrackerAPI.Application.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Application.Validators
{
    public class AddMovieToWatchlistCommandValidator : AbstractValidator<AddMovieToWatchlistCommand>
    {
        public AddMovieToWatchlistCommandValidator()
        {
            RuleFor(command => command.MovieId).GreaterThan(0);
            RuleFor(command => command.WatchlistId).GreaterThan(0);
        }
    }
}
