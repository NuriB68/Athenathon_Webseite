using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace Athenathon_Webseite.Models
{
    //Table User with the columns Id, Email and University
    public class User
    {
        public User()
        {
            UserDistances = new List<UserDistance>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        //Validation of Email-Input
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+(@student.uni-siegen.de|@unicusano.it|@unicusano.com|@student.um.si|@um.si|@hmu.gr|@vgtu.lt|@stud.vgtu.lt|@vilniustech.lt|@ipp.pt|@etu.univ-orleans.fr)$", ErrorMessage = "University mail from participating universities required")]
        public string Email { get; set; }
        [Required]
        public string University { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Roles { get; set; }
        public bool Locked { get; set; }
        public List<UserDistance> UserDistances { get; set; }

    }
}