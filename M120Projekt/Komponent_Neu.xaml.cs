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
    /// Interaktionslogik für Komponent_Neu.xaml
    /// </summary>
    public partial class Komponent_Neu : UserControl
    {
        
        public Komponent_Neu()
        {
            InitializeComponent();
        }

        private void aktivereSpeichern()
        {
            if (nameNeu != null && beschreibungNeu != null && kategorieNeu != null && preisNeu != null)
            {
                List<String> fehler = Validator.validiere(new String[] { nameNeu.Text, beschreibungNeu.Text, kategorieNeu.Text, preisNeu.Text });
                speichern.IsEnabled = fehler.Count == 0;
                setFehlermeldungen(fehler);
            }
        }

        private void setFehlermeldungen(List<String> fehler)
        {
           
            KomponentenVerwaltung.Instance.setzteFeedback(fehler, false);
            
        }

        private void nameNeu_TextChanged(object sender, TextChangedEventArgs e)
        {
            aktivereSpeichern();
        }

        private void beschreibungNeu_TextChanged(object sender, TextChangedEventArgs e)
        {
            aktivereSpeichern();
        }

        private void kategorieNeu_TextChanged(object sender, TextChangedEventArgs e)
        {
            aktivereSpeichern();
        }

        private void preisNeu_TextChanged(object sender, TextChangedEventArgs e)
        {
            aktivereSpeichern();
        }

        private void speichern_Click(object sender, RoutedEventArgs e)
        {
            long id = abspeichern();
            KomponentenVerwaltung.Instance.wechselUC(this, 0, new Komponent_Detail(id));
            KomponentenVerwaltung.Instance.setzteFeedback("Komponent erstellt.", true);
        }

        private long abspeichern()
        {
            Data.Komponent k = new Data.Komponent();
            k.Name = nameNeu.Text;
            k.Beschreibung = beschreibungNeu.Text;
            k.Kategorie = kategorieNeu.Text;
            k.Registriert_am = DateTime.Today;
            k.Preis = Convert.ToDouble(preisNeu.Text);

            return k.Erstellen();
        }

        private void zurueck_Click(object sender, RoutedEventArgs e)
        {
            KomponentenVerwaltung.Instance.zurueck();
        }
        private void ganzZuruck_Click(object sender, RoutedEventArgs e)
        {
            KomponentenVerwaltung.Instance.ganzZurueck();
        }
    }
}
