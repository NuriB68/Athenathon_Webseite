using Athenathon_Webseite.Data;
using Athenathon_Webseite.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Athenathon_Webseite.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;

        public UserController(ApplicationDbContext db)
        {
            _db = db;
        }

        /* Startseite der User page, welche die Liste der aktuellen
         Nutzer mit ihren Details anzeigt und weitere Optionen bietet */
        public IActionResult Index()
        {
            IEnumerable<User> objList = _db.Users;
            return View(objList);
        }

        // GET Create
        /* Leitet weiter zur Ansicht der Nutzererstellung */
        public IActionResult Create()
        {
            return View();
        }

        // POST Create
        /* Fügt den neuen Nutzer der Datenbank hinzu und kehrt
           zur Index-Ansicht zurück */
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
        /* Weiterleitung zur Ansicht, wo der Nutzer mit der entsprechenden
           Id angezeigt wird und die Option des Löschens vorliegt */
        public IActionResult Delete(int? id)
        {
            if (id == null || id==0)
            {
                return NotFound();
            }
            var obj = _db.Users.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST Delete
        /* Löschung des Nutzers mit der jeweiligen Id aus der Datenbank
           und Weiterleitung zur Index-Ansicht */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? id)
        {
            var obj = _db.Users.Find(id);
            if(obj == null)
            {
                return NotFound();
            }

            _db.Users.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET Update
        /* Weiterleitung zur Ansicht, wo der Nutzer mit der jeweiligen
           Id bearbeitet werden kann */
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
        /* Übernehmen der Veränderungen in der Datenbank und Weiterleitung
           zur Index-Ansicht */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(User obj)
        {
            if (ModelState.IsValid)
            {
                _db.Users.Update(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obj);
        }
    }
}
