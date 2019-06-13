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

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Komponent_Uebersicht.xaml
    /// </summary>
    public partial class Komponent_Uebersicht : UserControl
    {

        private List<Data.Komponent> komponenten = new List<Data.Komponent>();
        private List<Data.Komponent> gefilterteKomponenten;
        public Komponent_Uebersicht()
        {
            foreach (Data.Komponent k in Data.Komponent.LesenAlle())
            {
                this.komponenten.Add(k);

            }
            gefilterteKomponenten = komponenten;
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KomponentenVerwaltung.Instance.wechselUC(this, 0,new Komponent_Neu());
        }

        private void dataGrid_Loaded(object sender, RoutedEventArgs e)
        {
            
            var grid = sender as DataGrid;
            grid.ItemsSource = komponenten;
            
        }
        private void Zeile_DoppelKlick(object sender, MouseButtonEventArgs e)
        {
            DataGridRow dataGridRow = sender as DataGridRow;
            if (dataGridRow.Item is Data.Komponent)
            {
                Data.Komponent k = dataGridRow.Item as Data.Komponent;
                KomponentenVerwaltung.Instance.wechselUC(this, 0,new Komponent_Detail(k.Id));
            }            
        }

        private void suche_TextChanged(object sender, TextChangedEventArgs e)
        {
            //filtern();
        }

        private void filtern()
        {
            if (suche.Text == "") gefilterteKomponenten = komponenten;
            foreach(Data.Komponent k in this.komponenten)
            {
                if (k.Name.Contains(suche.Text))
                {
                    this.gefilterteKomponenten.Clear();
                    this.gefilterteKomponenten.Add(k);
                }
            }
        }
    }
}
