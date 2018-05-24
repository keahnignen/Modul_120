using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace lb120_2_Bibliothek.DB
{
    class Buch
    {
        public Buch() { }
        [Key]
        public Int64 BuchId { get; set; }
        [Required]
        public String Titel { get; set; }
        public ICollection<Ausleihe> Ausleihen { get; set; }
        [NotMapped]
        public Boolean Verfuegbar {
            get
            {
                Boolean verfuegbar = true;
                // Loop durch alle Ausleihen
                foreach(DB.Ausleihe ausleihe in APP.Ausleihe.Lesen_BuchId(BuchId))
                {
                    if (DateTime.Today >= ausleihe.Start && DateTime.Today <= ausleihe.Ende && ausleihe.IstZurueck == false)
                    {
                        verfuegbar = false;
                    }
                }
                return verfuegbar;
            }
        }
        public override string ToString()
        {
            return BuchId.ToString();
        }
    }
}
