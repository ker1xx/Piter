using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace api.Models;
public partial class FuelContext : DbContext
{
    public FuelContext()
    {
    }

    public FuelContext(DbContextOptions<FuelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BankTransaction> BankTransactions { get; set; }

    public virtual DbSet<CameraLoad> CameraLoads { get; set; }

    public virtual DbSet<Datum> Data { get; set; }

    public virtual DbSet<GasStation> GasStations { get; set; }

    public virtual DbSet<LoyaltyСard> LoyaltyСards { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<Station> Stations { get; set; }
    public virtual DbSet<Vechicle> Vechicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BankTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Stations");

            entity.ToTable("Bank_Transaction");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AuthorizationCode).HasColumnName("authorization_code");
            entity.Property(e => e.AzsId).HasColumnName("AZS_ID");
            entity.Property(e => e.CardNubmer).HasColumnName("card_nubmer");
            entity.Property(e => e.NameSurname)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name_surname");
            entity.Property(e => e.OrgranizationName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("orgranization_name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SessionKey)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("session_key");
        });

        modelBuilder.Entity<CameraLoad>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Camera_l__3213E83FDF07A71A");

            entity.ToTable("Camera_load");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("date")
                .HasColumnName("date");
            entity.Property(e => e.Img)
                .HasMaxLength(50)
                .HasColumnName("img");
            entity.Property(e => e.StateNumber)
                .HasMaxLength(50)
                .HasColumnName("state_number");
            entity.Property(e => e.Status).HasColumnName("status");
        });

        modelBuilder.Entity<Datum>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__data__3213E83FA017A075");

            entity.ToTable("data");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.StationId).HasColumnName("Station_ID");
        });

        modelBuilder.Entity<GasStation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_data");

            entity.ToTable("Gas_Station");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.AddressId).HasColumnName("address_id");
            entity.Property(e => e.GasStation1Id).HasColumnName("gas_Station1_ID");
            entity.Property(e => e.GasStation2Id).HasColumnName("gas_Station2_ID");
        });

        modelBuilder.Entity<LoyaltyСard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Loyalty___3213E83F72C6E6CF");

            entity.ToTable("Loyalty_Сards");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardHolder).HasMaxLength(50);
            entity.Property(e => e.LoyaltyСard1).HasColumnName("LoyaltyСard");
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__purchase__3213E83F053FF365");

            entity.ToTable("purchase");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CardHolder)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("cardHolder");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.FuelType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("fuelType");
            entity.Property(e => e.PaymentType)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("paymentType");
            entity.Property(e => e.PurchaseDate)
                .HasColumnType("datetime")
                .HasColumnName("purchaseDate");
            entity.Property(e => e.StationId).HasColumnName("station_ID");
            entity.Property(e => e.Value).HasColumnName("value");
        });

        modelBuilder.Entity<Station>(entity =>
        {
            entity.HasKey(e => e.StationId).HasName("PK__Stations__55F200EE1206FC16");

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

        modelBuilder.Entity<Vechicle>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__vechicle__3213E83FDE7E332E");

            entity.ToTable("vechicle");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.CarNumber)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("car_number");
            entity.Property(e => e.CurrentFuel).HasColumnName("current_fuel");
            entity.Property(e => e.SizeOfTank).HasColumnName("size_of_tank");
            entity.Property(e => e.SupportedFuel)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("supported_fuel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
