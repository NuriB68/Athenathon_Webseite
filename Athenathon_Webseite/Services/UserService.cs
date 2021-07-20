using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Athenathon_Webseite.Data;

namespace Athenathon_Webseite.Services
{
    public class UserService  // infos are searched from the database to see if login should be allowed
                              // function is called in login
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // email and password are checked if they are represented in the database, acces is checked( depending on roles and if supervisor is locked or not)
        internal bool TryValidateUser(string email, string password, out List<Claim> claims)
        {
            claims = new List<Claim>();
            var appUser = _context.Users
                 .Where(a => a.Email == email)
                 .Where(a => a.Roles == "Admin" || a.Roles == "Supervisor")  // only these roles are allowed to login
                 .Where(a => a.Locked == false) // only allowed if not locked
                 .Where(a => a.Password == password).FirstOrDefault();

            if (appUser is null)
            {
                return false;
            }
            else
            {
                // if user is in database and have access to website new claims are added
                claims.Add(new Claim("email", email));
                claims.Add(new Claim(ClaimTypes.Email, appUser.Email));
                claims.Add(new Claim(ClaimTypes.Role, appUser.Roles));  //  will be used for showing or hiding buttons or certain text depending on role
                return true;
            }

        }

    }


}
