using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.Models
{
    public class ExtendedReviewModel
    {
        public string Username { get; set; }
        public string MovieId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public string Date { get; set; }

        public string Title { get; set; }
        public string Year { get; set; }        
        public string Type { get; set; }
        public string Poster { get; set; }
    }
}
