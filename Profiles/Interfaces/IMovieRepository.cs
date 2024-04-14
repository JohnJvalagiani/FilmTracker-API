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
       public Task<IEnumerable<Movie>> SearchByNameAsync(string movieName);
    }
}
