using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string? Genre { get; set; }
        public bool IsWatched { get; set; }
        public string? WatchlistId { get; set; }
        public Watchlist? Watchlist { get; set; }
    }
}
