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
    /// Interaktionslogik für Komponent_Bearbeiten.xaml
    /// </summary>
    public partial class Komponent_Bearbeiten : UserControl
    {

        private Data.Komponent k;

        public Komponent_Bearbeiten(long id)
        {
            InitializeComponent();
            this.k = Data.Komponent.LesenID(id);
            setWerte(this.k);
        }

        private void setWerte(Data.Komponent k)
        {
            titel.Content = k.Name;

            idEdit.Text = Convert.ToString(k.Id);
            nameEdit.Text = k.Name;
            beschreibungEdit.Text = k.Beschreibung;
            kategorieEdit.Text = k.Kategorie;
            preisEdit.Text = Convert.ToString(k.Preis);
        }

        private void aktivereEditieren()
        {
            if (nameEdit != null && beschreibungEdit != null && kategorieEdit != null && preisEdit != null)
            {
                List<String> fehler = Validator.validiere(new String[] { nameEdit.Text, beschreibungEdit.Text, kategorieEdit.Text, preisEdit.Text });
                editieren.IsEnabled = fehler.Count == 0;
                setFehlermeldungen(fehler);
            }
        }

        private void setFehlermeldungen(List<String> fehler)
        {
            KomponentenVerwaltung.Instance.setzteFeedback(fehler, false);
        }

        private void nameEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            aktivereEditieren();
        }

        private void beschreibungEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            aktivereEditieren();
        }

        private void kategorieEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            aktivereEditieren();
        }

        private void preisEdit_TextChanged(object sender, TextChangedEventArgs e)
        {
            aktivereEditieren();
        }

        private void editieren_Click(object sender, RoutedEventArgs e)
        {
            abspeichern();
        }

        private void abspeichern()
        {
            
            
            this.k.Name = nameEdit.Text;
            this.k.Beschreibung = beschreibungEdit.Text;
            this.k.Kategorie = kategorieEdit.Text;
            this.k.Registriert_am = DateTime.Today;
            this.k.Preis = Convert.ToDouble(preisEdit.Text);

            this.k.Aktualisieren();
            KomponentenVerwaltung.Instance.wechselUC(this, this.k.Id, new Komponent_Detail(this.k.Id));
            KomponentenVerwaltung.Instance.setzteFeedback("Komponent aktualisiert.", true);
        }

        private void zuruck_Click(object sender, RoutedEventArgs e)
        {
            KomponentenVerwaltung.Instance.zurueck();
        }

        private void ganzZuruck_Click(object sender, RoutedEventArgs e)
        {
            KomponentenVerwaltung.Instance.ganzZurueck();
        }
    }
}
