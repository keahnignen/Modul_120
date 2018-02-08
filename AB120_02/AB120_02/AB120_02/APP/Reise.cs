using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB120_02.APP
{
    /// <summary>
    /// Applikationsschicht: CRUD Klasse für Reise
    /// </summary>
    static class Reise
    {
        /// <summary>
        /// Methode: Liste von allen Reisen lesen
        /// </summary>
        /// <returns></returns>
        public static List<DB.Reise> Lesen_Alle()
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Reise select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: eine Reise lesen anhand Primärschlüssel
        /// </summary>
        /// <param name="reiseID"></param>
        /// <returns></returns>
        public static DB.Reise Lesen_ReiseID(Int64 reiseID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Reise where rec.ReiseID == reiseID select rec).FirstOrDefault();
            }
        }
        /// <summary>
        /// Methode: Liste von Reisen lesen anhand KundenID
        /// </summary>
        /// <param name="kundeID"></param>
        /// <returns></returns>
        public static List<DB.Reise> Lesen_KundenID(Int64 kundeID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Reise join rk in db.Kunde_Reise on rec.ReiseID equals rk.Reise where rk.Kunde == kundeID select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Liste von Reisen lesen anhand HotelID
        /// </summary>
        /// <param name="hotelID"></param>
        /// <returns></returns>
        public static List<DB.Reise> Lesen_HotelID(Int64 hotelID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Reise join rh in db.Reise_Hotel on rec.ReiseID equals rh.Reise where rh.Hotel == hotelID select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Liste von Reisen lesen anhand LandID
        /// </summary>
        /// <param name="landID"></param>
        /// <returns></returns>
        public static List<DB.Reise> Lesen_LandID(Int64 landID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Reise where rec.Land == landID select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Neue Reise erstellen
        /// </summary>
        /// <param name="reise"></param>
        /// <returns></returns>
        public static Int64 Erstellen(DB.Reise reise)
        {
            if (reise.Start == null) reise.Start = DateTime.Now;
            if (reise.Ende == null) reise.Ende = DateTime.Now;
            if (reise.NameLeitung == null) reise.NameLeitung = "";
            using (var db = new DB.M120Datenbank())
            {
                db.Reise.Add(reise);
                db.SaveChanges();
                db.Entry(reise).Reload();
                return reise.ReiseID;
            }
        }
        /// <summary>
        /// Methode: Bestehende Reise aktualisieren
        /// </summary>
        /// <param name="reise"></param>
        public static void Aktualisieren(DB.Reise reise)
        {
            using (var db = new DB.M120Datenbank())
            {
                db.Entry(reise).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Methode: Löschen einer Reise
        /// </summary>
        /// <param name="reise"></param>
        public static void Loeschen(DB.Reise reise)
        {
            using (var db = new DB.M120Datenbank())
            {
                db.Entry(reise).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
