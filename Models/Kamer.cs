using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prog5.Models
{
    [Table("Kamer")]
    public class Kamer
    {
        [Key]
        public int KamerNr { get; set; }

        public String Naam { get; set; }

        public int Capaciteit { get; set; }
    }
}