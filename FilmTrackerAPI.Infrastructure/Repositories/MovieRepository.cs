using FilmTrackerAPI.Domain.Entities;
using FilmTrackerAPI.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Infrastructure.Repositories
{
    public class MovieRepository(ApplicationDbContext context) : IMovieRepository
    {
        public async Task<IEnumerable<Movie>> SearchByNameAsync(string movieName)
        {
            return await context.Movies
                .Where(m => EF.Functions.Like(m.Title, $"%{movieName}%"))
                .ToListAsync();
        }
    }
}
