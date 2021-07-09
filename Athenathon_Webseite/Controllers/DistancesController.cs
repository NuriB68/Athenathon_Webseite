using Athenathon_Webseite.Data;
using Athenathon_Webseite.Models;
using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
            IEnumerable<UserDistance> objList = _db.UserDistances;
            return View(objList);
        }
    }
}
