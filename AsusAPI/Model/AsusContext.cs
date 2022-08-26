using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Model.Domain;
using System;

namespace Model
{
    public class AsusContext : IdentityDbContext<OdgovornoLice, IdentityRole<int>, int>
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
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OdgovornoLice>().ToTable("OdgovornoLice");

            modelBuilder.Entity<Trziste>().HasKey(e => e.SifraTrzista);
            //modelBuilder.Entity<OdgovornoLice>().HasKey(e => e.SifraRadnika );
            modelBuilder.Entity<Kupac>().HasKey(e => e.PIB);
            modelBuilder.Entity<Proizvod>().HasKey(p => p.SifraProizvoda);
            modelBuilder.Entity<Drzava>().HasKey(p => p.IDDrzave);

            modelBuilder.Entity<Drzava>().HasMany(d => d.Gradovi).WithOne(g => g.Drzava);
            modelBuilder.Entity<Grad>().HasKey(g => new { g.PostanskiBroj, g.IDDrzave });

            //modelBuilder.Entity<Proizvod>().HasMany(p => p.Karakteristike).WithOne(k => k.Proizvod);
            modelBuilder.Entity<Karakteristika>().HasKey(k => new { k.IDKarakteristike, k.SifraProizvoda });

            //modelBuilder.Entity<Drzava>().OwnsMany(e => e.Gradovi).WithOwner(e => e.Drzava);
            //modelBuilder.Entity<Proizvod>().OwnsMany(p => p.Karakteristike).WithOwner(k => k.Proizvod);

            
            

            //modelBuilder.Entity<OdgovornoLice>().HasOne(e => e.Trziste).WithMany().
            //    HasForeignKey(e => e.SifraTrzista).OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Kupac>(entity =>
            {

                entity.HasOne(k => k.Grad)
                    .WithMany()
                    .HasForeignKey(k => new {k.PostanskiBroj, k.IDDrzave})
                    .OnDelete(DeleteBehavior.Restrict)
                    .HasConstraintName("FK_Kupac_Grad");
            });



        }
    }
}
