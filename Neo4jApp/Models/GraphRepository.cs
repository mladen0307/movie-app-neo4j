using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Neo4jClient;
using Neo4jClient.Cypher;

namespace Neo4jApp.Models
{
    public class GraphRepository : IGraphRepository
    {
        private GraphClient client;

        public GraphRepository()
        {
            client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "admin1");
            client.Connect();
        }

        public void AddMovies(List<MovieModel> moviesToAdd)
        {
            if (moviesToAdd == null)
                return;
            foreach (MovieModel movie in moviesToAdd)
            {
                client.Cypher
                    .Merge("(m:Movie { imdbID: {imdbID} })")
                    .OnCreate()
                    .Set("m = {movie}")
                    .WithParams(new
                    {
                        imdbID = movie.imdbID,
                        movie
                    })
                    .ExecuteWithoutResults();
            }
        }

        public List<MovieModel> FindMoviesByTitle(string title)
        {
            string movieName = "(?i).*" + title + ".*";

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("movieName", movieName);

            var query = new Neo4jClient.Cypher.CypherQuery("match (n:Movie) where exists(n.Title) and n.Title =~ {movieName} return n",
                                                            queryDict, CypherResultMode.Set);

            List<MovieModel> movies = ((IRawGraphClient)client).ExecuteGetCypherResults<MovieModel>(query).ToList();


            return movies;
        }

        public MovieDetailsModel GetMovieById(string id)
        {
            MovieDetailsModel movieWithDetails = client.Cypher
                .Match("(movie:Movie)")
                .Where((MovieModel movie) => movie.imdbID == id)
                .Return(movie => movie.As<MovieDetailsModel>()).Results.FirstOrDefault<MovieDetailsModel>();
            return movieWithDetails;
        }

        public void AddMovieDetails(MovieDetailsModel movieWithDetails)
        {
            client.Cypher
                    .Match("(movie:Movie)")
                    .Where((MovieModel movie) => movie.imdbID == movieWithDetails.imdbID)
                    .Set("movie = {details}")
                    .WithParam("details", movieWithDetails)
                    .ExecuteWithoutResults();
        }

        public void AddPerson(PersonModel person)
        {
            client.Cypher
                    .Merge("(p:Person { Username: {Username} })")
                    .OnCreate()
                    .Set("p = {person}")
                    .WithParams(new
                    {
                        Username = person.Username,
                        person
                    })
                    .ExecuteWithoutResults();
        }

        public PersonModel GetPerson(string username)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("username", username);

            var query = new Neo4jClient.Cypher.CypherQuery("match (p:Person) where p.Username = {username} return p",
                                                            queryDict, CypherResultMode.Set);

            PersonModel person = ((IRawGraphClient)client).ExecuteGetCypherResults<PersonModel>(query).FirstOrDefault(); ;

            return person;
        }

        public void EditPerson(PersonModel person)
        {
            client.Cypher
                    .Match("(p:Person)")
                    .Where((PersonModel p) => p.Username == person.Username)
                    .Set("p = {person}")
                    .WithParam("person", person)
                    .ExecuteWithoutResults();
        }

        public void DeleteAllPeople()
        {
            client.Cypher
                .OptionalMatch("(p:Person)")               
                .Delete("p")
                .ExecuteWithoutResults();
        }

        public void AddReview(ReviewModel review)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("movieId", review.MovieId);
            queryDict.Add("username", review.Username);
            queryDict.Add("rating", review.Rating);
            queryDict.Add("text", review.ReviewText);
            queryDict.Add("date", review.Date);


            var query1 = new Neo4jClient.Cypher
                .CypherQuery("MATCH (p:Person)-[r:Reviewed]->(m:Movie) WHERE p.Username = {username} and m.imdbID = {movieId} delete r",
                                                            queryDict, CypherResultMode.Set);

            var query2 = new Neo4jClient.Cypher
                .CypherQuery("MATCH (p:Person), (m:Movie) WHERE p.Username = {username} and m.imdbID = {movieId} CREATE (p)-[:Reviewed {Date:{date}, ReviewText:{text}, Rating:{rating}}]->(m)",
                                                            queryDict, CypherResultMode.Set);

            ((IRawGraphClient)client).ExecuteCypher(query1);
            ((IRawGraphClient)client).ExecuteCypher(query2);
            UpdateSim(review.Username);
        }

        public List<ReviewModel> GetReviewsForMovie(string movieId)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
                queryDict.Add("movieId", movieId);

            var query = new Neo4jClient.Cypher
                .CypherQuery("MATCH (p:Person)-[r:Reviewed]->(m:Movie) WHERE m.imdbID = {movieId} return r.Date as Date, r.Rating as Rating, r.ReviewText as ReviewText, p.Username as Username, m.imdbID as MovieId",
                                                            queryDict, CypherResultMode.Projection);



            List<ReviewModel> reviews = ((IRawGraphClient)client).ExecuteGetCypherResults<ReviewModel>(query).ToList();
            return reviews;
        }

        public List<ExtendedReviewModel> GetReviewsFromUser(string username)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
                queryDict.Add("username", username);

            var query = new Neo4jClient.Cypher
                .CypherQuery("MATCH (p:Person)-[r:Reviewed]->(m:Movie) WHERE p.Username = {username} return r.Date as Date, r.Rating as Rating, r.ReviewText as ReviewText, p.Username as Username, m.imdbID as MovieId, m.Poster as Poster, m.Title as Title, m.Year as Year, m.Type as Type",
                                                            queryDict, CypherResultMode.Projection);

            List<ExtendedReviewModel> reviews = ((IRawGraphClient)client).ExecuteGetCypherResults<ExtendedReviewModel>(query).ToList();
            return reviews;

        }

        private void UpdateSim(string username)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("username", username);

            var query = new Neo4jClient.Cypher
                .CypherQuery("MATCH (p1:Person)-[x:Reviewed]->(m:Movie)<-[y:Reviewed]-(p2:Person) WHERE p1.Username={username} WITH SUM(x.Rating * y.Rating) AS xyDotProduct, SQRT(REDUCE(xDot = 0.0, a IN COLLECT(x.Rating) | xDot + a^2)) AS xLength, SQRT(REDUCE(yDot = 0.0, b IN COLLECT(y.Rating) | yDot + b^2)) AS yLength, p1, p2 MERGE (p1)-[s:SIMILARITY]-(p2) SET s.similarity = xyDotProduct / (xLength * yLength)",
                queryDict, CypherResultMode.Set);

            ((IRawGraphClient)client).ExecuteCypher(query);

        }


        public List<PersonWithSim> FindKnn(string username, int k)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("username", username);
            queryDict.Add("k", k);

            var query = new Neo4jClient.Cypher
                .CypherQuery("MATCH (p1:Person)-[s:SIMILARITY]-(p2:Person) WHERE p1.Username = {username} WITH p2, s.similarity as sim ORDER BY sim DESC LIMIT {k} return p2.Username as Username, p2.FullName as FullName, p2.Bio as Bio, sim as Similarity",
                                                            queryDict, CypherResultMode.Projection);


            List<PersonWithSim> people = ((IRawGraphClient)client).ExecuteGetCypherResults<PersonWithSim>(query).ToList();
            return people;
        }

        public List<MovieDetailsModel> TopRatedMovies(int n)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();            
            queryDict.Add("n", n);

            var query = new Neo4jClient.Cypher
                .CypherQuery("MATCH (p:Person)-[r:Reviewed]-(m:Movie) WITH m, AVG(r.Rating) AS ar ORDER BY ar DESC LIMIT {n} return m",
                                                            queryDict, CypherResultMode.Set);
            List<MovieDetailsModel> movies = ((IRawGraphClient)client).ExecuteGetCypherResults<MovieDetailsModel>(query).ToList();
            return movies;
        }


        public List<MovieDetailsModel> RecommendedMovies(string username)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("username", username);

            var query = new Neo4jClient.Cypher
                .CypherQuery("MATCH (b:Person)-[r:Reviewed]->(m:Movie), (b)-[s:SIMILARITY]-(a:Person) WHERE a.Username = {username} and NOT((a)-[:Reviewed]->(m)) WITH m, s.similarity AS similarity, r.Rating AS rating ORDER BY m.Title, similarity DESC WITH m, COLLECT(rating)[0..3] AS ratings WITH m, REDUCE(s = 0, i IN ratings | s + i)*1.0 / SIZE(ratings) AS reco ORDER BY reco DESC RETURN m AS Movie",
                                                            queryDict, CypherResultMode.Set);
            List<MovieDetailsModel> movies = ((IRawGraphClient)client).ExecuteGetCypherResults<MovieDetailsModel>(query).ToList();
            return movies;

        }

        public List<MovieDetailsModel> RecentlyViewedMovies(List<string> ids)
        {
            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("ids", ids);

            var query = new Neo4jClient.Cypher
                .CypherQuery("MATCH (m:Movie) WHERE m.imdbID IN {ids} return m", queryDict, CypherResultMode.Set);
            List<MovieDetailsModel> movies = ((IRawGraphClient)client).ExecuteGetCypherResults<MovieDetailsModel>(query).ToList();
            return movies;
        }
    }
}
