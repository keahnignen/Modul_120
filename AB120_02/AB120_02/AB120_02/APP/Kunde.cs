using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB120_02.APP
{
    /// <summary>
    /// Applikationsschicht: CRUD Klasse für Kunde
    /// </summary>
    static class Kunde
    {
        /// <summary>
        /// Methode: Liste aller Kunden lesen
        /// </summary>
        /// <returns></returns>
        public static List<DB.Kunde> Lesen_Alle()
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Kunde select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: ein Kunde lesen anhand Primärschlüssel
        /// </summary>
        /// <param name="kundenID"></param>
        /// <returns></returns>
        public static DB.Kunde Lesen_KundeID(Int64 kundenID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Kunde where rec.KundeID == kundenID select rec).FirstOrDefault();
            }
        }
        /// <summary>
        /// Methode: Liste von Kunden lesen anhand exaktem Match auf Name
        /// </summary>
        /// <param name="kundeName"></param>
        /// <returns></returns>
        public static List<DB.Kunde> Lesen_Name(string kundeName)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Kunde where rec.Name == kundeName select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Liste von Kunden lesen anhand Teilmatch auf Name
        /// </summary>
        /// <param name="kundeName"></param>
        /// <returns></returns>
        public static List<DB.Kunde> Lesen_NameWie(string kundeName)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Kunde where rec.Name.Contains(kundeName) select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Liste von Kunden lesen anhand reiseID
        /// </summary>
        /// <param name="reiseID"></param>
        /// <returns></returns>
        public static List<DB.Kunde> Lesen_ReiseID(Int64 reiseID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Kunde join rk in db.Kunde_Reise on rec.KundeID equals rk.Kunde where rk.Reise == reiseID select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Neuen Kunden erstellen
        /// </summary>
        /// <param name="kunde"></param>
        /// <returns></returns>
        public static Int64 Erstellen(DB.Kunde kunde)
        {
            if (kunde.Anrede == null) kunde.Anrede = "";
            if (kunde.Email == null) kunde.Email = "";
            if (kunde.Geburtsdatum == null) kunde.Geburtsdatum = DateTime.Today;
            if (kunde.Mobile == null) kunde.Mobile = "";
            if (kunde.Name == null) kunde.Name = "";
            if (kunde.NameZusatz == null) kunde.NameZusatz = "";
            if (kunde.Ort == null) kunde.Ort = "";
            if (kunde.PassNr == null) kunde.PassNr = "";
            if (kunde.StrasseNr == null) kunde.StrasseNr = "";
            if (kunde.Telefon == null) kunde.Telefon = "";
            if (kunde.Vorname == null) kunde.Vorname = "";
            if (kunde.Web == null) kunde.Web = "";
            if (kunde.Nationalitaet == 0) kunde.Nationalitaet = 192;
            using (var db = new DB.M120Datenbank())
            {
                db.Kunde.Add(kunde);
                db.SaveChanges();
                db.Entry(kunde).Reload();
                return kunde.KundeID;
            }
        }
        /// <summary>
        /// Methode: Bestehenden Kunde aktualisieren
        /// </summary>
        /// <param name="kunde"></param>
        public static void Aktualisieren(DB.Kunde kunde)
        {
            using (var db = new DB.M120Datenbank())
            {
                db.Entry(kunde).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Methode: Löschen eines Kunden
        /// </summary>
        /// <param name="kunde"></param>
        public static void Loeschen(DB.Kunde kunde)
        {
            using (var db = new DB.M120Datenbank())
            {
                db.Entry(kunde).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
    }
}
