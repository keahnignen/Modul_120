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
    /// Interaktionslogik für UC_auslehnen.xaml
    /// </summary>
    public partial class UC_auslehnen : UserControl
    {
        private ScrollViewer parentControl;
        public UC_auslehnen(ScrollViewer parent)
        {
            InitializeComponent();
            parentControl = parent;

            //var newlist = APP.Ausleihe.Lesen_Alle();
            //foreach (var ausleihe in APP.Ausleihe.Lesen_Alle())
            //{

            // }
            //auswahlKunde.ItemsSource = DB.AusleiheDarstellung.toAusleiheDarstellung(APP.Ausleihe.Lesen_Alle().ToArray());
            auswahlKunde.ItemsSource = APP.Ausleihe.Lesen_Alle();


        }

        private void auswahlKunde_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (auswahlKunde.SelectedItem != null)
            {
                DB.Ausleihe auswahl = (DB.Ausleihe)auswahlKunde.SelectedItem;
                UC_newBook einzelKunde = new UC_newBook(auswahl.AusleiheId, parentControl);
                parentControl.Content = einzelKunde;
            }

        }
    }
}
