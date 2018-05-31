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
using lb120_2_Bibliothek.DB;

namespace lb120_2_Bibliothek
{
    /// <summary>
    /// Interaktionslogik für UC_Ausleihe.xaml
    /// </summary>
    public partial class UC_Ausleihe : UserControl
    {
        public UC_Ausleihe()
        {
            InitializeComponent();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource =  APP.Ausleihe.Lesen_Alle();
        }
    }
}
