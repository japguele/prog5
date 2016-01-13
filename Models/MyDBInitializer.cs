﻿using System;
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


            context.SaveChanges();
        }
    }
}