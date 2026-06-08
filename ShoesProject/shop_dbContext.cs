using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ShoesProject
{
    public partial class shop_dbContext : DbContext
    {
        public shop_dbContext()
        {
        }

        public shop_dbContext(DbContextOptions<shop_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<DeliveryPoints> DeliveryPoints { get; set; }
        public virtual DbSet<Manufacturers> Manufacturers { get; set; }
        public virtual DbSet<Measures> Measures { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<ProductTypes> ProductTypes { get; set; }
        public virtual DbSet<Products> Products { get; set; }
        public virtual DbSet<ProductsOrders> ProductsOrders { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Statuses> Statuses { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=shop_db;Username=postgres;Password=1111");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.ToTable("categories");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<DeliveryPoints>(entity =>
            {
                entity.ToTable("delivery_points");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasColumnName("delivery_address");
            });

            modelBuilder.Entity<Manufacturers>(entity =>
            {
                entity.ToTable("manufacturers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasColumnName("manufacturer_name");
            });

            modelBuilder.Entity<Measures>(entity =>
            {
                entity.ToTable("measures");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.MeasureName)
                    .IsRequired()
                    .HasColumnName("measure_name");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.ToTable("orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.DeliveryDate)
                    .HasColumnName("delivery_date")
                    .HasColumnType("date");

                entity.Property(e => e.IdDeliveryPoint).HasColumnName("id_delivery_point");

                entity.Property(e => e.IdStatuses).HasColumnName("id_statuses");

                entity.Property(e => e.IdUser).HasColumnName("id_user");

                entity.Property(e => e.OrderDate)
                    .HasColumnName("order_date")
                    .HasColumnType("date");

                entity.HasOne(d => d.IdDeliveryPointNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdDeliveryPoint)
                    .HasConstraintName("orders_id_delivery_point_fkey");

                entity.HasOne(d => d.IdStatusesNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdStatuses)
                    .HasConstraintName("orders_id_statuses_fkey");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("orders_id_user_fkey");
            });

            modelBuilder.Entity<ProductTypes>(entity =>
            {
                entity.ToTable("product_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProdType)
                    .IsRequired()
                    .HasColumnName("prod_type");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Art)
                    .IsRequired()
                    .HasColumnName("art");

                entity.Property(e => e.CointInStock).HasColumnName("coint_in_stock");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description");

                entity.Property(e => e.Discount).HasColumnName("discount");

                entity.Property(e => e.IdCategory).HasColumnName("id_category");

                entity.Property(e => e.IdManufacturer).HasColumnName("id_manufacturer");

                entity.Property(e => e.IdMeasure).HasColumnName("id_measure");

                entity.Property(e => e.IdSupplier).HasColumnName("id_supplier");

                entity.Property(e => e.IdType).HasColumnName("id_type");

                entity.Property(e => e.PhotoUrl).HasColumnName("photo_url");

                entity.Property(e => e.Price)
                    .HasColumnName("price")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("products_id_category_fkey");

                entity.HasOne(d => d.IdManufacturerNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdManufacturer)
                    .HasConstraintName("products_id_manufacturer_fkey");

                entity.HasOne(d => d.IdMeasureNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdMeasure)
                    .HasConstraintName("products_id_measure_fkey");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("products_id_supplier_fkey");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("products_id_type_fkey");
            });

            modelBuilder.Entity<ProductsOrders>(entity =>
            {
                entity.ToTable("products_orders");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.ProductsOrders)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("products_orders_id_order_fkey");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ProductsOrders)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("products_orders_id_product_fkey");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.ToTable("roles");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Statuses>(entity =>
            {
                entity.ToTable("statuses");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.ToTable("suppliers");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasColumnName("supplier_name");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name");

                entity.Property(e => e.IdRole).HasColumnName("id_role");

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasColumnName("last_name");

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasColumnName("login");

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasColumnName("middle_name");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass");

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("users_id_role_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
