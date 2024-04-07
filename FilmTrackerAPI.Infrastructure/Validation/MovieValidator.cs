using FilmTrackerAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Infrastructure.Validation
{
    public class MovieValidator : AbstractValidator<Movie>
    {
        public MovieValidator()
        {
            RuleFor(m => m.Title)
                .NotEmpty().WithMessage("Title is required.")
                .Length(1, 100).WithMessage("Title must be between 1 and 100 characters.");

            RuleFor(m => m.Description)
                .NotEmpty().WithMessage("Description is required.")
                .Length(1, 500).WithMessage("Description must be between 1 and 500 characters.");

            RuleFor(m => m.ReleaseDate)
                .NotEmpty().WithMessage("Release date is required.");

            RuleFor(m => m.Genre)
                .NotEmpty().WithMessage("Genre is required.")
                .Length(1, 50).WithMessage("Genre must be between 1 and 50 characters.");
        }
    }
}
