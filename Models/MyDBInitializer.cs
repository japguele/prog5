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
                id = 1,
                Naam = "Normale prijs",
                Kosten = 20,
            });

            context.Prijs.Add(new Prijs()
            {
                id = 2,
                Naam = "Hoogseizoen",
                Kosten = 30,
            });

            context.Prijs.Add(new Prijs()
            {
                id = 3,
                Naam = "Laagseizoen",
                Kosten = 10,
            });

            context.PrijsPeriode.Add(new PrijsPeriode()
            {
                id = 1,
                BeginDatum = new DateTime(634292263478068039),
                EindDatum = new DateTime(636292263478068039),
            });

            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 2,
                Naam = "Red room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 3,
                Naam = "Blue room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 5,
                Naam = "Green room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 2,
                Naam = "Yellow room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 3,
                Naam = "Orange room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 5,
                Naam = "Purple room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 2,
                Naam = "Rainbow room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 3,
                Naam = "Black room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 5,
                Naam = "White room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 2,
                Naam = "Grey room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 3,
                Naam = "Transparant room",
                MinimalePrijs = 10,
            });
            context.Kamers.Add(new Kamer()
            {
                Capaciteit = 5,
                Naam = "Invisible room",
                MinimalePrijs = 10,
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

            /*context.Booking.Add(new Booking()
            {
                GastNr = 0,
                StartDate = new DateTime(2015, 1, 15),
                EndDate = new DateTime(2015, 1, 17),

            });*/
            context.SaveChanges();
        }
    }
}
