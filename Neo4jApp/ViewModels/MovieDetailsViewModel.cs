using Neo4jApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.ViewModels
{
    public class MovieDetailsViewModel
    {
        public MovieDetailsModel Movie { get; set; }
        public List<ReviewModel> Reviews { get; set; }
    }
}
