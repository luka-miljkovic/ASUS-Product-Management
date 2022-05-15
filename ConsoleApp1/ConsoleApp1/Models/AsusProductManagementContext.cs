using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ConsoleApp1.Models
{
    public partial class AsusProductManagementContext : DbContext
    {
        public AsusProductManagementContext()
        {
        }

        public AsusProductManagementContext(DbContextOptions<AsusProductManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Drzava> Drzavas { get; set; }
        public virtual DbSet<Grad> Grads { get; set; }
        public virtual DbSet<Karakteristika> Karakteristikas { get; set; }
        public virtual DbSet<Kupac> Kupacs { get; set; }
        public virtual DbSet<OdgovornoLice> OdgovornoLices { get; set; }
        public virtual DbSet<Proizvod> Proizvods { get; set; }
        public virtual DbSet<Trziste> Trzistes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AsusProductManagement;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Drzava>(entity =>
            {
                entity.ToTable("Drzava");
            });

            modelBuilder.Entity<Grad>(entity =>
            {
                entity.HasKey(e => new { e.DrzavaId, e.PostanskiBroj });

                entity.ToTable("Grad");

                entity.Property(e => e.PostanskiBroj).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Drzava)
                    .WithMany(p => p.Grads)
                    .HasForeignKey(d => d.DrzavaId);
            });

            modelBuilder.Entity<Karakteristika>(entity =>
            {
                entity.HasKey(e => new { e.ProizvodId, e.KarakteristikaId });

                entity.ToTable("Karakteristika");

                entity.Property(e => e.KarakteristikaId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Proizvod)
                    .WithMany(p => p.Karakteristikas)
                    .HasForeignKey(d => d.ProizvodId);
            });

            modelBuilder.Entity<Kupac>(entity =>
            {
                entity.HasKey(e => e.Pib);

                entity.ToTable("Kupac");

                entity.Property(e => e.Pib).HasColumnName("PIB");

                entity.Property(e => e.UlicaIbroj).HasColumnName("UlicaIBroj");

                entity.HasOne(d => d.Grad)
                    .WithMany(p => p.Kupacs)
                    .HasForeignKey(d => new { d.DrzavaId, d.GradId })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Kupac_Grad");
            });

            modelBuilder.Entity<OdgovornoLice>(entity =>
            {
                entity.HasKey(e => e.SifraRadnika);

                entity.ToTable("OdgovornoLice");

                entity.HasIndex(e => e.SifraTrzista, "IX_OdgovornoLice_SifraTrzista");

                entity.HasOne(d => d.SifraTrzistaNavigation)
                    .WithMany(p => p.OdgovornoLices)
                    .HasForeignKey(d => d.SifraTrzista)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Proizvod>(entity =>
            {
                entity.ToTable("Proizvod");
            });

            modelBuilder.Entity<Trziste>(entity =>
            {
                entity.HasKey(e => e.SifraTrzista);

                entity.ToTable("Trziste");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
