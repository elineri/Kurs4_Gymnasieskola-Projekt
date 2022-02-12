using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3
{
    public partial class Gymnasieskola3Context : DbContext
    {
        public Gymnasieskola3Context()
        {
        }

        public Gymnasieskola3Context(DbContextOptions<Gymnasieskola3Context> options)
            : base(options)
        {
        }

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
