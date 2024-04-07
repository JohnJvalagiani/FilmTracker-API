using FilmTrackerAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Domain.Interfaces
{
    public interface IMovieRepository
    {
       public Task<Movie> GetByIdAsync(int id);
       public Task<IEnumerable<Movie>> GetAllAsync();
       public Task<IEnumerable<Movie>> GetMoviesByWatchlistIdAsync(int watchlistId);
       public Task AddAsync(Movie movie);
       public Task UpdateAsync(Movie movie);
       public Task DeleteAsync(int id);
       public Task<IEnumerable<Movie>> SearchByNameAsync(string movieName);
    }
}
