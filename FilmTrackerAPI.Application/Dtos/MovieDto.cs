using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilmTrackerAPI.Application.Dtos
{
    public record MovieDto
    {
        public int Id { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        public DateTime ReleaseDate { get; init; }
        public string Genre { get; init; }
        public bool IsWatched { get; init; }
    }
}
