using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb120_2_Bibliothek.APP
{
    static class Kunde
    {
        public static List<DB.Kunde> Lesen_Alle()
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Kunden select rec).ToList();
            }
        }
        public static DB.Kunde Lesen_ID(Int64 KundeId)
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Kunden where rec.KundeId == KundeId select rec).FirstOrDefault();
            }
        }
        public static DB.Kunde Lesen_Name(String Name)
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Kunden where rec.Name == Name select rec).FirstOrDefault();
            }
        }

        public static Int64 Erstellen(DB.Kunde Kunde)
        {
            if (Kunde.Name == null) Kunde.Name = "";
            if (Kunde.Ortschaft == null) Kunde.Ortschaft = "";
            using (var db = new DB.Context())
            {
                db.Kunden.Add(Kunde);
                db.SaveChanges();
                return Kunde.KundeId;
            }
        }
        public static void Aktualisieren(DB.Kunde Kunde)
        {
            using (var db = new DB.Context())
            {
                db.Entry(Kunde).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}
