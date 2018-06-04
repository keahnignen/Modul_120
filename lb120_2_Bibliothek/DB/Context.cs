using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb120_2_Bibliothek.DB
{
    class Context : DbContext
    {
        public Context(): base("name=MyConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = true;
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DB.Context, lb120_2_Bibliothek.Migrations.Configuration>());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Kunde>().ToTable("Kunde"); // Damit kein "s" angehängt wird an Tabelle
            modelBuilder.Entity<Buch>().ToTable("Buch"); // Damit kein "s" angehängt wird an Tabelle
            modelBuilder.Entity<Ausleihe>().ToTable("Ausleihe"); // Damit kein "s" angehängt wird an Tabelle
        }
        public DbSet<Kunde> Kunden { get; set; }
        public DbSet<Buch> Buecher { get; set; }
        public DbSet<Ausleihe> Ausleihen { get; set; }

    }
}
