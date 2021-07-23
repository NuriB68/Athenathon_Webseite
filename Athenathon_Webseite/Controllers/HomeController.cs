using Athenathon_Webseite.Models;
using Athenathon_Webseite.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
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

        public ActionResult Dashboard()
        {

            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("denied")]
        public IActionResult Denied()  // shown, when entrance is denied
        {
            return View();
        }

        [HttpGet("login")]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost("login")]  // validation function tests if User exists and is allowed to log in, please refer UserService
        public async Task<IActionResult> Validate(string email, string password, string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (_userService.TryValidateUser(email, password, out List<Claim> claims))
            {
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity); // new ClaimsPrincipal and Identity added to User
                await HttpContext.SignInAsync(claimsPrincipal);
                return RedirectToAction("Index", "Home");  // if logged in, User is send to Index-Home-View
            }

            else  // shows error, if wrong data is put in or access is denied
            {
                TempData["Error"] = "Error. Username or Password is invalid or your access is denied. " +
                    "If you are a regular User please use the App for personal Data";
                return View("login"); 
            }


        }

        [Authorize]  // if logged in, logout is possible
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

        // display the user manual pdf file on the website for every visitor
        public ActionResult Usermanual()
        {

            return View();
        }
    }
}

