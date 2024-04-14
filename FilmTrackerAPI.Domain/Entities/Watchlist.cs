using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Domain.Entities
{
    public class Watchlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public List<MovieWatchlist> MovieWatchlists { get; set; } = new List<MovieWatchlist>();
    }
}
