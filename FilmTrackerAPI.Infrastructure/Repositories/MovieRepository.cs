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

        public async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await context.Movies.FindAsync(id);

            return movie ?? throw new KeyNotFoundException($"Movie with ID {id} was not found.");
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await context.Movies.ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByWatchlistIdAsync(int watchlistId)
        {
            return await context.Movies
                .Where(m => m.WatchlistId == watchlistId)
                .ToListAsync();
        }

        public async Task AddAsync(Movie movie)
        {
            context.Movies.Add(movie);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            context.Movies.Update(movie);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await GetByIdAsync(id);
            if (movie != null)
            {
                context.Movies.Remove(movie);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Movie>> SearchByNameAsync(string movieName)
        {
            return await context.Movies
                .Where(m => EF.Functions.Like(m.Title, $"%{movieName}%"))
                .ToListAsync();
        }
    }
}
