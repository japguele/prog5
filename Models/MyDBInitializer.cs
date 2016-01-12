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

            context.SaveChanges();
        }
    }
}
