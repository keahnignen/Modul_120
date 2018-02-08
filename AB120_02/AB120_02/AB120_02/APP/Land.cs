using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB120_02.APP
{
    /// <summary>
    /// Applikationsschicht: CRUD Klasse für Land
    /// </summary>
    static class Land
    {
        /// <summary>
        /// Methode: Liste von allen Ländern lesen
        /// </summary>
        /// <returns></returns>
        public static List<DB.Land> Lesen_Alle()
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Land select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: ein Land lesen anhand Primärschlüssel
        /// </summary>
        /// <param name="landID"></param>
        /// <returns></returns>
        public static DB.Land Lesen_LandID(Int64 landID)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Land where rec.LandID == landID select rec).FirstOrDefault();
            }
        }
        /// <summary>
        /// Methode: Liste von Ländern lesen anhand exaktem Match auf Name
        /// </summary>
        /// <param name="landName"></param>
        /// <returns></returns>
        public static List<DB.Land> Lesen_Name(string landName)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Land where rec.Name == landName select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Liste von Laendern lesen anhand Teilmatch auf Name
        /// </summary>
        /// <param name="landName"></param>
        /// <returns></returns>
        public static List<DB.Land> Lesen_NameWie(string landName)
        {
            using (var db = new DB.M120Datenbank())
            {
                return (from rec in db.Land where rec.Name.Contains(landName) select rec).ToList();
            }
        }
        /// <summary>
        /// Methode: Neues Land erstellen
        /// </summary>
        /// <param name="land"></param>
        /// <returns></returns>
        public static Int64 Erstellen(DB.Land land)
        {
            if (land.Name == null) land.Name = "";
            if (land.Kurzname == null) land.Kurzname = "";
            using (var db = new DB.M120Datenbank())
            {
                db.Land.Add(land);
                db.SaveChanges();
                db.Entry(land).Reload();
                return land.LandID;
            }
        }
        /// <summary>
        /// Methode: Bestehendes Land aktualisieren
        /// </summary>
        /// <param name="land"></param>
        public static void Aktualisieren(DB.Land land)
        {
            using (var db = new DB.M120Datenbank())
            {
                db.Entry(land).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }
        /// <summary>
        /// Methode: Löschen eines Landes
        /// </summary>
        /// <param name="land"></param>
        private static void Loeschen(DB.Kunde land)
        {
            using (var db = new DB.M120Datenbank())
            {
                db.Entry(land).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }
        #region "Bild Hilfsprogramme"
        public static byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }
        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
        #endregion
    }
}
