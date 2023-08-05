using System;
using System.Collections.Generic;
using Domains;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace RedStore.Models;

public partial class RedStoreShopContext : IdentityDbContext<IdentityUser>
{
    public RedStoreShopContext()
    {
    }

    public RedStoreShopContext(DbContextOptions<RedStoreShopContext> options)
        : base(options)
    {
    }
    public virtual DbSet<TbFeatured> TbFeatureds { get; set; }

    public virtual DbSet<TbHeader> TbHeaders { get; set; }

    public virtual DbSet<TbMainProduct> TbMainProducts { get; set; }

    public virtual DbSet<TbOffer> TbOffers { get; set; }

    public virtual DbSet<TbSalesInvoices> TbSalesInvoices { get; set; }

    public virtual DbSet<Tbtestimonial> Tbtestimonials { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        // identity
        base.OnModelCreating(modelBuilder);
        // identity

        modelBuilder.Entity<TbFeatured>(entity =>
        {
            entity.HasKey(e => e.FeaturedId);

            entity.ToTable("TbFeatured");

            entity.Property(e => e.ImageName).HasMaxLength(200);
            entity.Property(e => e.Pragraph)
                .HasMaxLength(200)
                .HasColumnName("pragraph");
            entity.Property(e => e.Prand).HasMaxLength(200);
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Qty).HasMaxLength(10);
            entity.Property(e => e.Rating).HasMaxLength(200);
            entity.Property(e => e.SalesPrice).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Size).HasMaxLength(200);
            entity.Property(e => e.Subtotal).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<TbHeader>(entity =>
        {
            entity.HasKey(e => e.HeaderId);

            entity.ToTable("TbHeader");

            entity.Property(e => e.ImageName).HasMaxLength(200);
            entity.Property(e => e.Paragraph).HasMaxLength(500);
            entity.Property(e => e.Title).HasMaxLength(500);
        });

        modelBuilder.Entity<TbMainProduct>(entity =>
        {
            entity.HasKey(e => e.MainId);

            entity.Property(e => e.ImageName).HasMaxLength(200);
            entity.Property(e => e.Pragraph)
                .HasMaxLength(200)
                .HasColumnName("pragraph");
            entity.Property(e => e.Prand).HasMaxLength(200);
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.PurchasePrice).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Qty).HasMaxLength(10);
            entity.Property(e => e.Rating).HasMaxLength(200);
            entity.Property(e => e.SalesPrice).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Size).HasMaxLength(200);
            entity.Property(e => e.Subtotal).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Tax).HasColumnType("decimal(8, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(8, 2)");
        });

        modelBuilder.Entity<TbOffer>(entity =>
        {
            entity.HasKey(e => e.OffersId);

            entity.ToTable("TbOffer");

            entity.Property(e => e.ImageName).HasMaxLength(200);
        });

        modelBuilder.Entity<TbSalesInvoices>(entity =>
        {
            entity.HasKey(e => e.InvoiceId);

            entity.Property(e => e.DelivryDate).HasColumnType("datetime");
            entity.Property(e => e.ImageName).HasMaxLength(200);
            entity.Property(e => e.InvoiceDate).HasColumnType("datetime");
            entity.Property(e => e.Prand).HasMaxLength(200);
            entity.Property(e => e.ProductName).HasMaxLength(200);
            entity.Property(e => e.SalesPrice).HasMaxLength(200);
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Tbtestimonial>(entity =>
        {
            entity.HasKey(e => e.TestimonialsId);

            entity.Property(e => e.Comment).HasMaxLength(4000);
            entity.Property(e => e.CustmerName).HasMaxLength(200);
            entity.Property(e => e.ImageName).HasMaxLength(200);
            entity.Property(e => e.Rating).HasMaxLength(200);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
