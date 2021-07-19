using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Athenathon_Webseite.Models
{
    //Table Newsfeed with the columns Time, Title, Text and Author
    public class Newsfeed
    {
        public Newsfeed()
        {

        }

        [Key]
        [Required]
        public string Time { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Author { get; set; }
    }
}