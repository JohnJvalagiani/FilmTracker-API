using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Domain.Entities
{
    public class Watchlist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; } 
        public ICollection<Movie> Movies { get; set; }

        public Watchlist() => Movies = new List<Movie>();
    }
}
