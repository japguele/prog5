using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace prog5.Models
{
    public class MyDBInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 3,
                Naam = "Love room",
            });

            context.Gast.Add(new Gast()
            {
                GastNr = 0,
                Naam = "jan",
                TussenVoegsel = "van",
                Achternaam = "hooi",
                Geboortedatum = new DateTime(2000,1,15),
                Vrouw = false,
                Woonplaats = "Nijmegen",
                Email = "janvanhooi@email.nl",
                Postcode = "1234 ab",
                Addres = "poffertjesstraat 2",
    

            });

            context.Booking.Add(new Booking()
            {
                GastNr = 0,
                StartDate = new DateTime(2015, 1, 15),
                EndDate = new DateTime(2015, 1, 17),

            });
            context.SaveChanges();
        }
    }
}
