using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace M120Projekt
{
    public static class Validator
    {

        public static String stringRegexName = @"^.{1,64}$";
        public static String stringRegexBeschreibung = @"^(.|[\n]){1,256}$";
        public static String stringRegexKategorie = @"^[\S]{1,64}$";

        public static String fehlerName = "Ungültiger Name";
        public static String fehlerBeschreibung = "Ungültige Beschreibung";
        public static String fehlerKategorie = "Ungültige Kategorie";
        public static String fehlerPreisDouble = "Ungültiger Preis (Keine Zahl)";
        public static String fehlerPreisPositiv = "Ungültiger Preis (Negativer Preis)";

        public static String fehlerParameter = "Ungültige Anzahl Parameter";



        public static Regex regexName = new Regex(stringRegexName);
        public static Regex regexBeschreibung = new Regex(stringRegexBeschreibung);
        public static Regex regexKategorie = new Regex(stringRegexKategorie);

        public static List<String> validiere(String[] werte)
        {
            List<String> fehler = new List<String>();

            if (werte.Length == 4)
            {
                Match matchName = regexName.Match(werte[0]);
                Match matchBeschreibung = regexBeschreibung.Match(werte[1]);
                Match matchKategorie = regexKategorie.Match(werte[2]);

                double preis;
                bool preisIstDouble = Double.TryParse(werte[3], out preis);
                bool preisIstPositiv = preis > 0;

                if (!matchName.Success) fehler.Add(fehlerName);
                if (!matchBeschreibung.Success) fehler.Add(fehlerBeschreibung);
                if (!matchKategorie.Success) fehler.Add(fehlerKategorie);
                if (!preisIstDouble)
                {
                    fehler.Add(fehlerPreisDouble);
                }
                else { if (!preisIstPositiv) fehler.Add(fehlerPreisPositiv); }
                

                return fehler;
            }
            fehler.Add(fehlerParameter);
            return fehler;
        }
    }
}
