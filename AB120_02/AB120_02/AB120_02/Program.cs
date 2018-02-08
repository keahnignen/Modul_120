using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB120_02
{
    class Program
    {
        static void Main(string[] args)
        {
            HauptmenuKunde();
        }
        static void HauptmenuKunde()
        {
            Console.Clear();
            Console.WriteLine("=== HAUPTMENU KUNDEN ===");
            Console.WriteLine("1) Alle Kunden anzeigen");
            Console.WriteLine("2) Kunde anzeigen (Suche nach KundeID)");
            Console.WriteLine("3) Kunden anzeigen (Suche nach Name,exakt)");
            Console.WriteLine("4) Kunden anzeigen (Suche nach Name,enthält)");
            Console.WriteLine("5) Kunde neu erstellen");
            Console.WriteLine("6) Kunde aktualisieren");
            Console.WriteLine("7) Kunde löschen");
            Console.WriteLine("9) Programm beenden");
            Console.WriteLine("=== Bitte auswählen ==>");
            string auswahl = Console.ReadLine();
            switch(auswahl)
            {
                case "1":
                    AusgabeListeAlleKunden();
                    break;
                case "2":
                    AusgabeEinKundeNachID();
                    break;
                case "3":
                    AusgabeListeKundenNachName();
                    break;
                case "4":
                    AusgabeListeKundenWieName();
                    break;
                case "5":
                    ErstelleKunde();
                    break;
                case "6":
                    AktualisiereKunde();
                    break;
                case "7":
                    LoeschenKunde();
                    break;
                case "9":
                    System.Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Ungültiger Befehl");
                    break;
            }
            Console.WriteLine("Ausführung beendet weiter mit <ENTER>");
            Console.ReadLine();
            HauptmenuKunde();
        }
        static void AusgabeEinKundeNachID()
        {
            Console.WriteLine("--- Kunde ausgeben (Suche nach ID) ---");
            Console.WriteLine("Bitte ID des Kunden eingeben:");
            Int64 id = Convert.ToInt64(Console.ReadLine());
            try
            {
                Console.WriteLine(APP.Kunde.Lesen_KundeID(id).Name);
            } catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Auslesen:" + ex.Message);
            }
        }
        static void AusgabeListeAlleKunden()
        {
            Console.WriteLine("--- Alle Kunden ausgeben ---");
            try
            {
                foreach (DB.Kunde kunde in APP.Kunde.Lesen_Alle())
                {
                    Console.WriteLine("KundeID:" + kunde.KundeID + " / Name:" + kunde.Name + " / Vorname:" + kunde.Vorname + " / Ort:" + kunde.Ort);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Auslesen:" + ex.Message);
            }
        }
        static void AusgabeListeKundenNachName()
        {
            Console.WriteLine("--- Kunden ausgeben (Suche nach Name) ---");
            Console.WriteLine("Bitte Name des Kunden eingeben:");
            string name = Console.ReadLine();
            try
            {
                foreach (DB.Kunde kunde in APP.Kunde.Lesen_Name(name))
                {
                    Console.WriteLine("KundeID:" + kunde.KundeID + " / Name:" + kunde.Name + " / Vorname:" + kunde.Vorname + " / Ort:" + kunde.Ort);
                }
            } catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Auslesen:" + ex.Message);
            }
        }
        static void AusgabeListeKundenWieName()
        {
            Console.WriteLine("--- Kunden ausgeben (Suche nach Name) ---");
            Console.WriteLine("Bitte Name des Kunden eingeben:");
            string name = Console.ReadLine();
            try
            {
                foreach (DB.Kunde kunde in APP.Kunde.Lesen_NameWie(name))
                {
                    Console.WriteLine("KundeID:" + kunde.KundeID + " / Name:" + kunde.Name + " / Vorname:" + kunde.Vorname + " / Ort:" + kunde.Ort);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Auslesen:" + ex.Message);
            }
        }
        static void ErstelleKunde()
        {
            Console.WriteLine("--- Kunde erstellen ---");
            DB.Kunde neuerKunde = new DB.Kunde();
            Console.WriteLine("Neuer Kunde 'Name':");
            neuerKunde.Name = Console.ReadLine();
            Console.WriteLine("Neuer Kunde 'Vorname':");
            neuerKunde.Vorname = Console.ReadLine();
            try
            {
                Console.WriteLine("Der neue Kunde hat die Nummer:" + APP.Kunde.Erstellen(neuerKunde));
            } catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Speichern:" + ex.Message);
            }
        }
        static void AktualisiereKunde()
        {
            Console.WriteLine("--- Kunde aktualisieren ---");
            Console.WriteLine("Bitte Kundennummer angeben:");
            Int64 id = Convert.ToInt64(Console.ReadLine());
            try
            {
                DB.Kunde kunde = APP.Kunde.Lesen_KundeID(id);
                Console.WriteLine("Kunde gefunden: " + kunde.Name);
                Console.WriteLine("Bitte neuen Namen eingeben:");
                kunde.Name = Console.ReadLine();
                APP.Kunde.Aktualisieren(kunde);
                // TEST
                kunde = APP.Kunde.Lesen_KundeID(id);
                Console.WriteLine("Neuer Name: " + kunde.Name);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Aktualisieren:" + ex.Message);
            }

        }
        static void LoeschenKunde()
        {
            Console.WriteLine("--- Kunde löschen ---");
            Console.WriteLine("Bitte Kundennummer angeben:");
            Int64 id = Convert.ToInt64(Console.ReadLine());
            try
            {
                DB.Kunde kunde = APP.Kunde.Lesen_KundeID(id);
                Console.WriteLine("Kunde gefunden: " + kunde.Name);
                APP.Kunde.Loeschen(kunde);
                // TEST
                if (APP.Kunde.Lesen_KundeID(id) == null)
                {
                    Console.WriteLine("Löschen erfolgreich");
                } else
                {
                    Console.WriteLine("Löschen NICHT erfolgreich");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Fehler beim Löschen:" + ex.Message);
            }
        }
    }
}
