using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace api.Models
{
    public partial class FuelContext : DbContext
    {
        public FuelContext()
        {
        }

        public FuelContext(DbContextOptions<FuelContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Datum> Data { get; set; } = null!;
        public virtual DbSet<Station> Stations { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Datum>(entity =>
            {
                entity.ToTable("data");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StationId).HasColumnName("Station_ID");
            });

            modelBuilder.Entity<Station>(entity =>
            {
                entity.Property(e => e.StationId)
                    .ValueGeneratedNever()
                    .HasColumnName("Station_ID");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Data1).HasColumnName("data1");

                entity.Property(e => e.Data2).HasColumnName("data2");

                entity.Property(e => e.Data3).HasColumnName("data3");

                entity.Property(e => e.Data4).HasColumnName("data4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
