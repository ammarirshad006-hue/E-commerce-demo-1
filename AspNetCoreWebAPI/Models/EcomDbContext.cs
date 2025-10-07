using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWebAPI.Models;

public partial class EcomDbContext : DbContext
{
    public EcomDbContext()
    {
    }

    public EcomDbContext(DbContextOptions<EcomDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Seller> Sellers { get; set; }

    public virtual DbSet<SellerProduct> SellerProducts { get; set; }

    public virtual DbSet<User> Users { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)

    {
       
    
        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
        {
            relationship.DeleteBehavior = DeleteBehavior.Cascade;
        }
    
    modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07D4AA8629");

            entity.ToTable("Category");

            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC07A6AA8C8A");

            entity.ToTable("Customer");

            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.City)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.SellerType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("seller_type");
            entity.Property(e => e.State)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC07C2F1B4E6");

            entity.Property(e => e.OrderDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.ShippingAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasDefaultValue("Pending");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__Customer__571DF1D5");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__OrderDet__3214EC07161406D3");

            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Order__01142BA1");

            entity.HasOne(d => d.SellerProducts).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.SellerProductsId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__OrderDeta__Selle__00200768");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC076D0F71DE");

            entity.ToTable("Product");

            entity.HasIndex(e => e.ApprovedBy, "idx_product_approvedby");

            entity.HasIndex(e => e.CategoryId, "idx_product_category");

            entity.HasIndex(e => e.CreatedBy, "idx_product_createdby");

            entity.HasIndex(e => e.RequestedBy, "idx_product_requestedby");

            entity.Property(e => e.ApprovedAt).HasColumnType("datetime");
            entity.Property(e => e.ApprovedBy)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.CreatedAt).HasColumnType("datetime");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.RequestedAt).HasColumnType("datetime");
            entity.Property(e => e.RequestedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sku)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("SKU");
            entity.Property(e => e.Status)
                .HasMaxLength(25)
                .IsUnicode(false);

            entity.HasOne(d => d.ApprovedByNavigation).WithMany(p => p.ProductApprovedByNavigations)
                .HasPrincipalKey(p => p.Name)
                .HasForeignKey(d => d.ApprovedBy)
                .HasConstraintName("FK__Product__Approve__75A278F5");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Product__Categor__73BA3083");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.ProductCreatedByNavigations)
                .HasPrincipalKey(p => p.Name)
                .HasForeignKey(d => d.CreatedBy)
                .HasConstraintName("FK__Product__Created__74AE54BC");

            entity.HasOne(d => d.RequestedByNavigation).WithMany(p => p.Products)
                .HasPrincipalKey(p => p.Name)
                .HasForeignKey(d => d.RequestedBy)
                .HasConstraintName("FK__Product__Request__76969D2E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07784E7CAB");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Seller>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Seller__3214EC070293E578");

            entity.ToTable("Seller");

            entity.HasIndex(e => e.Name, "UQ_Seller_Name").IsUnique();

            entity.HasIndex(e => e.Name, "UQ__Seller__737584F65327278D").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Seller__AB6E61641D5A410E").IsUnique();

            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(15)
                .IsUnicode(false)
                .HasColumnName("phone_number");
            entity.Property(e => e.SellerType)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("seller_type");
        });

        modelBuilder.Entity<SellerProduct>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SellerPr__3214EC0797DBE07A");

            entity.Property(e => e.ListingDate).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Product).WithMany(p => p.SellerProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__SellerPro__Produ__7D439ABD");

            entity.HasOne(d => d.Seller).WithMany(p => p.SellerProducts)
                .HasForeignKey(d => d.SellerId)
                .HasConstraintName("FK__SellerPro__Selle__7C4F7684");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07E1D84254");

            entity.HasIndex(e => e.Name, "UQ_Users_Name").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534573096FD").IsUnique();

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Users__RoleId__3B75D760");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
