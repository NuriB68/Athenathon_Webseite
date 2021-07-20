﻿using Athenathon_Webseite.Data;
using Athenathon_Webseite.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athenathon_Webseite.Controllers
{
    public class DistancesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DistancesController(ApplicationDbContext db)
        {
            _db = db;
        }
      
        // Implementation of Searchoption
        public IActionResult Index(string searchText)
        {
            return View(_db.UserDistances.Where(a => a.Id.ToString().Contains(searchText) && a.User.Roles != "Admin" || a.TypeOfSport.Contains(searchText) && a.User.Roles != "Admin"
             || a.User.Name.Contains(searchText) || searchText == null && a.User.Roles != "Admin").ToList()); 
        }


        // GET Create
        /* Redirects to the user creation view */

        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Create()
        {
            List<User> cl = new List<User>();
            cl = (from c in _db.Users.Where(a => a.Roles != "Admin") select c).ToList();
            ViewBag.message = cl;

            return View();
        }

        // POST Create
        /* Adds new User to database and returns to Index-View */

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


        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Update(int? id)
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

        [Authorize(Roles = "Admin, Supervisor")]
        public IActionResult Delete(int? id)
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
        /* Deletion of the User with its Id from the database and returns to Index-View */


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
