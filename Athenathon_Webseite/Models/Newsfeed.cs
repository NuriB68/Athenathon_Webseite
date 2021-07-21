using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Athenathon_Webseite.Models
{
    public class Newsfeed
    {

        [Key]
        public int NewsId { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public string Author { get; set; }
        public Newsfeed()
        {
       
        }
    }


}
