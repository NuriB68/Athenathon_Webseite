using Athenathon_Webseite.Data;
using Athenathon_Webseite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Athenathon_Webseite.Services;

namespace Athenathon_Webseite.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }


        /* Startpage regarding Users, shows list of Users and their details, offers options to proceed*/

        [Authorize(Roles = "Admin, Supervisor")]  // Access for Admin and Supervisor
        public IActionResult Index(string searchText)
        {
            if (User.HasClaim(ClaimTypes.Role, "Admin")) // Admin can see and update everyone
            {

                return View(_db.Users.Where(a => a.Id.ToString().Contains(searchText)  || a.Name.Contains(searchText)  ||
                a.Roles.Contains(searchText)  || a.University.Contains(searchText)   || searchText == null ).ToList());
            } else {  // Supervisor can only see user
                return View(_db.Users.Where(a => a.Id.ToString().Contains(searchText) &&  a.Roles == "User" || a.Name.Contains(searchText) && a.Roles == "User" ||
                a.Roles.Contains(searchText) && a.Roles == "User" || a.University.Contains(searchText) && a.Roles == "User" || searchText == null && a.Roles == "User").ToList());
            }
        }



        // GET Create
        /* Redirects to the user creation view */

        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
                return View();
        }

        // POST Create
        /* Adds new User to database and returns to Index-View */

        [Authorize(Roles = "Admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // GET Delete
        /*  Redirection to the view where the user is displayed with the corresponding Id 
         *  and the option of deletion is available */

        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Delete
        /* Deletion of User with corresponding Id from database and returns to Index-View */

        [Authorize(Roles = "Admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Users.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET Update
        /* Redirection to the view, where the User and its corresponding ID cna be updated*/

        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Update(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Update
        /* Apply changes to database and return to Index-View*/

        [Authorize(Roles = "Admin, Supervisor")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(User obj)
        {
            if (ModelState.IsValid)
            {

                _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _db.Entry(obj).Property("Roles").IsModified = false;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // page, where using the select-function the role user or superviser is selected

        [Authorize(Roles = "Admin")]
        public IActionResult UpdateRole(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Users.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Update
        // Apply changes to database and return to Index-View

        [Authorize(Roles = "Admin")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateRole(User obj)
        {

            // if (ModelState.IsValid)
            //  {

            //    _db.Users.Update(obj);
            _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.Entry(obj).Property("Email").IsModified = false;
            _db.Entry(obj).Property("University").IsModified = false;
            _db.Entry(obj).Property("Password").IsModified = false;
            _db.Entry(obj).Property("Name").IsModified = false;
            _db.SaveChanges();
            return RedirectToAction("Index");
            //    }
        }

        
    }
}