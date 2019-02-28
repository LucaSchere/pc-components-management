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
    public class KlasseA
    {
        #region Datenbankschicht
        [Key]
        public Int64 KlasseAId { get; set; }
        [Required]
        public String TextAttribut { get; set; }
        [Required]
        public DateTime DatumAttribut { get; set; }
        [Required]
        public Boolean BooleanAttribut { get; set; }
        #endregion
        #region Applikationsschicht
        public KlasseA() { }
        [NotMapped]
        public String BerechnetesAttribut
        {
            get
            {
                return "Im Getter kann Code eingefügt werden für berechnete Attribute";
            }
        }
        public static IEnumerable<Data.KlasseA> LesenAlle()
        {
            return (from record in Data.Global.context.KlasseA select record);
        }
        public static Data.KlasseA LesenID(Int64 klasseAId)
        {
            return (from record in Data.Global.context.KlasseA where record.KlasseAId == klasseAId select record).FirstOrDefault();
        }
        public static IEnumerable<Data.KlasseA> LesenAttributGleich(String suchbegriff)
        {
            return (from record in Data.Global.context.KlasseA where record.TextAttribut == suchbegriff select record);
        }
        public static IEnumerable<Data.KlasseA> LesenAttributWie(String suchbegriff)
        {
            return (from record in Data.Global.context.KlasseA where record.TextAttribut.Contains(suchbegriff) select record);
        }
        public Int64 Erstellen()
        {
            if (this.TextAttribut == null || this.TextAttribut == "") this.TextAttribut = "leer";
            if (this.DatumAttribut == null) this.DatumAttribut = DateTime.MinValue;
            Data.Global.context.KlasseA.Add(this);
            Data.Global.context.SaveChanges();
            return this.KlasseAId;
        }
        public Int64 Aktualisieren()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Modified;
            Data.Global.context.SaveChanges();
            return this.KlasseAId;
        }
        public void Loeschen()
        {
            Data.Global.context.Entry(this).State = System.Data.Entity.EntityState.Deleted;
            Data.Global.context.SaveChanges();
        }
        public override string ToString()
        {
            return KlasseAId.ToString(); // Für bessere Coded UI Test Erkennung
        }
        #endregion
    }
}
