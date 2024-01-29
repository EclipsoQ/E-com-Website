using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace main_prj.Models;

public partial class ComputerShopContext : DbContext
{
    public ComputerShopContext()
    {
    }

    public ComputerShopContext(DbContextOptions<ComputerShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CategoryProduct> CategoryProducts { get; set; }

    public virtual DbSet<Headphone> Headphones { get; set; }

    public virtual DbSet<Keyboard> Keyboards { get; set; }

    public virtual DbSet<Monitor> Monitors { get; set; }

    public virtual DbSet<Mouse> Mice { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ComputerShop;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Categori__19093A2BA5AF0244");

            entity.HasIndex(e => e.CategoryName, "UQ__Categori__8517B2E0E4819EB8").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(100);
        });

        modelBuilder.Entity<CategoryProduct>(entity =>
        {
            entity.HasKey(e => e.CatePrdId).HasName("PK__Category__35B5F72FD4D13DD7");

            entity.ToTable("Category_Product");

            entity.Property(e => e.CatePrdId).HasColumnName("CatePrdID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Category).WithMany(p => p.CategoryProducts)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Category___Categ__656C112C");

            entity.HasOne(d => d.Product).WithMany(p => p.CategoryProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Category___Produ__66603565");
        });

        modelBuilder.Entity<Headphone>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Accessories).HasMaxLength(100);
            entity.Property(e => e.Battery).HasMaxLength(100);
            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.Color).HasMaxLength(20);
            entity.Property(e => e.Compatibilities).HasMaxLength(100);
            entity.Property(e => e.ConnectionType).HasMaxLength(100);
            entity.Property(e => e.HeadphoneType).HasMaxLength(20);
            entity.Property(e => e.Microphone).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Headphone__Produ__74AE54BC");
        });

        modelBuilder.Entity<Keyboard>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Battery).HasMaxLength(100);
            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.Color).HasMaxLength(50);
            entity.Property(e => e.ConnectionType).HasMaxLength(100);
            entity.Property(e => e.KeyboardType).HasMaxLength(100);
            entity.Property(e => e.Led).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Switch).HasMaxLength(100);
            entity.Property(e => e.Weight).HasMaxLength(50);

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Keyboards__Produ__6EF57B66");
        });

        modelBuilder.Entity<Monitor>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.AspectRatio).HasMaxLength(20);
            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Resolution).HasMaxLength(20);
            entity.Property(e => e.Size).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Monitors__Produc__70DDC3D8");
        });

        modelBuilder.Entity<Mouse>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Battery).HasMaxLength(100);
            entity.Property(e => e.Brand).HasMaxLength(100);
            entity.Property(e => e.Color).HasMaxLength(100);
            entity.Property(e => e.ConnectionType).HasMaxLength(100);
            entity.Property(e => e.Model).HasMaxLength(100);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Resolution).HasMaxLength(100);
            entity.Property(e => e.Weight).HasMaxLength(100);

            entity.HasOne(d => d.Product).WithMany()
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Mice__ProductID__72C60C4A");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF127732F4");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Orders__UserID__693CA210");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C349079D5");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__6C190EBB");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Produ__6D0D32F4");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6ED38D2BE2C");

            entity.HasIndex(e => e.ProductName, "UQ_ProductName").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductImages).HasMaxLength(255);
            entity.Property(e => e.ProductName).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACE1626319");

            entity.HasIndex(e => e.Email, "UQ_Email").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
