using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prog5.Models
{
    public class BookKamerModel
    {
        public List<Booking> Booking { get; set; }

        public Booking Book { get; set; }
        public Kamer Kamer { get; set; }
    }
}