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

        public virtual DbSet<Categorie> Categorie { get; set; }
        public virtual DbSet<DeliveryPoint> DeliveryPoint { get; set; }
        public virtual DbSet<Manufacturer> Manufacturer { get; set; }
        public virtual DbSet<Measure> Measure { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<ProductsOrder> ProductsOrder { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Statuse> Statuse { get; set; }
        public virtual DbSet<Supplier> Supplier { get; set; }
        public virtual DbSet<User> User { get; set; }

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
            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.ToTable("categorie");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('categories_id_seq'::regclass)");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("category_name");
            });

            modelBuilder.Entity<DeliveryPoint>(entity =>
            {
                entity.ToTable("delivery_point");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('delivery_points_id_seq'::regclass)");

                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasColumnName("delivery_address");
            });

            modelBuilder.Entity<Manufacturer>(entity =>
            {
                entity.ToTable("manufacturer");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('manufacturers_id_seq'::regclass)");

                entity.Property(e => e.ManufacturerName)
                    .IsRequired()
                    .HasColumnName("manufacturer_name");
            });

            modelBuilder.Entity<Measure>(entity =>
            {
                entity.ToTable("measure");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('measures_id_seq'::regclass)");

                entity.Property(e => e.MeasureName)
                    .IsRequired()
                    .HasColumnName("measure_name");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('orders_id_seq'::regclass)");

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
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdDeliveryPoint)
                    .HasConstraintName("orders_id_delivery_point_fkey");

                entity.HasOne(d => d.IdStatusesNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdStatuses)
                    .HasConstraintName("orders_id_statuses_fkey");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("orders_id_user_fkey");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('products_id_seq'::regclass)");

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
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("products_id_category_fkey");

                entity.HasOne(d => d.IdManufacturerNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdManufacturer)
                    .HasConstraintName("products_id_manufacturer_fkey");

                entity.HasOne(d => d.IdMeasureNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdMeasure)
                    .HasConstraintName("products_id_measure_fkey");

                entity.HasOne(d => d.IdSupplierNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdSupplier)
                    .HasConstraintName("products_id_supplier_fkey");

                entity.HasOne(d => d.IdTypeNavigation)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.IdType)
                    .HasConstraintName("products_id_type_fkey");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("product_type");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('product_types_id_seq'::regclass)");

                entity.Property(e => e.ProdType)
                    .IsRequired()
                    .HasColumnName("prod_type");
            });

            modelBuilder.Entity<ProductsOrder>(entity =>
            {
                entity.ToTable("products_order");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('products_orders_id_seq'::regclass)");

                entity.Property(e => e.IdOrder).HasColumnName("id_order");

                entity.Property(e => e.IdProduct).HasColumnName("id_product");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.IdOrderNavigation)
                    .WithMany(p => p.ProductsOrder)
                    .HasForeignKey(d => d.IdOrder)
                    .HasConstraintName("products_orders_id_order_fkey");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ProductsOrder)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("products_orders_id_product_fkey");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('roles_id_seq'::regclass)");

                entity.Property(e => e.RoleName)
                    .IsRequired()
                    .HasColumnName("role_name");
            });

            modelBuilder.Entity<Statuse>(entity =>
            {
                entity.ToTable("statuse");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('statuses_id_seq'::regclass)");

                entity.Property(e => e.StatusName)
                    .IsRequired()
                    .HasColumnName("status_name");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.ToTable("supplier");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('suppliers_id_seq'::regclass)");

                entity.Property(e => e.SupplierName)
                    .IsRequired()
                    .HasColumnName("supplier_name");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('users_id_seq'::regclass)");

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
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("users_id_role_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
