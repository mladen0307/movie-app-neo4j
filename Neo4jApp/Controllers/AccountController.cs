using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Neo4jApp.Models;
using Neo4jApp.ViewModels;

namespace Neo4jApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IGraphRepository _graphRepository;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IGraphRepository graphRepository)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _graphRepository = graphRepository;
        }

        public IActionResult DeleteAllUsers()
        {
            foreach (var user in _userManager.Users.ToList())
            {
                _userManager.DeleteAsync(user);
            }
            _graphRepository.DeleteAllPeople();
            return RedirectToAction("Index", "Home");
        }


        [Authorize]
        [HttpGet]
        public IActionResult Profile(string id)
        {
            if (id == null) {
                ClaimsPrincipal currentUser = this.User;
                id = currentUser.Identity.Name;
            }

            ProfileViewModel model = new ProfileViewModel()
            {
                Person = _graphRepository.GetPerson(id),
                Reviews = _graphRepository.GetReviewsFromUser(id)
            } ;
            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit()
        {
            ClaimsPrincipal currentUser = this.User;
            string username = currentUser.Identity.Name;
            PersonModel user = _graphRepository.GetPerson(username);
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(PersonModel person)
        {
            ClaimsPrincipal currentUser = this.User;
            string username = currentUser.Identity.Name;
            if (person.Username != username)
            {
                ModelState.AddModelError("", "Error processing request");
                    return View(person);
            }
            _graphRepository.EditPerson(person);
            return RedirectToAction("Profile","Account");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await
                _userManager.FindByNameAsync(model.UserName);

            if(user !=null)
            {
                var result = await
                    _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                if (result.Succeeded)
                    return RedirectToAction("Index", "Home");
            }


            ModelState.AddModelError("", "Username/password is incorrect ");
            return View(model);
        }

        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = model.UserName,
                    Email = model.Email                   
                };                
                var result =
                    await _userManager
                        .CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    _graphRepository.AddPerson(new PersonModel
                                    { Username = model.UserName, FullName = model.FullName, Bio = "" });
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("", $"Username {model.UserName} is already taken");
                }
               
            }
            return View(model);
            
        }


        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    }
}