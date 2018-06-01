using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb120_2_Bibliothek.DB
{
    class AusleiheDarstellung
    {
        public Int16 AusleiheId { get; set; }
        public DateTime Start { get; set; }
        public DateTime Ende { get; set; }
        public long KundeId { get; set; }
        public string KundeName { get; set; }
        public long  BuchId { get; set; }

        public string BuchTitel { get; set; }

        public String Bemerkungen { get; set; }
 
        public Boolean IstZurueck { get; set; }

        public static AusleiheDarstellung[] toAusleiheDarstellung(Ausleihe[] ab)
        {

            List<AusleiheDarstellung> sd = new List<AusleiheDarstellung>();
            foreach (var a in ab)
            {
                var x = new AusleiheDarstellung();
                x.AusleiheId = a.AusleiheId;
                x.Start = a.Start;
                x.Ende = a.Ende;
                x.KundeId = a.Kunde.KundeId;
                x.KundeName = a.Kunde.Name;
                x.BuchId = a.Buch.BuchId;
                x.BuchTitel = a.Buch.Titel;
                sd.Add(x);
            }       
            return sd.ToArray();
        }
    }
}
