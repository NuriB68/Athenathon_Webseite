using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Athenathon_Webseite.Models
{
    //Table UserDistance with the columns DistanceId, Distance, TypeOfSport, DayTime, Duration,
    //AverageSpeed and CaloriesBurned
    public class UserDistance
    {
         [Key]
        public int DistanceId { get; set; }
        [Required]
        public double Distance { get; set; }
        [Required]
        public string TypeOfSport { get; set; }
        [RegularExpression(@"^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$", ErrorMessage = "Format must be hh:mm")]
        public string DayTime { get; set; }
        [Required]
        [RegularExpression(@"^([0-9][0-9]):[0-5][0-9]:[0-5][0-9]$", ErrorMessage = "Invalid Duration")]
        public string Duration { get; set; }
        public double AverageSpeed { get; set; }
        public int CaloriesBurned { get; set; }

        [ForeignKey("User")]

        public int Id { get; set; }
        public User User { get; set; }  
            
    }   
}
