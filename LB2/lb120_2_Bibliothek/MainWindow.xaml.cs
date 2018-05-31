using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Testdaten();
            //Check();
        }

        #region Testdaten
        private void Testdaten()
        {
            // 2 Ausleihen
            DB.Ausleihe ausleihe1 = new DB.Ausleihe { Buch = APP.Buch.Lesen_Titel("A# for beginners"), Kunde = APP.Kunde.Lesen_Name("Albert"), Start = new DateTime(2018, 5, 1), Ende = new DateTime(2018, 5, 10) };
            APP.Ausleihe.Erstellen(ausleihe1);
            DB.Ausleihe ausleihe2 = new DB.Ausleihe { Buch = APP.Buch.Lesen_Titel("B# for professionals"), Kunde = APP.Kunde.Lesen_Name("Bruno"), Start = new DateTime(2018, 4, 28), Ende = new DateTime(2018, 4, 30), IstZurueck = true };
            APP.Ausleihe.Erstellen(ausleihe2);
            DB.Ausleihe ausleihe3 = new DB.Ausleihe { Buch = APP.Buch.Lesen_Titel("C# for genius"), Kunde = APP.Kunde.Lesen_Name("Bruno"), Start = new DateTime(2018, 1, 1), Ende = new DateTime(2018, 3, 1) };
            APP.Ausleihe.Erstellen(ausleihe3);
        }
        private void Check()
        {
            Debug.Print("A# for beginners verfügbar:" + APP.Buch.Lesen_Titel("A# for beginners").Verfuegbar.ToString());
            Debug.Print("B# for professionals verfügbar:" + APP.Buch.Lesen_Titel("B# for professionals").Verfuegbar.ToString());
            Debug.Print("C# for genius verfügbar:" + APP.Buch.Lesen_Titel("C# for genius").Verfuegbar.ToString());
            foreach(DB.Ausleihe ausleihe in APP.Ausleihe.Lesen_Alle())
            {
                Debug.Print("Ausleihe:"+ ausleihe.AusleiheId + " Buch:" + ausleihe.Buch.Titel + " Überfällig:" + ausleihe.IstUeberfaellig + " Kunde:" + ausleihe.Kunde.Name);
            }
        }
        #endregion

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            placeholder.Content = new UC_Buch();
        }

        private void btn_Copy_Click(object sender, RoutedEventArgs e)
        {
            placeholder.Content = new UC_Ausleihe();
        }
    }
}
