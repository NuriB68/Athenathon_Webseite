using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Athenathon_Webseite.Models
{
    public class UserDistance
    {
        [Key]
        public int DistanceId { get; set; }
        public int Distance { get; set; }
        public string TypeOfSport { get; set; }
        public int DayTime { get; set; }
        public int Duration { get; set; }
        public int AverageSpeed { get; set; }
        public int CaloriesBurned { get; set; }
        public User User { get; set; }  
            
    }   
}
