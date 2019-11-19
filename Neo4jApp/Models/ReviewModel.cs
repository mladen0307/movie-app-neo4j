using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.Models
{
    public class ReviewModel
    {
        public string Username { get; set; }
        public string MovieId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public string Date { get; set; }

        
    }
}
