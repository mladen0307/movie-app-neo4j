using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.Models
{
    public class PersonWithSim
    {
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Bio { get; set; }
        public double Similarity { get; set; }
    }
}
