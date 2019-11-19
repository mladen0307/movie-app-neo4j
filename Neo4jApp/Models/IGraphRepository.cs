using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Neo4jApp.Models
{
    public interface IGraphRepository
    {
        void AddMovies(List<MovieModel> moviesToAdd);
        List<MovieModel> FindMoviesByTitle(string title);
        MovieDetailsModel GetMovieById(string id);
        void AddMovieDetails(MovieDetailsModel movieWithDetails);
        void AddPerson(PersonModel person);
        PersonModel GetPerson(string username);
        void EditPerson(PersonModel person);
        void DeleteAllPeople();
        void AddReview(ReviewModel review);
        List<ReviewModel> GetReviewsForMovie(string movieId);
        List<ExtendedReviewModel> GetReviewsFromUser(string username);
        List<PersonWithSim> FindKnn(string username, int k);
        List<MovieDetailsModel> TopRatedMovies(int n);
        List<MovieDetailsModel> RecommendedMovies(string username);
    }
}
