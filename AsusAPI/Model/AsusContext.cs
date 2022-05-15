using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System;

namespace Model
{
    public class AsusContext : DbContext
    {
        public DbSet<Kupac> Kupci { get; set; }
        public DbSet<OdgovornoLice> OdgovornaLica { get; set; }
        public DbSet<Trziste> Trzista { get; set; }
        public DbSet<Drzava> Drzave { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<Proizvod> Proizvodi { get; set; }
        public DbSet<Karakteristika> Karakteristike { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=AsusProductManagement1;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Trziste>().HasKey(e => e.SifraTrzista);
            modelBuilder.Entity<OdgovornoLice>().HasKey(e => e.SifraRadnika );
            modelBuilder.Entity<Kupac>().HasKey(e => e.PIB);
            //modelBuilder.Entity<Proizvod>().HasKey(p => p.SifraProizvoda);
            //modelBuilder.Entity<Drzava>().HasKey(d => d.IDDrzave);

            modelBuilder.Entity<Proizvod>().OwnsMany(s => s.Karakteristike).WithOwner(t => t.Proizvod);

            modelBuilder.Entity<Drzava>().OwnsMany(e => e.Gradovi).WithOwner(e => e.Drzava);

            modelBuilder.Entity<OdgovornoLice>().HasOne(e => e.Trziste).WithMany().
                HasForeignKey(e => e.SifraTrzista).OnDelete(DeleteBehavior.NoAction);
            //modelBuilder.Entity<Kupac>().HasOne(k => k.Grad).WithMany(/*g => g.Kupci*/).HasForeignKey(e => e.DrzavaId);
            //modelBuilder.Entity<Kupac>().HasOne(k => k.Grad).WithMany(/*g => g.Kupci*/).HasForeignKey(e => e.GradId);

            //modelBuilder.Entity<Grad>().HasMany(g => g.Kupci).WithOne(k => k.Grad);

            //modelBuilder.Entity<Grad>().HasKey(g => new { g.PostanskiBroj, g.DrzavaId });
            //modelBuilder.Entity<Karakteristika>().HasKey(k => new { k.IDKarkteristike, k.ProizvodId });

            //modelBuilder.Entity<Kupac>(entity =>
            //{

            //    entity.HasOne(d => d.Grad)
            //        .WithMany(p => p.Kupci)
            //        .HasForeignKey(d => new { d.DrzavaId, d.GradId })
            //        .OnDelete(DeleteBehavior.ClientSetNull)
            //        .HasConstraintName("FK_Kupac_Grad");
            //});



        }
    }
}
