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
        internal virtual DbSet<Helper> Helpers { get; set; }
        internal virtual DbSet<Invoice> Invoices { get; set; }
        internal virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        internal virtual DbSet<InvoicePayment> InvoicePayments { get; set; }
        internal virtual DbSet<Order> Orders { get; set; }
        internal virtual DbSet<OrderItem> OrderItems { get; set; }
        internal virtual DbSet<PickListOrder> PickListOrders { get; set; }
        internal virtual DbSet<PickListOrderItem> PickListOrderItems { get; set; }
        internal virtual DbSet<PrintOrder> PrintOrders { get; set; }
        internal virtual DbSet<Product> Products { get; set; }
        internal virtual DbSet<ProductBundle> ProductBundles { get; set; }
        internal virtual DbSet<ProductBundleItem> ProductBundleItems { get; set; }
        internal virtual DbSet<ProductColor> ProductColors { get; set; }
        internal virtual DbSet<ProductColorSize> ProductColorSizes { get; set; }
        internal virtual DbSet<ProductInventoryLocation> ProductInventoryLocations { get; set; }
        internal virtual DbSet<ProductMovementHistory> ProductMovementHistorys { get; set; }
        internal virtual DbSet<ProductShipmentHistory> ProductShipmentHistorys { get; set; }
        internal virtual DbSet<SystemOwner> SystemOwners { get; set; }
        internal virtual DbSet<InventoryLocation> InventoryLocations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().
                HasMany(x => x.OrderItems).
                WithOne(x => x.Order);

            modelBuilder.Entity<InventoryLocation>()
                .Property(t => t.Type)
                .HasConversion(new EnumToStringConverter<InventoryLocationType>());
        }
    }
}