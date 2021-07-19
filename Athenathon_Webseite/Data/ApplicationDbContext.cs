using Athenathon_Webseite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Athenathon_Webseite.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Includes tables in the DbContext
         public DbSet<User> Users { get; set; }
         public DbSet<UserDistance> UserDistances { get; set; }
         public DbSet<Newsfeed> Newsfeeds { get; set; }

    }
}
