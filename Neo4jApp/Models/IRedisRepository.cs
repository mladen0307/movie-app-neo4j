using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.Models
{
    public interface IRedisRepository
    {
        void SaveVisit(string username, string imdbId);

        //Vraca najvise 5 najskorije posecenih filmova za datog usera, ne vraca duplikate        
        List<string> GetRecentlyVisited(string username);
    }
}
