using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace lb120_2_Bibliothek.DB
{
    public class Kunde
    {
        public Kunde()
        { }
        public Int16 KundeId { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        public String Ortschaft { get; set; }
        public ICollection<Ausleihe> Ausleihen { get; set; }
        public override string ToString()
        {
            return KundeId.ToString();
        }
    }

}
