using Neo4jApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.ViewModels
{
    public class ProfileViewModel
    {
        public PersonModel Person { get; set; }
        public List<ExtendedReviewModel> Reviews { get; set; }
    }
}
