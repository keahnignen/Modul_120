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
    /// Interaktionslogik für UC_ueberfaellig.xaml
    /// </summary>
    public partial class UC_ueberfaellig : UserControl
    {
        private ScrollViewer parentControl;
        public UC_ueberfaellig(ScrollViewer parent)
        {
            InitializeComponent();
            parentControl = parent;
            auswahlKunde.ItemsSource = APP.Buch.Lesen_Alle();
            /*
            if(auswahlKunde.ItemsSource.Verfuegbarkeit == "TRUE")
            {
                
            }
            */
        }
        private void auswahlKunde_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (auswahlKunde.SelectedItem != null)
            {
                DB.Buch auswahl = (DB.Buch)auswahlKunde.SelectedItem;
                UC_newBook einzelKunde = new UC_newBook(auswahl.KundeID, parentControl);
                parentControl.Content = einzelKunde;
            }

        }

        private void auswahlKunde_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
