using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M120Projekt
{
    static class APIDemo
    {
        #region KlasseA
        // Create
        public static void DemoACreate()
        {
            Debug.Print("--- DemoACreate ---");
            // KlasseA
            Data.KlasseA klasseA1 = new Data.KlasseA();
            klasseA1.TextAttribut = "Artikel 1";
            klasseA1.DatumAttribut = DateTime.Today;
            Int64 klasseA1Id = klasseA1.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA1Id);
        }
        public static void DemoACreateKurz()
        {
            Data.KlasseA klasseA2 = new Data.KlasseA { TextAttribut = "Artikel 2", BooleanAttribut = true, DatumAttribut = DateTime.Today };
            Int64 klasseA2Id = klasseA2.Erstellen();
            Debug.Print("Artikel erstellt mit Id:" + klasseA2Id);
        }

        // Read
        public static void DemoARead()
        {
            Debug.Print("--- DemoARead ---");
            // Demo liest alle
            foreach (Data.KlasseA klasseA in Data.KlasseA.LesenAlle())
            {
                Debug.Print("Artikel Id:" + klasseA.KlasseAId + " Name:" + klasseA.TextAttribut);
            }
        }
        // Update
        public static void DemoAUpdate()
        {
            Debug.Print("--- DemoAUpdate ---");
            // KlasseA ändert Attribute
            Data.KlasseA klasseA1 = Data.KlasseA.LesenID(1);
            klasseA1.TextAttribut = "Artikel 1 nach Update";
            klasseA1.Aktualisieren();
        }
        // Delete
        public static void DemoADelete()
        {
            Debug.Print("--- DemoADelete ---");
            Data.KlasseA.LesenID(1).Loeschen();
            Debug.Print("Artikel mit Id 1 gelöscht");
        }
        #endregion
    }
}
