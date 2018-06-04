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
    public partial class UC_Buch : UserControl
    {
        private ScrollViewer _scrollViewer;
        public UC_Buch(ScrollViewer scrollViewer)
        {
            this._scrollViewer = scrollViewer;
            InitializeComponent();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            dataGrid.AutoGenerateColumns = false;


            var list = new List<Ausleihe>();

            foreach (var buch in APP.Buch.Lesen_Alle())
            {
                var ausleihen =  APP.Ausleihe.Lesen_BuchId(buch.BuchId);

                if (ausleihen.Count == 0)
                {
                    var ausliehe = new Ausleihe();
                    ausliehe.Buch = buch;
                    ausliehe.IstZurueck = true;
                    list.Add(ausliehe);
                }
                else
                {
                    var ausleihe = ausleihen.First();
                    ausleihe.Buch = buch;
                    list.Add(ausleihe);
                }
            }

            dataGrid.ItemsSource = list;


            dataGrid.IsReadOnly = true;
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeToDetailView();
        }

        private void ChangeToDetailView()
        {
            if (dataGrid.SelectedIndex == -1) return;
           
            var selectedItem = (Ausleihe)dataGrid.SelectedItem;

            _scrollViewer.Content = selectedItem.IstZurueck ? new UC_DetailedView(_scrollViewer, selectedItem.Buch) : new UC_DetailedView(_scrollViewer, selectedItem);

  
        }
    }
}
