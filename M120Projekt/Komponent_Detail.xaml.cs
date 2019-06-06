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
    /// Interaktionslogik für Komponent_Detail.xaml
    /// </summary>
    public partial class Komponent_Detail : UserControl
    {
        private Data.Komponent k;
        public Komponent_Detail(long id)
        {
            InitializeComponent();
            this.k = Data.Komponent.LesenID(id);
            setWerte(this.k);
        }

        private void setWerte(Data.Komponent k)
        {
            titel.Content = k.Name;

            idDetail.Text = Convert.ToString(k.Id);
            nameDetail.Text = k.Name;
            beschreibungDetail.Text = k.Beschreibung;
            kategorieDetail.Text = k.Kategorie;
            preisDetail.Text = Convert.ToString(k.Preis);
        }

        private void geheZuEdit_Click(object sender, RoutedEventArgs e)
        {
            KomponentenVerwaltung.Instance.wechselUC(this, this.k.Id, new Komponent_Bearbeiten(this.k.Id));
        }

        private void zurueck_Click(object sender, RoutedEventArgs e)
        {
            KomponentenVerwaltung.Instance.zurueck();
        }

        private void loeschen_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = true;
        }

        private void loeschenJa_Click(object sender, RoutedEventArgs e)
        {
            this.k.Loeschen();
            popup.IsOpen = false;
            KomponentenVerwaltung.Instance.wechsleNachLoeschung();
            KomponentenVerwaltung.Instance.setzteFeedback("Komponent gelöscht.", true);
        }

        private void loeschenNein_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void ganzZuruck_Click(object sender, RoutedEventArgs e)
        {
            KomponentenVerwaltung.Instance.ganzZurueck();
        }
    }
}
