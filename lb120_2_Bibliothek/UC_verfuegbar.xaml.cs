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
    /// Interaktionslogik für UC_verfuegbar.xaml
    /// </summary>
    public partial class UC_verfuegbar : UserControl
    {
        private ScrollViewer parentControl;
        public UC_verfuegbar(ScrollViewer parent)
        {
            InitializeComponent();
            parentControl = parent;
            auswahlKunde.ItemsSource = APP.Kunde.Lesen_Alle();
            
        }

        private void auswahlKunde_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (auswahlKunde.SelectedItem != null)
            {
                DB.Kunde auswahl = (DB.Kunde)auswahlKunde.SelectedItem;
                UC_newBook einzelKunde = new UC_newBook(auswahl.KundeId, parentControl);
                parentControl.Content = einzelKunde;
            }

        }
    }
}
