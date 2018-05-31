using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb120_2_Bibliothek.APP
{
    public static class Ausleihe
    {
        public static List<DB.Ausleihe> Lesen_Alle()
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Ausleihen.Include("Buch").Include("Kunde") select rec).ToList();
            }
        }
        public static DB.Ausleihe Lesen_ID(Int64 AusleiheId)
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Ausleihen where rec.AusleiheId == AusleiheId select rec).FirstOrDefault();
            }
        }
        public static List<DB.Ausleihe> Lesen_BuchId(Int64 BuchId)
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Ausleihen where rec.Buch.BuchId == BuchId select rec).ToList(); ;
            }
        }
        public static DB.Ausleihe Lesen_Datum(DateTime Datum)
        {
            using (var db = new DB.Context())
            {
                return (from rec in db.Ausleihen where rec.Start <= Datum && rec.Ende >= Datum select rec).FirstOrDefault();
            }
        }

        public static Int64 Erstellen(DB.Ausleihe Ausleihe)
        {
            if (Ausleihe.Bemerkungen == null || Ausleihe.Bemerkungen == "") Ausleihe.Bemerkungen = "keine";
            if (Ausleihe.Buch == null) throw new Exception("Null ist ungültig");
            if (Ausleihe.Kunde == null) throw new Exception("Null ist ungültig");
            if (Ausleihe.Start == null) throw new Exception("Null ist ungültig");
            if (Ausleihe.Ende == null) throw new Exception("Null ist ungültig");
            using (var db = new DB.Context())
            {

                db.Ausleihen.Add(Ausleihe);
                db.Buecher.Attach(Ausleihe.Buch);
                db.Kunden.Attach(Ausleihe.Kunde);
                db.SaveChanges();
                return Ausleihe.AusleiheId;
            }
        }
        public static void Aktualisieren(DB.Ausleihe Ausleihe)
        {
            using (var db = new DB.Context())
            {
                db.Entry(Ausleihe).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

    }
}
