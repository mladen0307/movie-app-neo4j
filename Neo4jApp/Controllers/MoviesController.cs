using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neo4jApp.Models;
using Neo4jApp.ViewModels;

namespace Neo4jApp.Controllers
{
    [Authorize]
    public class MoviesController : Controller
    {
        private readonly IGraphRepository _graphRepository;
        private readonly IOmdbClient _omdbClient;
        private readonly IRedisRepository _redisRepository;

        public MoviesController(IGraphRepository graphRepository, IOmdbClient omdbClient, IRedisRepository redisRepository)
        {
            _graphRepository = graphRepository;
            _omdbClient = omdbClient;
            _redisRepository = redisRepository;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal currentUser = this.User;
            string username = currentUser.Identity.Name;


            List<string> recentMovies = _redisRepository.GetRecentlyVisited(username);
           

            MoviesIndexModel model = new MoviesIndexModel()
            {
                TopMovies = _graphRepository.TopRatedMovies(6),
                RecMovies = _graphRepository.RecommendedMovies(username).Take(6).ToList(),
                MoviesHistory = _graphRepository.RecentlyViewedMovies(recentMovies)
            };

            return View(model);
        }

        public async Task<IActionResult> Search(string title)
        {
            MoviesSearchViewModel model = new MoviesSearchViewModel()
            {
                Movies = _graphRepository.FindMoviesByTitle(title)
            };
            if (model.Movies.Count < 5)
            {
                model.Movies = await _omdbClient.LoadMoviesAsync(title);
                _graphRepository.AddMovies(model.Movies);
            }
            return View(model);
        }

        public async Task<IActionResult> Details(string id)
        {
            MovieDetailsViewModel model = new MovieDetailsViewModel()
            {
                Movie = _graphRepository.GetMovieById(id),
                Reviews = _graphRepository.GetReviewsForMovie(id)
            };
            if (model.Movie.Genre == null)
            {
                model.Movie = await _omdbClient.LoadMovieByImdbIDAsync(id);
                _graphRepository.AddMovieDetails(model.Movie);
            }

            ClaimsPrincipal currentUser = this.User;
            string username = currentUser.Identity.Name;

            _redisRepository.SaveVisit(username, id);

            return View(model);
        }

        public IActionResult Review(string username, string imbdId, int rating, string text)
        {
            ReviewModel review = new ReviewModel()
            {
                Username = username,
                MovieId = imbdId,
                Rating = rating,
                ReviewText = text,
                Date = DateTime.Now.ToString("dd/MM/yyyy H:mm")
            };

            _graphRepository.AddReview(review);

            
            return RedirectToAction("Details","Movies", new { id = imbdId });
        }


    }
}