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
    public class MovieRepository(DataContext _context) : IMovieRepository
    {

        public async Task<Movie> GetByIdAsync(int id)
        {
            return await _context.Movies.FindAsync(id);
        }

        public async Task<IEnumerable<Movie>> GetAllAsync()
        {
            return await _context.Movies.ToListAsync();
        }

        public async Task<IEnumerable<Movie>> GetMoviesByWatchlistIdAsync(int watchlistId)
        {
            return await _context.Movies
                .Where(m => int.Parse(m.WatchlistId) == watchlistId)
                .ToListAsync();
        }

        public async Task AddAsync(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var movie = await GetByIdAsync(id);
            if (movie != null)
            {
                _context.Movies.Remove(movie);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Movie>> SearchByNameAsync(string movieName)
        {
            return await _context.Movies
         .Where(m => EF.Functions.Like(m.Title, $"%{movieName}%"))
         .ToListAsync();
        }
    }
}
