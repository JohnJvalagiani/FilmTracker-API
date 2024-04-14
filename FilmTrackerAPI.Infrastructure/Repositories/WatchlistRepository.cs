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
    public class WatchlistRepository(ApplicationDbContext context) : IWatchlistRepository
    {
        public async Task<Watchlist> GetByIdAsync(int id)
        {
            var watchlist = await context.Watchlists
                                         .Include(w => w.Movies)
                                         .FirstOrDefaultAsync(w => w.Id == id);

            return watchlist ?? throw new KeyNotFoundException($"Watchlist with ID {id} was not found.");
        }

        public async Task<IEnumerable<Watchlist>> GetAllAsync()
        {
            return await context.Watchlists
                .Include(w => w.Movies)
                .ToListAsync();
        }

        public async Task AddAsync(Watchlist watchlist)
        {
            context.Watchlists.Add(watchlist);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Watchlist watchlist)
        {
            context.Watchlists.Update(watchlist);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var watchlist = await GetByIdAsync(id);
            if (watchlist != null)
            {
                context.Watchlists.Remove(watchlist);
                await context.SaveChangesAsync();
            }
        }
        public async Task<IEnumerable<Watchlist>> GetAllByUserIdAsync(string userId)
        {
            return await context.Watchlists
                .Where(w => w.UserId == userId)
                .Include(w => w.Movies)
                .ToListAsync();
        }

    }
}
