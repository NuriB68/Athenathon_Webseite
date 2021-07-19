using Athenathon_Webseite.Data;
using Athenathon_Webseite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


//in Arbeit!
namespace Athenathon_Webseite.Controllers
{
    public class NewsfeedController : Controller
    {
        private readonly ApplicationDbContext _db;
        public NewsfeedController(ApplicationDbContext db)
        {
            _db = db;
        }
      
        public IActionResult Index(string searchText)
        {
            return View(_db.Newsfeeds.Where(a => a.Time.Contains(searchText) || a.Title.Contains(searchText)    || a.Author.Contains(searchText) || searchText == null).ToList()); 
        }

        
        public IActionResult Create()
        {
            List<Newsfeed> cl = new List<Newsfeed>();
            cl = (from c in _db.Newsfeeds select c).ToList();
            ViewBag.message = cl;

            return View();
        }

        // POST Create
        /* Adds new User to database and returns to Index-View */



        [HttpPost]
        [ValidateAntiForgeryToken]
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

        public IActionResult Update(int? Time)
        {

            if (Time == null )
            {
                return NotFound();
            }
            var obj = _db.Newsfeeds.Find(Time);
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
        public IActionResult Update(Newsfeed obj)
        {
            {
                if (ModelState.IsValid)
                {

                    _db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    _db.Entry(obj).Property("Time").IsModified = false;
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(obj);
            }
        }

        public IActionResult Delete(int? Time)
        {
            if (Time == null )
            {
                return NotFound();
            }
            var obj = _db.Newsfeeds.Find(Time);
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
        public IActionResult DeletePost(int? Time)
        {
            var obj = _db.UserDistances.Find(Time);
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
