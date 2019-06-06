using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaktionslogik für KomponentenVerwaltung.xaml
    /// </summary>
    public partial class KomponentenVerwaltung : Window
    {
        private List<Tuple<Seiten, long>> verlauf = new List<Tuple<Seiten, long>>();
        public static KomponentenVerwaltung Instance { get; private set; }
        public KomponentenVerwaltung()
        {
           
            Data.Global.context = new Data.Context();
            InitializeComponent();
            container.Content = new Komponent_Uebersicht();
            Instance = this;
        }

        private void leeren()
        {
            container.Content = null;
        }

        public void wechsleNachLoeschung()
        {
            leeren();
            container.Content = new Komponent_Uebersicht();
        }

        public void wechselUC(UserControl aktuell, long id, UserControl uc)
        {
            verlaufErgaenzen(aktuell, id);
            leeren();
            container.Content = uc;

            rueckmeldung.Content = "";
        }
        public void zurueck()
        {
            leeren();
            if(verlauf[verlauf.Count-1].Item1 == Seiten.Uebersicht)
            {
                container.Content = new Komponent_Uebersicht();
            }
            if (verlauf[verlauf.Count - 1].Item1 == Seiten.Neu)
            {
                container.Content = new Komponent_Neu();
            }
            if (verlauf[verlauf.Count - 1].Item1 == Seiten.Detail)
            {
                container.Content = new Komponent_Detail(verlauf[verlauf.Count-1].Item2);
            }
            if (verlauf[verlauf.Count - 1].Item1 == Seiten.Bearbeiten)
            {
                container.Content = new Komponent_Bearbeiten(verlauf[verlauf.Count - 1].Item2);
            }
            
            verlauf.RemoveAt(verlauf.Count - 1);
            rueckmeldung.Content = "";

        }

        public void ganzZurueck()
        {
            verlauf.Clear();
            leeren();
            container.Content = new Komponent_Uebersicht();
        }

        private void verlaufErgaenzen(UserControl uc, long id)
        {
           
            if (uc.GetType() == typeof(Komponent_Uebersicht))
            {
                verlauf.Add( new Tuple<Seiten, long>(Seiten.Uebersicht, id));
            }
            else if(uc.GetType() == typeof(Komponent_Neu))
            {
                verlauf.Add(new Tuple<Seiten, long>(Seiten.Neu, id));
            }
            else if(uc.GetType() == typeof(Komponent_Detail))
            {
                verlauf.Add(new Tuple<Seiten, long>(Seiten.Detail, id));
            }
            else if(uc.GetType() == typeof(Komponent_Bearbeiten))
            {
                verlauf.Add(new Tuple<Seiten, long>(Seiten.Bearbeiten, id));
            }
        }

        public void setzteFeedback(String s, bool erfolg)
        {
            if (rueckmeldung != null)
            {
                rueckmeldung.Foreground = (erfolg) ? new SolidColorBrush(Colors.Green) : new SolidColorBrush(Colors.Red);
                rueckmeldung.Content = s;
            }
        }
        public void setzteFeedback(List<String> fehler, bool erfolg)
        {
            String meldung = "";
            foreach (String s in fehler)
            {
                meldung += s + ", ";
            }

            setzteFeedback(meldung, erfolg);
        }

    }
}
