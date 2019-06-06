using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace M120Projekt.Data
{
    public class Komponent
    {
        #region Datenbankschicht
        [Key]
        public Int64 Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Beschreibung { get; set; }
        [Required]
        public String Kategorie { get; set; }
        [Required]
        public DateTime Registriert_am { get; set; }
        [Required]
        public double Preis { get; set; }

        #endregion
        #region Applikationsschicht
        public Komponent() { }
        
        public static IEnumerable<Data.Komponent> LesenAlle()
        {
            return (from record in Data.Global.context.Komponent select record);
        }
        public static Data.Komponent LesenID(Int64 KomponentId)
        {
            return (from record in Data.Global.context.Komponent where record.Id == KomponentId select record).FirstOrDefault();
        }
        public static IEnumerable<Data.Komponent> LesenAttributGleich(String suchbegriff)
        {
            return (from record in Data.Global.context.Komponent where record.Name == suchbegriff select record);
        }
        public static IEnumerable<Data.Komponent> LesenAttributWie(String suchbegriff)
        {
            return (from record in Data.Global.context.Komponent where record.Name.Contains(suchbegriff) select record);
        }
        public Int64 Erstellen()
        {
            if (this.Name == null || this.Name == "") this.Name = "leer";
            if (this.Registriert_am == null) this.Registriert_am = DateTime.MinValue;
            Data.Global.context.Komponent.Add(this);
            Data.Global.context.SaveChanges();
            return this.Id;
        }
        public Int64 Aktualisieren()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Modified;
            Data.Global.context.SaveChanges();
            return this.Id;
        }
        public void Loeschen()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
            Data.Global.context.SaveChanges();
        }
        public override string ToString()
        {
            return Id.ToString(); // Für bessere Coded UI Test Erkennung
        }

        public static long naechsteID()
        {

            //return Data.Global.context.Komponent.SqlQuery("SELECT IDENT_CURRENT('dbo.Komponent');");
            try
            {
                long id = LesenAlle().Last().Id;
                return id;
            } catch (Exception e)
            {

            }
            return 1;
        }            
          
       

        #endregion
    }
}
