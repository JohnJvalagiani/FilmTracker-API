using FilmTrackerAPI.Application.Commands;
using FilmTrackerAPI.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Application.Handlers
{
    internal class WatchlistHandler(IMovieRepository movieRepository) :
        IRequestHandler<Commands.AddMovieToWatchlistCommand, bool>
    {
        public async Task<bool> Handle(Commands.AddMovieToWatchlistCommand request, CancellationToken cancellationToken)
        {
            var movie = await movieRepository.GetByIdAsync(request.MovieId);
            if (movie == null)
            {
                return false;
            }

            movie.IsWatched = true;
            await movieRepository.UpdateAsync(movie);
            return true;
        }
    }


    }