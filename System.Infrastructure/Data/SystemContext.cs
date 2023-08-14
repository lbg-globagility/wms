using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Enums;

namespace WarehouseManagementSystem.Infrastructure.Data
{
    public class SystemContext : DbContext
    {
        public SystemContext(DbContextOptions options)
            : base(options)
        {
        }

        internal virtual DbSet<Agent> Agents { get; set; }
        internal virtual DbSet<Category> Categories { get; set; }
        internal virtual DbSet<Color> Colors { get; set; }
        internal virtual DbSet<Helper> Helpers { get; set; }
        internal virtual DbSet<InventoryLocation> InventoryLocations { get; set; }
        internal virtual DbSet<Invoice> Invoices { get; set; }
        internal virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        internal virtual DbSet<InvoicePayment> InvoicePayments { get; set; }
        internal virtual DbSet<Order> Orders { get; set; }
        internal virtual DbSet<OrderItem> OrderItems { get; set; }
        internal virtual DbSet<Organization> Organizations { get; set; }
        internal virtual DbSet<PickListOrder> PickListOrders { get; set; }
        internal virtual DbSet<PickListOrderItem> PickListOrderItems { get; set; }
        internal virtual DbSet<PrintOrder> PrintOrders { get; set; }
        internal virtual DbSet<Product> Products { get; set; }
        internal virtual DbSet<ProductBundle> ProductBundles { get; set; }
        internal virtual DbSet<ProductBundleItem> ProductBundleItems { get; set; }
        internal virtual DbSet<ProductColor> ProductColors { get; set; }
        internal virtual DbSet<ProductColorSize> ProductColorSizes { get; set; }
        internal virtual DbSet<ProductInventoryLocation> ProductInventoryLocations { get; set; }
        internal virtual DbSet<ProductMovementHistory> ProductMovementHistories { get; set; }
        internal virtual DbSet<ProductShipmentHistory> ProductShipmentHistories { get; set; }
        internal virtual DbSet<RackShelfColumn> RackShelfColumns { get; set; }
        internal virtual DbSet<SystemOwner> SystemOwners { get; set; }
        internal virtual DbSet<UserActivity> UserActivities { get; set; }
        internal virtual DbSet<UserActivityItem> UserActivityItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>(t =>
            {
                t.Property(x => x.Status)
                    .HasConversion(new EnumToStringConverter<CategoryStatus>());

                t.HasMany(x => x.Products)
                    .WithOne(x => x.Category);
            });

            modelBuilder.Entity<Color>(t =>
            {
                t.HasMany(x => x.ProductColors)
                    .WithOne(x => x.Color);

                t.Property(x => x.Status)
                    .HasConversion(new EnumToStringConverter<ColorStatus>());
            });

            modelBuilder.Entity<InventoryLocation>(t =>
            {
                t.Property(x => x.Type)
                .HasConversion(new EnumToStringConverter<InventoryLocationType>());

                t.HasMany(x => x.RackShelfColumns)
                    .WithOne(x => x.InventoryLocation);
            });

            modelBuilder.Entity<Order>()
                .HasMany(x => x.OrderItems)
                .WithOne(x => x.Order);

            modelBuilder.Entity<Product>(t =>
            {
                t.HasMany(x => x.ProductColors)
                    .WithOne(x => x.Product);

                t.HasOne(x => x.Category)
                    .WithMany(x => x.Products);
            });

            modelBuilder.Entity<ProductColor>(t =>
            {
                t.HasOne(x => x.Color)
                    .WithMany(x => x.ProductColors);

                t.HasMany(x => x.ProductColorSizes)
                    .WithOne(x => x.ProductColor);

                t.HasOne(x => x.Product)
                    .WithMany(x => x.ProductColors);

                t.Property(x => x.Status)
                    .HasConversion(new EnumToStringConverter<ProductColorStatus>());
            });

            modelBuilder.Entity<ProductColorSize>(t =>
            {
                t.HasMany(x => x.ProductInventoryLocations)
                    .WithOne(x => x.ProductColorSize);

                t.HasOne(x => x.ProductColor)
                    .WithMany(x => x.ProductColorSizes);
            });

            modelBuilder.Entity<ProductInventoryLocation>(t =>
            {
                t.HasOne(x => x.ProductColorSize)
                    .WithMany(x => x.ProductInventoryLocations);

                t.HasOne(x => x.RackShelfColumn)
                    .WithMany(x => x.ProductInventoryLocations);
            });

            modelBuilder.Entity<RackShelfColumn>(t =>
            {
                t.HasMany(x => x.ProductInventoryLocations)
                    .WithOne(x => x.RackShelfColumn);

                t.Property(x => x.Status)
                    .HasConversion(new EnumToStringConverter<RackShelfColumnStatus>());
            });
        }
    }
}