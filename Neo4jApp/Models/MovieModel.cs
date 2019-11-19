using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.Models
{
    public class MovieModel
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string imdbID { get; set; }
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
