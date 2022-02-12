using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3.Models
{
    public partial class GymnasieskolaDbContext : DbContext
    {
        public GymnasieskolaDbContext()
        {
        }

        public GymnasieskolaDbContext(DbContextOptions<GymnasieskolaDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAvdelningPersonal> TblAvdelningPersonal { get; set; }
        public virtual DbSet<TblAvdelningar> TblAvdelningar { get; set; }
        public virtual DbSet<TblBetyg> TblBetyg { get; set; }
        public virtual DbSet<TblElever> TblElever { get; set; }
        public virtual DbSet<TblKlasser> TblKlasser { get; set; }
        public virtual DbSet<TblKursbetyg> TblKursbetyg { get; set; }
        public virtual DbSet<TblKurser> TblKurser { get; set; }
        public virtual DbSet<TblPersonal> TblPersonal { get; set; }
        public virtual DbSet<TblKursSchema> TblKursSchema { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-FUL8DVID;Initial Catalog=Gymnasieskola3;Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAvdelningPersonal>(entity =>
            {
                entity.HasKey(e => e.Apid);

                entity.ToTable("tblAvdelningPersonal");

                entity.Property(e => e.Apid).HasColumnName("APId");

                entity.Property(e => e.FavdelningId).HasColumnName("FAvdelningId");

                entity.Property(e => e.FpersonalId).HasColumnName("FPersonalId");

                entity.HasOne(d => d.Favdelning)
                    .WithMany(p => p.TblAvdelningPersonal)
                    .HasForeignKey(d => d.FavdelningId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAvdelningPersonal_tblAvdelningar");

                entity.HasOne(d => d.Fpersonal)
                    .WithMany(p => p.TblAvdelningPersonal)
                    .HasForeignKey(d => d.FpersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblAvdelningPersonal_tblPersonal");
            });

            modelBuilder.Entity<TblAvdelningar>(entity =>
            {
                entity.HasKey(e => e.AvdelningId);

                entity.ToTable("tblAvdelningar");

                entity.Property(e => e.AvdelningId).HasColumnName("AvdelningID");

                entity.Property(e => e.Avdelningsnamn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblBetyg>(entity =>
            {
                entity.HasKey(e => e.BetygId);

                entity.ToTable("tblBetyg");

                entity.Property(e => e.Betygsnamn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblElever>(entity =>
            {
                entity.HasKey(e => e.ElevId)
                    .HasName("PK__Elever__4AE80D636B475F3A");

                entity.ToTable("tblElever");

                entity.Property(e => e.Eefternamn)
                    .IsRequired()
                    .HasColumnName("EEfternamn")
                    .HasMaxLength(50);

                entity.Property(e => e.Eförnamn)
                    .IsRequired()
                    .HasColumnName("EFörnamn")
                    .HasMaxLength(50);

                entity.Property(e => e.FklassId).HasColumnName("FKlassID");

                entity.HasOne(d => d.Fklass)
                    .WithMany(p => p.TblElever)
                    .HasForeignKey(d => d.FklassId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblElever_tblKlasser");
            });

            modelBuilder.Entity<TblKlasser>(entity =>
            {
                entity.HasKey(e => e.KlassId);

                entity.ToTable("tblKlasser");

                entity.Property(e => e.KlassId).HasColumnName("KlassID");

                entity.Property(e => e.Klassnamn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblKursbetyg>(entity =>
            {
                entity.HasKey(e => e.KursbetygsId)
                    .HasName("PK_Kursbetyg");

                entity.ToTable("tblKursbetyg");

                entity.Property(e => e.BetygsDatum).HasColumnType("date");

                entity.Property(e => e.Fbetyg).HasColumnName("FBetyg");

                entity.Property(e => e.FelevId).HasColumnName("FElevId");

                entity.Property(e => e.FkursId).HasColumnName("FKursId");

                entity.Property(e => e.FpersonalId).HasColumnName("FPersonalId");

                entity.Property(e => e.KursSlutdatum).HasColumnType("date");

                entity.Property(e => e.KursStartdatum).HasColumnType("date");

                entity.HasOne(d => d.FbetygNavigation)
                    .WithMany(p => p.TblKursbetyg)
                    .HasForeignKey(d => d.Fbetyg)
                    .HasConstraintName("FK_tblKursbetyg_tblBetyg");

                entity.HasOne(d => d.Felev)
                    .WithMany(p => p.TblKursbetyg)
                    .HasForeignKey(d => d.FelevId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblKursbetyg_tblElever1");

                entity.HasOne(d => d.Fkurs)
                    .WithMany(p => p.TblKursbetyg)
                    .HasForeignKey(d => d.FkursId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblKursbetyg_tblKurser1");

                entity.HasOne(d => d.Fpersonal)
                    .WithMany(p => p.TblKursbetyg)
                    .HasForeignKey(d => d.FpersonalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblKursbetyg_tblPersonal1");
            });

            modelBuilder.Entity<TblKurser>(entity =>
            {
                entity.HasKey(e => e.KursId)
                    .HasName("PK__Kurser__BCCFFFDBADA6301B");

                entity.ToTable("tblKurser");

                entity.Property(e => e.Kursnamn)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblPersonal>(entity =>
            {
                entity.HasKey(e => e.PersonalId)
                    .HasName("PK__Personal__283437F36359159C");

                entity.ToTable("tblPersonal");

                entity.Property(e => e.Befattning)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Pefternamn)
                    .IsRequired()
                    .HasColumnName("PEfternamn")
                    .HasMaxLength(50);

                entity.Property(e => e.Pförnamn)
                    .IsRequired()
                    .HasColumnName("PFörnamn")
                    .HasMaxLength(50);

                entity.Property(e => e.Slutdatum).HasColumnType("date");

                entity.Property(e => e.Startdatum).HasColumnType("date");
            });

            modelBuilder.Entity<TblKursSchema>(entity =>
            {
                entity.HasKey(e => e.KursSchemaId)
                    .HasName("PK_KursSchema");

                entity.ToTable("tblKursSchema");

                entity.Property(e => e.FkursId).HasColumnName("FKursId");

                entity.Property(e => e.KursSlutdatum).HasColumnType("date");

                entity.Property(e => e.KursStartdatum).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
