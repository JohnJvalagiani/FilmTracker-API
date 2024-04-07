using FilmTrackerAPI.Domain.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Infrastructure.Validation
{
    public class WatchlistValidator : AbstractValidator<Watchlist>
    {
        public WatchlistValidator()
        {
            RuleFor(w => w.Name)
                .NotEmpty().WithMessage("Name is required.")
                .Length(1, 100).WithMessage("Name must be between 1 and 100 characters.");

            RuleFor(w => w.UserId)
                .NotEmpty().WithMessage("User ID is required.");
        }
    }
}
