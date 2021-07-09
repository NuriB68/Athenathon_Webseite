using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Athenathon_Webseite.Models
{
    //Tabelle Nutzer mit den Spalten Id, Email und University
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        //Validierung der Emaileingabe
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+(@student.uni-siegen.de|@unicusano.it|@unicusano.com|@student.um.si|@um.si|@hmu.gr|@vgtu.lt|@stud.vgtu.lt|@vilniustech.lt|@ipp.pt|@etu.univ-orleans.fr)$", ErrorMessage = "University mail from participating universities required")]
        public string Email { get; set; }
        [Required]
        //Validierung der Universitätseingabe
        [RegularExpression("Siegen|Orleans|Porto|Rome|Crete|Maribor|Vilnius", ErrorMessage = "University is not part of the Event")]
        public string University { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }

        public string Roles { get; set; }
        public ICollection<UserDistance> UserDistances { get; set; }

    }
}