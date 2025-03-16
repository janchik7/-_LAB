using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace IKM1.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
        Database.EnsureCreated();
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Buyer> Buyers { get; set; }

    public virtual DbSet<Property> Properties { get; set; }

    public virtual DbSet<Realtor> Realtors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=123");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Buyer>(entity =>
        {
            entity.HasKey(e => e.BuyerId).HasName("buyers_pkey");

            entity.ToTable("buyers");

            entity.Property(e => e.BuyerId).HasColumnName("buyer_id");
            entity.Property(e => e.Budget)
                .HasPrecision(12, 2)
                .HasColumnName("budget");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Property>(entity =>
        {
            entity.HasKey(e => e.PropertyId).HasName("properties_pkey");

            entity.ToTable("properties");

            entity.Property(e => e.PropertyId).HasColumnName("property_id");
            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .HasColumnName("address");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Price)
                .HasPrecision(12, 2)
                .HasColumnName("price");
            entity.Property(e => e.PropertyType)
                .HasMaxLength(20)
                .HasColumnName("property_type");
            entity.Property(e => e.RealtorId).HasColumnName("realtor_id");

        });

        modelBuilder.Entity<Realtor>(entity =>
        {
            entity.HasKey(e => e.RealtorId).HasName("realtors_pkey");

            entity.ToTable("realtors");

            entity.Property(e => e.RealtorId).HasColumnName("realtor_id");
            entity.Property(e => e.CommissionRate)
                .HasPrecision(4, 2)
                .HasDefaultValueSql("2.00")
                .HasColumnName("commission_rate");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .HasColumnName("full_name");
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .HasColumnName("phone");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
