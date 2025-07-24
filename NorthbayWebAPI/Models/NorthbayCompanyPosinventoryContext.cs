using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NorthbayWebAPI.Models;

public partial class NorthbayCompanyPosinventoryContext : DbContext
{
    public NorthbayCompanyPosinventoryContext()
    {
    }

    public NorthbayCompanyPosinventoryContext(DbContextOptions<NorthbayCompanyPosinventoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ProductList> ProductLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=NorthbayCompanyPOSInventory;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductList>(entity =>
        {
            entity
                .ToTable("ProductList");

            entity.Property(e => e.Datecreated).HasColumnType("datetime");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(50);
            entity.Property(e => e.ProductPrice).HasColumnType("decimal(32, 2)");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
