using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lb120_2_Bibliothek
{
    /// <summary>
    /// Interaktionslogik für UC_newBook.xaml
    /// </summary>
    public partial class UC_newBook : UserControl
    {
        private DB.Kunde kunde;
        private ScrollViewer parentControl;

        enum Zustand
        {
            Leer,
            Anzeige,
            Neu,
            Veraendert,
            Ungespeichert
        }
        enum Uebergang
        {
            Abbrechen,
            Suchen,
            Erstellen,
            Loeschen,
            Eingabe,
            Speichern
        }
        private Boolean eingabeIgnorieren;
        private Zustand aktuellerZustand;
        public UC_newBook(long kundeID, ScrollViewer parent)
        {
            InitializeComponent();
            //Ansicht zum bearbeiten
            AktuellerZustand = Zustand.Leer;
            // AB06 A1
            tbName.Text = APP.Kunde.Lesen_ID(kundeID).Name;
            tbTitel.Text = APP.Buch.Lesen_ID(kundeID).Titel;
            //DatePicker Start werte abfüllen 
            var swag = APP.Ausleihe.Lesen_ID(kundeID).Start;
            tbStart.DisplayDate = swag;
            tbStart.Text = swag.ToString();
            //DatePicker Ende werte abfüllen 
            var swag2 = APP.Ausleihe.Lesen_ID(kundeID).Ende;
            tbEnde.DisplayDate = swag2;
            tbEnde.Text = swag2.ToString();
            //Bemerkung Werte abfüllen
            tbBemerkung.Text = APP.Ausleihe.Lesen_ID(kundeID).Bemerkungen;

            //z>urueck.IsChecked = APP.Buch.Lesen_Alle(kundeID);
            // AB06 A2
            sucheNr.Text = kundeID.ToString();
            //Will nicht anzeigen
            //tbName.Text = kundeID.ToString();

            macheUebergang(Uebergang.Suchen);
            parentControl = parent;
        }

        private void neu_Click(object sender, RoutedEventArgs e)
        {
            
                // DB
                kunde = new DB.Kunde();
            // GUI
            macheUebergang(Uebergang.Erstellen);

        }
        private Zustand AktuellerZustand
        {
            get { return aktuellerZustand; }
            // Knöpfe ein/ausschalten je nach Zustand
            set
            {
                if (value == Zustand.Leer)
                {
                    DeaktiviereSteuerelemente();
                    sucheNr.IsEnabled = true;
                    suchen.IsEnabled = true;
                    neu.IsEnabled = true;
                    aktuellerZustand = value;
                    // GUI
                    LeereFelder();
                    //TODO: KIFI KIFI
                    EinzelansichtGrid.IsEnabled = true;
                }
                else if (value == Zustand.Anzeige)
                {
                    DeaktiviereSteuerelemente();
                    abbrechen.IsEnabled = true;
                    neu.IsEnabled = true;
                    loeschen.IsEnabled = true;
                    aktuellerZustand = value;
                    // Felder abfüllen
                    eingabeIgnorieren = true;
                    LeereFelder();
                    EinzelansichtGrid.IsEnabled = true;
                   
                    tbName.Text = kunde.Name;
                    
                    // AB06 A1 ENDE
                    // AB06 A3 START
                   
                    // AB06 A3 ENDE
                    eingabeIgnorieren = false;
                }
                else if (value == Zustand.Veraendert)
                {
                    DeaktiviereSteuerelemente();
                    abbrechen.IsEnabled = true;
                    speichern.IsEnabled = true;
                    aktuellerZustand = value;
                }
                else if (value == Zustand.Neu)
                {
                    DeaktiviereSteuerelemente();
                    EinzelansichtGrid.IsEnabled = true;
                    abbrechen.IsEnabled = true;
                    aktuellerZustand = value;
                }
                else if (value == Zustand.Ungespeichert)
                {
                    DeaktiviereSteuerelemente();
                    abbrechen.IsEnabled = true;
                    speichern.IsEnabled = true;
                    aktuellerZustand = value;
                }
            }
        }

















        private void macheUebergang(Uebergang uebergang)
        {
            if (uebergang == Uebergang.Abbrechen)
            {
                if (aktuellerZustand == Zustand.Veraendert || aktuellerZustand == Zustand.Ungespeichert)
                {
                    if (MessageBox.Show("Änderungen gehen verloren, wirklich abbrechen?", "Achtung!", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                    {
                        Abbrechen();
                    }
                }
                else
                {
                    Abbrechen();
                }
            }
            else if (uebergang == Uebergang.Erstellen)
            {
                Erstellen();
            }
            else if (uebergang == Uebergang.Loeschen)
            {
                if (MessageBox.Show("Wirklich löschen?", "Achtung", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxResult.No) == MessageBoxResult.Yes)
                {
                    AblaufLoeschen();
                }
            }
            else if (uebergang == Uebergang.Suchen)
            {
                
            }
            else if (uebergang == Uebergang.Eingabe)
            {
                AblaufEingabe();
            }
            else if (uebergang == Uebergang.Speichern)
            {
                AblaufSpeichern();
            }
        }
        #region "Schnittstelle zu Applikationsschicht"
        private void Abbrechen()
        {
            // DB
            kunde = null;
            // GUI
            AktuellerZustand = Zustand.Leer;
            // AB06 A2
            //parentControl.Content = new UC_newBook(parentControl);
        }
        private void Erstellen()
        {
            // DB
            kunde = new DB.Kunde();
            // GUI
            LeereFelder();
            AktuellerZustand = Zustand.Neu;
        }
        private void AblaufLoeschen()
        {
            // DB
            APP.Kunde.Aktualisieren(kunde);
            // GUI
            AktuellerZustand = Zustand.Leer;
            // AB06 A2
            //parentControl.Content = new UC_Listenansicht_Kunde(parentControl);

        }
        
        private void AblaufSpeichern()
        {
            kunde.Name = tbName.Text;
            // AB06 A1 ENDE
            // DB
            if (aktuellerZustand == Zustand.Ungespeichert)
            {
                // Neu hinzufügen
                APP.Kunde.Erstellen(kunde);
            }
            else if (aktuellerZustand == Zustand.Veraendert)
            {
                // Aenderungen speichern
                APP.Kunde.Aktualisieren(kunde);
            }
            // GUI
            AktuellerZustand = Zustand.Anzeige;

        }
        private void AblaufEingabe()
        {
            // DB (leer)
            // GUI
            if (AktuellerZustand == Zustand.Anzeige || AktuellerZustand == Zustand.Veraendert)
            {
                AktuellerZustand = Zustand.Veraendert;
            }
            else if (AktuellerZustand == Zustand.Neu)
            {
                AktuellerZustand = Zustand.Ungespeichert;
            }
        }
        #endregion
        #region "GUI Ereignisse"
        private void suchen_Click(object sender, RoutedEventArgs e)
        {
            macheUebergang(Uebergang.Suchen);
        }
        private void sucheNr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                macheUebergang(Uebergang.Suchen);
            }
        }
        private void speichern_Click(object sender, RoutedEventArgs e)
        {
            macheUebergang(Uebergang.Speichern);
        }
        private void eingabe(object sender, TextChangedEventArgs e)
        {
            if (!eingabeIgnorieren)
            {
                macheUebergang(Uebergang.Eingabe);
            }
        }
        private void anredeFrau_Checked(object sender, RoutedEventArgs e)
        {
            if (!eingabeIgnorieren)
            {
                macheUebergang(Uebergang.Eingabe);
            }
        }
        private void anredeHerr_Checked(object sender, RoutedEventArgs e)
        {
            if (!eingabeIgnorieren)
            {
                macheUebergang(Uebergang.Eingabe);
            }
        }
        private void anredeFamilie_Checked(object sender, RoutedEventArgs e)
        {
            if (!eingabeIgnorieren)
            {
                macheUebergang(Uebergang.Eingabe);
            }
        }
        /*
        private void neu_Click(object sender, RoutedEventArgs e)
        {
            macheUebergang(Uebergang.Erstellen);
        }
        */
        private void loeschen_Click(object sender, RoutedEventArgs e)
        {
            macheUebergang(Uebergang.Loeschen);
        }
        private void abbrechen_Click(object sender, RoutedEventArgs e)
        {
            macheUebergang(Uebergang.Abbrechen);
        }
        //AB06 A1
        
        #endregion
        #region "GUI Hilfsfunktionen"
        private void DeaktiviereSteuerelemente()
        {
            suchen.IsEnabled = false;
            sucheNr.IsEnabled = false;
            speichern.IsEnabled = false;
            neu.IsEnabled = false;
            loeschen.IsEnabled = false;
            abbrechen.IsEnabled = false;
        }
        private void LeereFelder()
        {
            tbName.Text = "";
            
        }
        #endregion

        // AB06 A1
    }
}
