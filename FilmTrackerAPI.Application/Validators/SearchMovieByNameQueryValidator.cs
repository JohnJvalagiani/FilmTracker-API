using FilmTrackerAPI.Application.Queries;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Application.Validators
{
    public class SearchMovieByNameQueryValidator : AbstractValidator<SearchMovieByNameQuery>
    {
        public SearchMovieByNameQueryValidator()
        {
            RuleFor(query => query.MovieName)
                .NotEmpty()
                .WithMessage("Movie name must not be empty.");
        }
    }
}
