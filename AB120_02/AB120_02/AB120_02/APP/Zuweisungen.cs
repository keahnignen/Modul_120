using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB120_02.APP
{
    static class Zuweisungen
    {
        public static Int64 Erstellen_Kunde_Reise(Int64 kundeID, Int64 reiseID)
        {
            using (var db = new DB.M120Datenbank())
            {
                DB.Kunde_Reise rec = new DB.Kunde_Reise();
                rec.Kunde = kundeID;
                rec.Reise = reiseID;
                db.Kunde_Reise.Add(rec);
                db.SaveChanges();
                db.Entry(rec).Reload();
                return rec.Kunde_Reise_ID;
            }
        }
        public static Int64 Erstellen_Reise_Hotel(Int64 reiseID, Int64 hotelID)
        {
            using (var db = new DB.M120Datenbank())
            {
                DB.Reise_Hotel rec = new DB.Reise_Hotel();
                rec.Reise = reiseID;
                rec.Hotel = hotelID;
                db.Reise_Hotel.Add(rec);
                db.SaveChanges();
                db.Entry(rec).Reload();
                return rec.Reise_Hotel_ID;
            }
        }
        public static void Loeschen_Kunde_Reise(Int64 kundeID, Int64 reiseID)
        {
            using (var db = new DB.M120Datenbank())
            {
                IQueryable<DB.Kunde_Reise> query = from rec in db.Kunde_Reise where rec.Kunde == kundeID && rec.Reise == reiseID select rec;
                foreach (DB.Kunde_Reise element in query)
                {
                    db.Entry(element).State = System.Data.Entity.EntityState.Deleted;
                }
                db.SaveChanges();
            }
        }
        public static void Loeschen_Reise_Hotel(Int64 reiseID, Int64 hotelID)
        {
            using (var db = new DB.M120Datenbank())
            {
                IQueryable<DB.Reise_Hotel> query = from rec in db.Reise_Hotel where rec.Reise == reiseID && rec.Hotel == hotelID select rec;
                foreach (DB.Reise_Hotel element in query)
                {
                    db.Entry(element).State = System.Data.Entity.EntityState.Deleted;
                }
                db.SaveChanges();
            }
        }
    }
}
