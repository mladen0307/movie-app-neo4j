using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.Models
{
    public interface IOmdbClient
    {
        Task<MovieDetailsModel> LoadMovieByImdbIDAsync(string id);
        Task<List<MovieModel>> LoadMoviesAsync(string searchString);

    }
}
