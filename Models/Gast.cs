using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prog5.Models
{
    [Table("Gast")]
    public class Gast
    {
        [Key]
        public int GastNr { get; set; }
        public String Naam { get; set; }
        public String TussenVoegsel { get; set; }
        public String Achternaam { get; set; }
        public DateTime Geboortedatum { get; set; }
        public bool Vrouw { get; set; }
        public String Woonplaats { get; set; }
        public String Email { get; set; }
        public String Postcode { get; set; }
        public String Addres { get; set; }

    }
}