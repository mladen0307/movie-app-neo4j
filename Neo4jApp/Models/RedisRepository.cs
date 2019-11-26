using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StackExchange.Redis;

namespace Neo4jApp.Models
{
    public class RedisRepository : IRedisRepository
    {
        private ConnectionMultiplexer redis;

        public RedisRepository()
        {
            redis = ConnectionMultiplexer.Connect("localhost");
        }

        public List<string> GetRecentlyVisited(string username)
        {
            IDatabase db = redis.GetDatabase();
            var res = db.ListRange(username);
            List<string> movieIds = new List<string>();
            foreach (var x in res)
            {
                movieIds.Add(x.ToString());
            }
            return movieIds;

        }

        public void SaveVisit(string username, string imdbId)
        {
            IDatabase db = redis.GetDatabase();
            db.ListRemove(username, imdbId, 0);
            db.ListLeftPush(username, imdbId);
            db.ListTrim(username, 0, 5);

        }
    }
}
