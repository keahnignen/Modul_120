//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AB120_02.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Kunde_Reise
    {
        public long Kunde_Reise_ID { get; set; }
        public long Kunde { get; set; }
        public long Reise { get; set; }
    
        public virtual Kunde Kunde1 { get; set; }
        public virtual Reise Reise1 { get; set; }
    }
}