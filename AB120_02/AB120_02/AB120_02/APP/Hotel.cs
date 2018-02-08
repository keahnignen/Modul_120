using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB120_02.APP
{
    /// <summary>
    /// Applikationsschicht: CRUD Klasse für Hotel
    /// </summary>
    static class Hotel
    {
        /// <summary>
        /// Methode: Liste von allen Hotels lesen
        /// </summary>
        /// <returns></returns>
        public static List<DB.Hotel> Lesen_Alle()
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Hotel select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: ein Hotel lesen anhand Primärschlüssel
        /// </summary>
        /// <param name="hotelID"></param>
        /// <returns></returns>
        public static DB.Hotel Lesen_HotelID(Int64 hotelID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Hotel where rec.HotelID == hotelID select rec).FirstOrDefault();
            }
        }
        /// <summary>
        /// Methode: Liste von Hotels lesen anhand exaktem Match auf Name
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public static List<DB.Hotel> Lesen_Name(string hotelName)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Hotel where rec.Name == hotelName select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Liste von Hotels lesen anhand ReiseID
        /// </summary>
        /// <param name="reiseID"></param>
        /// <returns></returns>
        public static List<DB.Hotel> Lesen_ReiseID(Int64 reiseID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Hotel join rh in db.Reise_Hotel on rec.HotelID equals rh.Hotel where rh.Reise == reiseID select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Liste von Hotels lesen anhand LandID
        /// </summary>
        /// <param name="landID"></param>
        /// <returns></returns>
        public static List<DB.Hotel> Lesen_LandID(Int64 landID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Hotel where rec.Land == landID select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Liste von Hotels lesen anhand Sterne
        /// </summary>
        /// <param name="sterne"></param>
        /// <returns></returns>
        public static List<DB.Hotel> Lesen_Sterne(byte sterne)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Hotel where rec.Sterne == sterne select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Liste von Hotel lesen anhand Teilmatch auf Name
        /// </summary>
        /// <param name="hotelName"></param>
        /// <returns></returns>
        public static List<DB.Hotel> Lesen_NameWie(string hotelName)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Hotel where rec.Name.Contains(hotelName) select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Neues Hotel erstellen
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        public static Int64 Erstellen(DB.Hotel hotel)
        {
            if (hotel.Name == null) hotel.Name = "";
            if (hotel.Ort == null) hotel.Ort = "";
            if (hotel.Land == 0) hotel.Land = 192;
            if (hotel.Manager == null) hotel.Manager = "";
            if (hotel.Telefon == null) hotel.Telefon = "";
            if (hotel.Email == null) hotel.Email = "";
            if (hotel.Web == null) hotel.Web = "";
            using (var db = new DB.M120Datenbank())
            {
                db.Hotel.Add(hotel);
                db.SaveChanges();
                db.Entry(hotel).Reload();
                return hotel.HotelID;
            }
        }
        /// <summary>
        /// Methode: Bestehendes Hotel aktualisieren
        /// </summary>
        /// <param name="hotel"></param>
        public static void Aktualisieren(DB.Hotel hotel)
        {
            using (var db = new DB.M120Datenbank())
            {
                db.Entry(hotel).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Methode: Löschen eines Hotels
        /// </summary>
        /// <param name="hotel"></param>
        public static void Loeschen(DB.Hotel hotel)
        {
            using (var db = new DB.M120Datenbank())
            {
                db.Entry(hotel).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
