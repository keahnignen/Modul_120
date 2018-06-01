using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lb120_2_Bibliothek.DB
{
    class Ausleihe
    {
        public Ausleihe() { }
        public Int16 AusleiheId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ende { get; set; }
        public Kunde Kunde { get; set; }
        public Buch Buch { get; set; }
        [Required]
        public String Bemerkungen { get; set; }
        [Required]
        public Boolean IstZurueck { get; set; }
        [NotMapped]
        public Boolean IstUeberfaellig
        {
            get
            {
                Boolean ueberfaellig = false;
                if (DateTime.Today >= Ende && IstZurueck == false)
                {
                    ueberfaellig = true;
                }
                return ueberfaellig;
            }
        }
        public override string ToString()
        {
            return AusleiheId.ToString();
        }

    }
}
