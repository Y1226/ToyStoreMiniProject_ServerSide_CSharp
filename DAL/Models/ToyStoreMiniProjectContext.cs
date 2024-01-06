using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class ToyStoreMiniProjectContext : DbContext
{
    public ToyStoreMiniProjectContext()
    {
    }

    public ToyStoreMiniProjectContext(DbContextOptions<ToyStoreMiniProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoryTbl> CategoryTbls { get; set; }

    public virtual DbSet<ProductTbl> ProductTbls { get; set; }

    public virtual DbSet<SaleDetailsTbl> SaleDetailsTbls { get; set; }

    public virtual DbSet<SalesTbl> SalesTbls { get; set; }

    public virtual DbSet<UserTbl> UserTbls { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LAPTOP-JQVA1GIN;Database=ToyStore_MiniProject;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryTbl>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2B7DEB0D96");

            entity.ToTable("Category_tbl");

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<ProductTbl>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product___B40CC6ED3356FB10");

            entity.ToTable("Product_tbl");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductPicture)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.ProductTbls)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product_t__Categ__398D8EEE");
        });

        modelBuilder.Entity<SaleDetailsTbl>(entity =>
        {
            entity.HasKey(e => e.SaleDetailsId).HasName("PK__SaleDeta__2BFB0DB3619023FA");

            entity.ToTable("SaleDetails_tbl");

            entity.Property(e => e.SaleDetailsId).HasColumnName("SaleDetailsID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.SaleId).HasColumnName("SaleID");

            entity.HasOne(d => d.Product).WithMany(p => p.SaleDetailsTbls)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaleDetai__Produ__4222D4EF");

            entity.HasOne(d => d.Sale).WithMany(p => p.SaleDetailsTbls)
                .HasForeignKey(d => d.SaleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SaleDetai__SaleI__412EB0B6");
        });

        modelBuilder.Entity<SalesTbl>(entity =>
        {
            entity.HasKey(e => e.SaleId).HasName("PK__Sales_tb__1EE3C41F82E1D0FB");

            entity.ToTable("Sales_tbl");

            entity.Property(e => e.SaleId).HasColumnName("SaleID");
            entity.Property(e => e.SaleDate).HasColumnType("date");
            entity.Property(e => e.UserId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.SalesTbls)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Sales_tbl__UserI__3E52440B");
        });

        modelBuilder.Entity<UserTbl>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User_tbl__1788CCAC7378AEE9");

            entity.ToTable("User_tbl");

            entity.Property(e => e.UserId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("UserID");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserEmail)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserFirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserLastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPassword)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserPhone)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
