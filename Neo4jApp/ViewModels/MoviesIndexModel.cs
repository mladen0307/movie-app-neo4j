using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neo4jApp.Models;

namespace Neo4jApp.ViewModels
{
    public class MoviesIndexModel
    {
        public List<MovieDetailsModel> TopMovies { get; set; }
        public List<MovieDetailsModel> RecMovies { get; set; }
    }
}
