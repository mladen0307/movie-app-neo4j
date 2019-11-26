using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Neo4jApp.Models;

namespace Neo4jApp.Controllers
{
    public class PeopleController : Controller
    {

        private readonly IGraphRepository _graphRepository;

        public PeopleController(IGraphRepository graphRepository)
        {
            _graphRepository = graphRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            ClaimsPrincipal currentUser = this.User;
            string username = currentUser.Identity.Name;            
            List<PersonWithSim> people = _graphRepository.FindKnn(username, 4);
            foreach (PersonWithSim person in people)
            {
                person.Similarity = Math.Round(person.Similarity, 2);
            }
            return View(people);
        }
    }
}