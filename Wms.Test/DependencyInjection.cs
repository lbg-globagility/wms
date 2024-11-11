using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Infrastructure.Data;
using WarehouseManagementSystem.Infrastructure.Data.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services;

namespace Wms.Test
{
    public abstract class DependencyInjection
    {
        private const string CONNECTION_STRING = "server=localhost; user id=root; password=globagility; database=wmsdb_thurston; port=3306; default command timeout=240;";

        public DependencyInjection()
        {
            ConfigureDependencyInjection();
        }

        public ServiceProvider MainServiceProvider { get; private set; }

        private void ConfigureDependencyInjection()
        {
            var services = new ServiceCollection();

            ConfigureServices(services);

            MainServiceProvider = services.BuildServiceProvider();
        }

        private void ConfigureServices(ServiceCollection services)
        {
            services.AddDbContext<SystemContext>(options =>
            {
                options.UseMySql(connectionString: CONNECTION_STRING)//, serverVersion: ServerVersion.AutoDetect(CONNECTION_STRING)
                .EnableSensitiveDataLogging()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
            });

            services.AddScoped<IAccountDataService, AccountDataService>();
            services.AddScoped<ICartonSizeDataService, CartonSizeDataService>();
            services.AddScoped<ICategoryDataService, CategoryDataService>();
            services.AddScoped<IColorDataService, ColorDataService>();
            services.AddScoped<IContactDataService, ContactDataService>();
            services.AddScoped<IInventoryLocationDataService, InventoryLocationDataService>();
            services.AddScoped<ILineupDataService, LineupDataService>();
            services.AddScoped<IMovementHistoryDataService, MovementHistoryDataService>();
            services.AddScoped<IOrderDataService, OrderDataService>();
            services.AddScoped<IOrderItemDataService, OrderItemDataService>();
            services.AddScoped<IPackingListDataService, PackingListDataService>();
            services.AddScoped<IPackingListCartonDataService, PackingListCartonDataService>();
            services.AddScoped<IPickListOrderItemDataService, PickListOrderItemDataService>();
            services.AddScoped<IPickListOrderDataService, PickListOrderDataService>();
            services.AddScoped<IPickListDataService, PickListDataService>();
            services.AddScoped<IPositionViewDataService, PositionViewDataService>();
            services.AddScoped<IProductDataService, ProductDataService>();
            services.AddScoped<IProductColorDataService, ProductColorDataService>();
            services.AddScoped<IProductColorSizeDataService, ProductColorSizeDataService>();
            services.AddScoped<IProductInventoryLocationDataService, ProductInventoryLocationDataService>();
            services.AddScoped<IRackShelfColumnDataService, RackShelfColumnDataService>();
            services.AddScoped<ISystemOwnerService, SystemOwnerService>();

            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<ICartonSizeRepository, CartonSizeRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IInventoryLocationRepository, InventoryLocationRepository>();
            services.AddScoped<ILineupRepository, LineupRepository>();
            services.AddScoped<IMovementHistoryRepository, MovementHistoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IPackingListRepository, PackingListRepository>();
            services.AddScoped<IPackingListCartonRepository, PackingListCartonRepository>();
            services.AddScoped<IPickListOrderItemRepository, PickListOrderItemRepository>();
            services.AddScoped<IPickListOrderRepository, PickListOrderRepository>();
            services.AddScoped<IPickListRepository, PickListRepository>();
            services.AddScoped<IPositionViewRepository, PositionViewRepository>();
            services.AddScoped<IProductColorRepository, ProductColorRepository>();
            services.AddScoped<IProductColorSizeRepository, ProductColorSizeRepository>();
            services.AddScoped<IProductInventoryLocationRepository, ProductInventoryLocationRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IRackShelfColumnRepository, RackShelfColumnRepository>();
            services.AddScoped<ISystemInfoRepository, SystemInfoRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserActivityRepository, UserActivityRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IListOfValueRepository, ListOfValueRepository>();

            services.AddScoped<IPolicyHelper, PolicyHelper>();
            services.AddScoped<IPickListAutomator, PickListAutomator>();
        }
    }
}
