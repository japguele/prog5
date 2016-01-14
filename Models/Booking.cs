using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prog5.Models
{
     [Table("Booking")]
    public class Booking
    {
        [Key]
        public int Booknr { get; set; }

        public int KamerNr { get; set; }

        [ForeignKey("KamerNr")]
        public virtual Kamer Kamer { get; set; }

        public int GastNr { get; set; }
    
        [ForeignKey("GastNr")]
        public virtual Gast Gast { get; set; }

      
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}