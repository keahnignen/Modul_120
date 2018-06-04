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
        private ScrollViewer _scrollViewer;
        public UC_Ausleihe(ScrollViewer scrollViewer)
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
            dataGrid.ItemsSource = APP.Ausleihe.Lesen_Alle();
            dataGrid.IsReadOnly = true;
        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ChangeToDetailView();
        }

        private void ChangeToDetailView()
        {
            if (dataGrid.SelectedIndex == -1) return;
            _scrollViewer.Content = new UC_DetailedView(_scrollViewer, (Ausleihe)dataGrid.SelectedItem);
        }
    }
}
