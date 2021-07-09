using Athenathon_Webseite.Models;
using Athenathon_Webseite.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Athenathon_Webseite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserService _userService;



        public HomeController(ILogger<HomeController> logger, UserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet("denied")]
        public IActionResult Denied()  // angezeigt wenn Zugang verboten ist
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]  // hier wird durch Validate Funktion geprüft ob User existiert und sich anmeden darf, siehe UserService
        public async Task<IActionResult> Validate(string email, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (_userService.TryValidateUser(email, password, out List<Claim> claims))
            {
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home");  // wenn man angemeldet ist wird man zur homepage geschickt
            }

            else
            {
                TempData["Error"] = "Error. Username or Password is invalid or your access is denied. " +
                    "If you are a regular User please use the App for personal Data";
                return View("login");
            }


        }

        [Authorize]  // falls man angemeldet ist kann man sich auch abmeldem
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

