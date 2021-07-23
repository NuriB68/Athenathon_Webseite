using Athenathon_Webseite.Data;
using Athenathon_Webseite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;


namespace Athenathon_Webseite.Controllers
{
    public class DistancesController : Controller  // Conroller for the Distances page, where you can see, add, update and delete distances
                                                   // all functions are accessable for admin and supervisor
    {
        private readonly ApplicationDbContext _db;
        public DistancesController(ApplicationDbContext db)
        {
            _db = db;
        }
        // Implementation of Searchoption
        public IActionResult Index(string searchText)  // all users distances (not Admin's) are listed with their UserID
                                                       // you can search for specific distances
        {
            return View(_db.UserDistances.Where(
                a => a.Id.ToString().Contains(searchText) 
                && a.User.Roles != "Admin" 
                || a.TypeOfSport.Contains(searchText) 
                && a.User.Roles != "Admin"
                || a.User.Name.Contains(searchText) 
                || searchText == null 
                && a.User.Roles != "Admin").ToList()
            ); 
        }


        // GET Create
        /* Redirects to the user creation view */

        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Create()  // page, where new distances can be added to database, you cannot see admin's ID
        {
            List<User> cl = new List<User>();
            cl = (from c in _db.Users.Where(a => a.Roles != "Admin") select c).ToList();
            ViewBag.message = cl;

            return View();
        }

        // POST Create
        /* Adds new Distance to database and returns to Index-View */

        [Authorize(Roles = "Admin, Supervisor")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserDistance obj)
        {
            if (ModelState.IsValid)
            {
                _db.UserDistances.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        // GET Update
        /* Redirection to the view, where the Distance and its corresponding ID can be updated*/


        /* 23.07.2021: till yesterday it was possible to upload new distance entries with distance and average speed as double/
        floats. But today we were suddenly confronted with the problem that a comma as this ',' is not accepted anymore
        also you can only give in values like integers or decimal dots 'x.y' like 13.04, now our biggest problem is, if we want to 
        pass these new values to the database it is automatically converted into an integer so our example below : 
        13.04 gets 1304 and we were not able to fix this problem. Technically we do not know how this problem occured.
        We did not change anything in the code nor the database. Still we have tried to delete the distance table and build
        it new again. But the problem is still present. We tried various of things but without knowing how this has 
        happened, why it has happended so where the problem exactly is, we do not understand how to fix it.
        Inserting data through the app still works fine. So for now sadly it is only possible to insert integer distances and 
        average speed manually through the website.
        .*/

        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Update(int? id)  // page, where you can update or edit distances
        {
            
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.UserDistances.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Update
        /* Updates Changes to database and returns to Index-View */

        [Authorize(Roles = "Admin, Supervisor")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(UserDistance obj)
        {
            {
                if (ModelState.IsValid)
                {

                    _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _db.Entry(obj).Property("Id").IsModified = false;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
        }

        // GET Delete
        /*  Redirection to the view where the Distance is displayed with the corresponding Id 
         *  and the option of deletion is available */
        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Delete(int? id)  // page, where you can delete distance entries
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.UserDistances.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Delete
        /* Deletion of the Distance with the User ID and with its Id from the database and returns to Index-View */


        [Authorize(Roles = "Admin, Supervisor")]

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.UserDistances.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.UserDistances.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
