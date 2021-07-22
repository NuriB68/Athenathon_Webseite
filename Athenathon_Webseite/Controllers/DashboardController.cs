using Microsoft.AspNetCore.Mvc;
using Athenathon_Webseite.Data;


namespace Athenathon_Webseite.Controllers
{
    //Controller for the Dashboard leading to Index View
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _db;
        public DashboardController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        /* Nach 5 Tagen ausgiebigem Probieren (10h je) habe ich die Datenbankanbindung für das Dashboard nicht auf die 
         * Reihe gekriegt. Theoretisch sollte es so funktionieren:
         * 1. WebMethod erstellen (um Google Chart mit Werten aus der Datenbank zu füllen.
         * Query zieht Daten, Ergebnisse werden in Array überführt, und dann als Liste von Objekten weitergegeben
         * 2. Im Index View des Dashboards zuerst die Google Chart API integrieren, dann drawChart Methode nutzen um mittels
         * jQuery AJAX die WebMethod zu initialisieren. Chart einem Div ELement zuweisen.
         * 
         * Leider war ich durch andere universitäre Verpflichtungen daran gebunden, meine Teilaufgaben erst im Juli
         * erledigen zu können. Mit mehr Zeit bin ich zuversichtlich, das ich die Datenbankanbindung noch hinbekommen hätte.
         * So habe ich mich für das Minimum Viable Product eines MockUp Dashboards entschieden, in dem die Daten hart gecoded sind
         * aber zumindest das Design des Dashboards fertig und sichtbar ist.
         * Ich möchte sie bitten meine mangelnde Zeitplanung nicht meinen Kommilitonen zu Last zu legen.
         * Mit freundlichen Grüßen
         * Anne Schmallenbach
         */
        
        public IActionResult Index()
        {
            return View();
        }
    }
}

