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
        [Required]
        public String Naam { get; set; }
        [Required]
        [Range(2,5,ErrorMessage="Choose one of the following numbers: 2,3,5.")]
        public int Capaciteit { get; set; }
        [Required]
        public int MinimalePrijs { get; set; }
        public Nullable<int> PeriodeId { get; set; }
        [ForeignKey("PeriodeId")]
        public virtual PrijsPeriode PrijsPeriode { get; set; }
        
    }
}