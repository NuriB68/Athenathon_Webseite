using Athenathon_Webseite.Data;
using Athenathon_Webseite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;


namespace Athenathon_Webseite.Controllers
{
    public class NewsfeedController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NewsfeedController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Implementation of searchoption
        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Index(string searchText)
        {
            return View(_db.Newsfeeds.Where(a => a.Time.Contains(searchText) || a.Title.Contains(searchText)  || a.Author.Contains(searchText) || searchText == null).ToList()); 
        }


        // GET Create
        /* Redirects to the user creation view */

        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Create()
        {
            return View();
        }


        // POST Create
        /* Adds new User to database and returns to Index-View */


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Create(Newsfeed obj)
        {
            if (ModelState.IsValid)
            {
                _db.Newsfeeds.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        // GET Update
        /* Redirection to the view, where the User and its corresponding ID can be updated*/
        [Authorize(Roles = "Admin, Supervisor")]

        public IActionResult Update(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var obj = _db.Newsfeeds.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            
            return View(obj);
        }


        // POST Update
        /* Updates Changes to database and returns to Index-View */



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Update(Newsfeed obj)
        {
            {
                if (ModelState.IsValid)
                {

                    _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _db.Entry(obj).Property("NewsId").IsModified = false;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
        }

        // GET Delete
        /*  Redirection to the view where the user is displayed with the corresponding Id 
         *  and the option of deletion is available */
        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return NotFound();
            }

            var obj = _db.Newsfeeds.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        // POST Delete
        /* Deletion of the User with its Id from the database and returns to Index-View */



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult DeletePost(int? newsid)
        {
            if (newsid == null || newsid <= 0)
            {
                return NotFound();
            }

            var obj = _db.Newsfeeds.Find(newsid);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Newsfeeds.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
