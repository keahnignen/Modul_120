namespace lb120_2_Bibliothek.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<lb120_2_Bibliothek.DB.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "lb120_2_Bibliothek.DB.Context";
        }

        protected override void Seed(lb120_2_Bibliothek.DB.Context context)
        {
            IList<DB.Kunde> demoKunden = new List<DB.Kunde>();
            
            demoKunden.Add(new DB.Kunde { Name = "Albert", Ortschaft = "Althofen" });
            demoKunden.Add(new DB.Kunde { Name = "Bruno", Ortschaft = "Basel" });
            demoKunden.Add(new DB.Kunde { Name = "Christ", Ortschaft = "Heilig" });
            
            context.Kunden.AddRange(demoKunden);

            IList<DB.Buch> demoBuecher = new List<DB.Buch>();
            
            demoBuecher.Add(new DB.Buch { Titel = "A# for beginners" });
            demoBuecher.Add(new DB.Buch { Titel = "B# for professionals" });
            demoBuecher.Add(new DB.Buch { Titel = "C# for genius" });
            
            context.Buecher.AddRange(demoBuecher);
            base.Seed(context);
        }
    }
}
