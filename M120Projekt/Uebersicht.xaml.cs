using M120Projekt.Data;
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
using System.Windows.Shapes;

namespace M120Projekt
{
    /// <summary>
    /// Interaktionslogik für Uebersicht.xaml
    /// </summary>
    public partial class Uebersicht : Window
    {
        public Uebersicht()
        {
            Komponent k = new Komponent();
            k.Id = 1;
            k.Name = "Name";
            k.Beschreibung = "Beschreibung";
            k.Kategorie = "Kategorie";
            k.Registriert_am = new DateTime();

            k.Preis = 5.5;

       
            InitializeComponent();
            List<Komponent> list = new List<Komponent>()
            {
                k
            };
            this.dataGrid.ItemsSource = list;
        }

    }
}
