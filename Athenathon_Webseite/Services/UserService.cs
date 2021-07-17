using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Athenathon_Webseite.Data;

namespace Athenathon_Webseite.Services
{
    public class UserService  // hier werden infos aus der datenbank gesucht, um zu schauen ob login erlaubt werden soll
                              // funktion wird in login aufgerufen
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }


        internal bool TryValidateUser(string email, string password, out List<Claim> claims)
        {
            claims = new List<Claim>();
            var appUser = _context.Users
                 .Where(a => a.Email == email)
                 .Where(a => a.Roles == "Admin" || a.Roles == "Supervisor")  // nur diese rollen dürfen sich anmelden
                 .Where(a => a.Password == password).FirstOrDefault();

            if (appUser is null)
            {
                return false;
            }
            else
            {

                claims.Add(new Claim("email", email));
                claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
                claims.Add(new Claim(ClaimTypes.Role, appUser.Roles));
                return true;
            }

        }

    }


}
