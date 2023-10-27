using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq.Expressions;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Entities.Base;
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
        internal virtual DbSet<Contact> Contacts { get; set; }
        internal virtual DbSet<Helper> Helpers { get; set; }
        internal virtual DbSet<InventoryLocation> InventoryLocations { get; set; }
        internal virtual DbSet<Invoice> Invoices { get; set; }
        internal virtual DbSet<InvoiceItem> InvoiceItems { get; set; }
        internal virtual DbSet<InvoicePayment> InvoicePayments { get; set; }
        internal virtual DbSet<Lineup> Lineups { get; set; }
        internal virtual DbSet<MovementHistory> MovementHistories { get; set; }

        internal virtual DbSet<Order> Orders { get; set; }
        internal virtual DbSet<OrderItem> OrderItems { get; set; }
        internal virtual DbSet<Organization> Organizations { get; set; }
        internal virtual DbSet<PickListOrder> PickListOrders { get; set; }
        internal virtual DbSet<PickListOrderItem> PickListOrderItems { get; set; }
        internal virtual DbSet<Position> Positions { get; set; }
        internal virtual DbSet<PositionView> PositionViews { get; set; }
        internal virtual DbSet<PrintOrder> PrintOrders { get; set; }
        internal virtual DbSet<Product> Products { get; set; }
        internal virtual DbSet<ProductBundle> ProductBundles { get; set; }
        internal virtual DbSet<ProductBundleItem> ProductBundleItems { get; set; }
        internal virtual DbSet<ProductColor> ProductColors { get; set; }
        internal virtual DbSet<ProductColorSize> ProductColorSizes { get; set; }
        internal virtual DbSet<ProductInventoryLocation> ProductInventoryLocations { get; set; }
        internal virtual DbSet<MovementHistory> ProductMovementHistories { get; set; }
        internal virtual DbSet<ProductShipmentHistory> ProductShipmentHistories { get; set; }
        internal virtual DbSet<RackShelfColumn> RackShelfColumns { get; set; }
        internal virtual DbSet<SystemOwner> SystemOwners { get; set; }
        internal virtual DbSet<User> Users { get; set; }
        internal virtual DbSet<UserActivity> UserActivities { get; set; }
        internal virtual DbSet<UserActivityItem> UserActivityItems { get; set; }
        internal virtual DbSet<View> Views { get; set; }

        private static void SetGeneratedColumnsToReadOnly(ModelBuilder modelBuilder)
        {
            var created = GetPropertyName<AuditableEntity>(x => x.Created);
            var lastUpd = GetPropertyName<AuditableEntity>(x => x.LastUpd);
            var createdBy = GetPropertyName<AuditableEntity>(x => x.CreatedBy);
            var lastUpdBy = GetPropertyName<AuditableEntity>(x => x.LastUpdBy);

            foreach (var t in modelBuilder.Model.GetEntityTypes())
            {
                if (CheckIfDerivableByAuditableEntity(t.ClrType.BaseType))
                {
                    // Even if the LastUpd and Created columns are private
                    // they are still included in the update query.
                    // If we strictly want them to be never be altered by
                    // ef core and only the database can update them,
                    // we can use the code below:
                    var createdMetaData = modelBuilder
                        .Entity(t.ClrType)
                        .Property(created)
                        .ValueGeneratedOnAddOrUpdate()
                        .Metadata;

                    createdMetaData.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
                    createdMetaData.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                    var lastupdMetaData = modelBuilder
                        .Entity(t.ClrType)
                        .Property(lastUpd)
                        .ValueGeneratedOnAddOrUpdate()
                        .Metadata;

                    lastupdMetaData.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
                    lastupdMetaData.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                    // CreatedBy can only be modified by ef core when EntityState is EntityState.Added
                    var createdByMetaData = modelBuilder
                        .Entity(t.ClrType)
                        .Property(createdBy)
                        .ValueGeneratedOnAddOrUpdate()
                        .Metadata;

                    createdByMetaData.BeforeSaveBehavior = PropertySaveBehavior.Save;
                    createdByMetaData.AfterSaveBehavior = PropertySaveBehavior.Ignore;

                    // LastUpdBy can only be modified by ef core when EntityState is not EntityState.Added
                    var lastUpdByMetaData = modelBuilder
                        .Entity(t.ClrType)
                        .Property(lastUpdBy)
                        .ValueGeneratedOnAddOrUpdate()
                        .Metadata;

                    lastUpdByMetaData.BeforeSaveBehavior = PropertySaveBehavior.Ignore;
                    lastUpdByMetaData.AfterSaveBehavior = PropertySaveBehavior.Save;
                }
            }
        }

        private static bool CheckIfDerivableByAuditableEntity(Type baseType)
        {
            while (baseType != null)
            {
                if (baseType == typeof(AuditableEntity))
                {
                    return true;
                }
                else
                {
                    baseType = baseType?.BaseType;
                }
            }

            return false;
        }

        private static string GetPropertyName<T>(Expression<Func<T, object>> expression)
        {
            if (expression.Body is MemberExpression)
            {
                return ((MemberExpression)expression.Body).Member.Name;
            }
            else
            {
                var op = ((UnaryExpression)expression.Body).Operand;
                return ((MemberExpression)op).Member.Name;
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SetGeneratedColumnsToReadOnly(modelBuilder);

            //modelBuilder.Entity<Agent>(t =>
            //{
            //    t.ToTable("agents");

            //    t.HasKey("RowID");
            //});

            //modelBuilder.Entity<Contact>(t =>
            //{
            //    t.ToTable("contacts");
            //    t.HasKey("RowID");
            //});

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

            modelBuilder.Entity<Order>(t =>
            {
                //t.ToTable("orders");

                //t.HasKey("RowID");

                t.HasMany(x => x.OrderItems)
                    .WithOne(x => x.Order);

                t.HasMany(x => x.MovementHistories)
                    .WithOne(x => x.Order);

                t.Property(x => x.OrderType)
                    .HasConversion(new EnumToStringConverter<OrderType>());

                // entity value
                Expression<Func<string, OrderStatus>> stringToOrderStatus()
                {
                    return s => s == OrderStatus.Open.ToString() ? OrderStatus.Open :
                        s == OrderStatus.Close.ToString() ? OrderStatus.Close :
                        s == OrderStatus.Approved.ToString() ? OrderStatus.Approved :
                        s == OrderStatus.Delivery.ToString() ? OrderStatus.Delivery :
                        s == OrderStatus.Packing.ToString() ? OrderStatus.Packing :
                        s == "For Packing" ? OrderStatus.ForPacking :
                        s == "Pick Listed" ? OrderStatus.PickListed :
                        s == OrderStatus.New.ToString() ? OrderStatus.New :
                        s == "Lined Up" ? OrderStatus.LinedUp :
                        s == OrderStatus.Cancelled.ToString() ? OrderStatus.Cancelled :
                        s == OrderStatus.Received.ToString() ? OrderStatus.Received :
                        s == "For Approval" ? OrderStatus.ForApproval :
                        s == "Submitted To Warehouse" ? OrderStatus.SubmittedToWarehouse : default;
                }

                // database value
                Expression<Func<OrderStatus, string>> orderStatusToString()
                {
                    return os => os == OrderStatus.Open ? OrderStatus.Open.ToString() :
                        os == OrderStatus.Close ? OrderStatus.Close.ToString() :
                        os == OrderStatus.Approved ? OrderStatus.Approved.ToString() :
                        os == OrderStatus.Delivery ? OrderStatus.Delivery.ToString() :
                        os == OrderStatus.Packing ? OrderStatus.Packing.ToString() :
                        os == OrderStatus.ForPacking ? "For Packing" :
                        os == OrderStatus.PickListed ? "Pick Listed" :
                        os == OrderStatus.New ? OrderStatus.New.ToString() :
                        os == OrderStatus.LinedUp ? "Lined Up" :
                        os == OrderStatus.Cancelled ? OrderStatus.Cancelled.ToString() :
                        os == OrderStatus.Received ? OrderStatus.Received.ToString() :
                        os == OrderStatus.ForApproval ? "For Approval" :
                        os == OrderStatus.SubmittedToWarehouse ? "Submitted To Warehouse" : default;
                }

                var orderStatusConverter = new ValueConverter<OrderStatus, string>(convertToProviderExpression: orderStatusToString(),
                    convertFromProviderExpression: stringToOrderStatus());

                t.Property(x => x.Status)
                    .HasConversion(orderStatusConverter);

                t.HasOne(o => o.UserCreate)
                    .WithMany(u => u.OrdersCreate)
                    .HasForeignKey(o => o.CreatedBy)
                    .HasPrincipalKey(u => u.RowID);

                t.HasOne(o => o.UserUpdate)
                    .WithMany(u => u.OrdersUpdate)
                    .HasForeignKey(o => o.LastUpdBy)
                    .HasPrincipalKey(u => u.RowID);

                //t.Property(x => x.AgentId).HasColumnName("AgentID");

                //t.Ignore(o => o.DeletedMovementHistories);
            });

            modelBuilder.Entity<Lineup>(t =>
            {
                t.HasOne(x => x.Order)
                    .WithMany(x => x.Lineups);
            });

            modelBuilder.Entity<Product>(t =>
            {
                t.HasMany(x => x.ProductColors)
                    .WithOne(x => x.Product);

                t.HasOne(x => x.Category)
                    .WithMany(x => x.Products);

                t.Property(x => x.Status)
                    .HasConversion(new EnumToStringConverter<ProductStatus>());
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
                //t.ToTable("productcolorsizes");

                t.HasKey("RowID");

                t.HasMany(x => x.ProductInventoryLocations)
                    .WithOne(x => x.ProductColorSize);

                t.HasOne(x => x.ProductColor)
                    .WithMany(x => x.ProductColorSizes);

                t.HasMany(x => x.MovementHistories)
                    .WithOne(x => x.ProductColorSize);
            });

            modelBuilder.Entity<ProductInventoryLocation>(t =>
            {
                t.HasOne(x => x.ProductColorSize)
                    .WithMany(x => x.ProductInventoryLocations);

                t.HasOne(x => x.RackShelfColumn)
                    .WithMany(x => x.ProductInventoryLocations);

                t.HasMany(x => x.MovementHistories)
                    .WithOne(x => x.ProductInventoryLocation);
            });

            modelBuilder.Entity<RackShelfColumn>(t =>
            {
                t.HasMany(x => x.ProductInventoryLocations)
                    .WithOne(x => x.RackShelfColumn);

                t.Property(x => x.Status)
                    .HasConversion(new EnumToStringConverter<RackShelfColumnStatus>());
            });

            modelBuilder.Entity<SystemOwner>(t =>
            {
                var converter = new ValueConverter<bool, string>(convertToProviderExpression: b => b ? "1" : "0",
                    convertFromProviderExpression: s => s == "1" ? true : false);

                t.Property(x => x.IsCurrentOwner)
                    .HasConversion(converter);
            });

            modelBuilder.Entity<Contact>(t =>
            {
                t.Property(x => x.Type)
                    .HasConversion(new EnumToStringConverter<ContactType>());
            });

            modelBuilder.Entity<Lineup>(t =>
            {
                // entity value
                Expression<Func<string, LineupStatus>> stringToLineupStatus()
                {
                    return s => s == LineupStatus.Cancelled.ToString() ? LineupStatus.Cancelled : s == LineupStatus.Delivered.ToString() ? LineupStatus.Delivered : LineupStatus.ConfirmedDelivery;
                }

                // database value
                Expression<Func<LineupStatus, string>> lineupStatusToString()
                {
                    return l => l == LineupStatus.Cancelled ? LineupStatus.Cancelled.ToString() : l == LineupStatus.Delivered ? LineupStatus.Delivered.ToString() : "Confirmed Delivery";
                }

                var converter = new ValueConverter<LineupStatus, string>(convertToProviderExpression: lineupStatusToString(),
                    convertFromProviderExpression: stringToLineupStatus());

                t.Property(x => x.Status)
                    .HasConversion(converter);
            });

            modelBuilder.Entity<Position>(t =>
            {
                t.HasMany(x => x.PositionViews)
                    .WithOne(x => x.Position);
            });

            modelBuilder.Entity<PositionView>(t =>
            {
                var converter = new ValueConverter<bool, string>(convertToProviderExpression: b => b ? "Y" : "N",
                    convertFromProviderExpression: s => s == "Y" ? true : false);

                t.Property(x => x.Creates)
                    .HasConversion(converter);

                t.Property(x => x.ReadOnly)
                    .HasConversion(converter);

                t.Property(x => x.Updates)
                    .HasConversion(converter);

                t.Property(x => x.Disable)
                    .HasConversion(converter);
            });

            modelBuilder.Entity<User>(t =>
            {
                t.HasOne(x => x.Position)
                    .WithOne(x => x.User);

                //t.HasMany(u => u.OrdersCreate)
                //    .WithOne(o => o.UserCreate)
                //    .HasForeignKey(o => o.CreatedBy)
                //    .HasPrincipalKey(u => u.RowID);

                //t.HasMany(u => u.OrdersUpdate)
                //    .WithOne(o => o.UserUpdate)
                //    .HasForeignKey(o => o.LastUpdBy)
                //    .HasPrincipalKey(u => u.RowID);
            });

            modelBuilder.Entity<View>(t =>
            {
                t.HasKey(x => x.RowID);

                t.HasMany(x => x.PositionViews)
                    .WithOne(x => x.View);
            });
        }
    }
}