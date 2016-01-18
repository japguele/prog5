using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prog5.Models
{
    [Table("Prijs")]
    public class Prijs
    {
        [Key]
        public int id { get; set; }

        public String Naam { get; set; }

        public int Kosten { get; set; }

    }
}