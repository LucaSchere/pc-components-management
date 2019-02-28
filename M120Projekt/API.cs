using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class API
    {
        #region KlasseA
        // Create
        public static void KomponentErstellen()
        {
            Debug.Print("--- Erstellen ---");
            // KlasseA
            Data.Komponent Komponent = new Data.Komponent();
            Komponent.Name = "Artikel 1";
            Komponent.Beschreibung = "BlaBla";
            Komponent.Kategorie = "Bla";
            Komponent.Registriert_am = DateTime.Today;
            Komponent.Preis = 222.2;

            Int64 KomponentID = Komponent.Erstellen();
            Debug.Print("Komponent erstellt mit Id:" + KomponentID);
        }
        public static void KomponentErstellenKurz()
        {
            Data.Komponent Komponent = new Data.Komponent { Name = "Artikel 2", Beschreibung = "BlaBla", Kategorie = "Bla", Registriert_am = DateTime.Today, Preis = 222.2};
            Int64 KomponentId = Komponent.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + KomponentId);
        }

        // Read test
        public static void KomponentLesen()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.Komponent klasseA in Data.Komponent.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.Id + " Name:" + klasseA.Name);
            }
        }
        // Update
        public static void KomponentAktualisieren()
        {
            Debug.Print("--- Aktualisieren ---");
            Data.Komponent klasseA1 = Data.Komponent.LesenID(15);
            if(klasseA1 != null)
            {
                klasseA1.Name = "Artikel 1 nach Update";
                klasseA1.Aktualisieren();
            }
            
        }
        // Delete
        public static void KomponentLoeschen()
        {
            Debug.Print("--- Löschen ---");
            Data.Komponent.LesenID(16).Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht");
        }
        #endregion
    }
}
