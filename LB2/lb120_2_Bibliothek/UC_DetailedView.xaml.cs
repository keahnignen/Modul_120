using lb120_2_Bibliothek.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace lb120_2_Bibliothek
{
    /// <summary>
    /// Interaktionslogik für UC_DetailedView.xaml
    /// </summary>
    public partial class UC_DetailedView : UserControl
    {

        private bool IsNew;

        private readonly Buch _buch = null;
        private readonly Ausleihe _ausleihe = null;
        private readonly ScrollViewer _scrollViewer = null;

        private UC_DetailedView(ScrollViewer sv)
        {
            InitializeComponent();
            _scrollViewer = sv;
        }

        public UC_DetailedView(ScrollViewer sv, Ausleihe ausleihe) : this(sv)
        {
            _ausleihe = ausleihe;
            _buch = ausleihe.Buch;
            Edit();
        }

        public UC_DetailedView(ScrollViewer sv, Buch buch) : this(sv)
        {
            _buch = buch;
            _ausleihe = new Ausleihe();
            New();
        }

        public void New()
        {
            lblTitle.Content = "Neue ausleihe erstellen";
            IsNew = true;
            SetBook();
            chkIsAvailable.IsEnabled = false;
            dtpStart.IsEnabled = true;
            SetDateTime(DateTime.Now, DateTime.Now.Date.Add(new TimeSpan(14, 0, 0, 0)));



            var kunden = APP.Kunde.Lesen_Alle();
            cbxKunde.ItemsSource = kunden;
            var x = kunden.FirstOrDefault();
            
            cbxKunde.DisplayMemberPath = nameof(x.Name);
            
            
        }

        public void SetBook()
        {
            var buch = new List<Buch>();
            buch.Add(_buch);
            cbxBuch.ItemsSource = buch;
            cbxBuch.DisplayMemberPath = nameof(_buch.Titel);
            cbxBuch.SelectedIndex = 0;
        }


        public void Edit()
        {
            lblTitle.Content = "Ausleihe bearbeiten";
            IsNew = false;
            SetBook();
            dtpStart.IsEnabled = false;
            chkIsAvailable.IsChecked = _ausleihe.IstZurueck;
            SetDateTime(_ausleihe.Start, _ausleihe.Ende);



            cbxKunde.IsEnabled = false;



            var kunden = new List<Kunde>();
            kunden.Add(_ausleihe.Kunde);

            cbxKunde.ItemsSource = kunden;
            //cbxKunde.SelectedItem = _ausleihe.Kunde;
            
            cbxKunde.DisplayMemberPath = nameof(_ausleihe.Kunde.Name);
            cbxKunde.SelectedIndex = 0;


        }

        private void SetDateTime(DateTime startDate, DateTime endDate)
        {
            dtpStart.Text = startDate.ToString("D");
            dtpEnd.Text = endDate.ToString("D");
        }


        private bool IsDateNotValid()
        {
            var x = ((DateTime)dtpEnd.SelectedDate).CompareTo((DateTime)dtpStart.SelectedDate) < 0;

            if (x)
            {
                MessageBox.Show("Start Datum ist älter als dass End Datum");
            }

            return x;
        }


        private bool SelectedUser()
        {
            var i = (cbxKunde.SelectedIndex != -1);
            if (!i)
            {
                MessageBox.Show("Kein Benutzer gewält");
            }

            return i;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (IsDateNotValid()) return;
            if (!SelectedUser()) return;
            Save();

        }

        private void Save()
        {
            _ausleihe.Start = (DateTime) dtpStart.SelectedDate;
            _ausleihe.Ende = (DateTime) dtpEnd.SelectedDate;
            _ausleihe.IstZurueck = (bool) chkIsAvailable.IsChecked;
            _ausleihe.Buch = _buch;
            _ausleihe.Kunde = (Kunde)cbxKunde.SelectedItem;

            if (IsNew)
            {
                APP.Ausleihe.Erstellen(_ausleihe);
            }
            else
            {
                APP.Ausleihe.Aktualisieren(_ausleihe);
            }

            _scrollViewer.Content = new UC_Ausleihe(_scrollViewer);
        }

        private void CalendarClosed(object sender, RoutedEventArgs e)
        {
            IsDateNotValid();
        }
    }
}
