using System.ComponentModel.DataAnnotations;


namespace Athenathon_Webseite.Models
{
    //Model of the Newsfeed, including NewsId, Time (later called Date on the actual Website), Title, Text and Author
    //as columns of a table.
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
