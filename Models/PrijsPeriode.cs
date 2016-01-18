using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace prog5.Models
{
    [Table("PrijsPeriode")]
    public class PrijsPeriode
    {
        [Key]
        public int PrijsPeriodeId { get; set; }
        public int id { get; set; }

        [ForeignKey("id")]
        public virtual Prijs prijs { get; set; }

        public DateTime BeginDatum { get; set; }

        public DateTime EindDatum { get; set; }
    }
}