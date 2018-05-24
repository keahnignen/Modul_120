using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb120_2_Bibliothek.APP
{
    static class Buch
    {
        public static List<DB.Buch> Lesen_Alle()
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Buecher select rec).ToList();
            }
        }
        public static DB.Buch Lesen_ID(Int64 BuchId)
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Buecher where rec.BuchId == BuchId select rec).FirstOrDefault();
            }
        }
        public static DB.Buch Lesen_Titel(String Titel)
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Buecher where rec.Titel == Titel select rec).FirstOrDefault();
            }
        }

        public static Int64 Erstellen(DB.Buch Buch)
            {
            if (Buch.Titel == null) Buch.Titel = "";
            using (var db = new DB.Context())
            {
                db.Buecher.Add(Buch);
                db.SaveChanges();
                return Buch.BuchId;
            }
        }
        public static void Aktualisieren(DB.Buch Buch)
        {
            using (var db = new DB.Context())
            {
                db.Entry(Buch).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}
