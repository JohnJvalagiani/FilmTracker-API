using FilmTrackerAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Domain.Interfaces
{
    public interface IWatchlistRepository
    {
       public Task<Watchlist> GetByIdAsync(int id);
       public Task<IEnumerable<Watchlist>> GetAllAsync();
       public Task AddAsync(Watchlist watchlist);
       public Task UpdateAsync(Watchlist watchlist);
       public Task DeleteAsync(int id);
        Task<IEnumerable<Watchlist>> GetAllByUserIdAsync(object userId);
    }
}
