using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace prog5.Models
{
    //public class MyDBInitializer : DropCreateDatabaseIfModelChanges<MyContext>
    public class MyDBInitializer : DropCreateDatabaseAlways<MyContext>
    {
        protected override void Seed(MyContext context)
        {

            context.Prijs.Add(new Prijs()
            {
                Naam = "Normale prijs",
                Kosten = 20,
            });

            context.Prijs.Add(new Prijs()
            {
                Naam = "Hoogseizoen",
                Kosten = 30,
            });

            context.Prijs.Add(new Prijs()
            {
                Naam = "Laagseizoen",
                Kosten = 10,
            });

            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 2,
                Naam = "Red room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 3,
                Naam = "Blue room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 5,
                Naam = "Green room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 2,
                Naam = "Yellow room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 3,
                Naam = "Orange room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 5,
                Naam = "Purple room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 2,
                Naam = "Rainbow room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 3,
                Naam = "Black room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 5,
                Naam = "White room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 2,
                Naam = "Grey room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 3,
                Naam = "Transparant room",
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 5,
                Naam = "Invisible room",
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
