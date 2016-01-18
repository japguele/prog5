using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace prog5.Models
{
    public class MyContext : DbContext
    {
        public MyContext()
        {
            Database.SetInitializer(new MyDBInitializer());
        }
        public DbSet<Kamer> Kamers { get; set; }
        public DbSet<Prijs> Prijs { get; set; }
        public DbSet<Gast> Gast { get; set; }
        public DbSet<Booking> Booking { get; set; }
    }
}