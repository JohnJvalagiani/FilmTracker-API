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
    public class WatchlistRepository : IWatchlistRepository
    {
        private readonly DataContext _context;

        public WatchlistRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Watchlist> GetByIdAsync(int id)
        {
            return await _context.Watchlists
                .Include(w => w.Movies)
                .FirstOrDefaultAsync(w => w.Id == id);
        }

        public async Task<IEnumerable<Watchlist>> GetAllAsync()
        {
            return await _context.Watchlists
                .Include(w => w.Movies)
                .ToListAsync();
        }

        public async Task AddAsync(Watchlist watchlist)
        {
            _context.Watchlists.Add(watchlist);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Watchlist watchlist)
        {
            _context.Watchlists.Update(watchlist);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var watchlist = await GetByIdAsync(id);
            if (watchlist != null)
            {
                _context.Watchlists.Remove(watchlist);
                await _context.SaveChangesAsync();
            }
        }
    }
}
