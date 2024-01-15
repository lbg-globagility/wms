Option Strict On

Imports Microsoft.EntityFrameworkCore
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Logging
Imports Microsoft.Extensions.Logging.Console
Imports WarehouseManagementSystem.Core.Interfaces
Imports WarehouseManagementSystem.Core.Interfaces.DomainServices
Imports WarehouseManagementSystem.Core.Interfaces.Excel
Imports WarehouseManagementSystem.Core.Interfaces.Repositories
Imports WarehouseManagementSystem.Infrastructure.Data
Imports WarehouseManagementSystem.Infrastructure.Data.Repositories
Imports WarehouseManagementSystem.Infrastructure.Data.Services
Imports WarehouseManagementSystem.Infrastructure.Excel

Public Class DependencyInjectionHelper

    Public Shared Sub ConfigureDependencyInjection()
        Dim services = New ServiceCollection()

        ConfigureServices(services)

        MainServiceProvider = services.BuildServiceProvider()
    End Sub

    Private Shared Sub ConfigureServices(services As ServiceCollection)
        services.AddDbContext(Of SystemContext)(
            Sub(options As DbContextOptionsBuilder)
                ConfigureDbContextOptions(options:=options)
            End Sub,
            ServiceLifetime.Transient)

        With services
            'Data Services
            .AddTransient(Of IAccountDataService, AccountDataService)
            .AddTransient(Of ICartonSizeDataService, CartonSizeDataService)
            .AddTransient(Of ICategoryDataService, CategoryDataService)
            .AddTransient(Of IColorDataService, ColorDataService)
            .AddTransient(Of IContactDataService, ContactDataService)
            .AddTransient(Of IInventoryLocationDataService, InventoryLocationDataService)
            .AddTransient(Of ILineupDataService, LineupDataService)
            .AddTransient(Of IMovementHistoryDataService, MovementHistoryDataService)
            .AddTransient(Of IOrderDataService, OrderDataService)
            .AddTransient(Of IOrderItemDataService, OrderItemDataService)
            .AddTransient(Of IPackingListDataService, PackingListDataService)
            .AddTransient(Of IPackingListCartonDataService, PackingListCartonDataService)
            .AddTransient(Of IPickListOrderItemDataService, PickListOrderItemDataService)
            .AddTransient(Of IPickListOrderDataService, PickListOrderDataService)
            .AddTransient(Of IPickListDataService, PickListDataService)
            .AddTransient(Of IPositionViewDataService, PositionViewDataService)
            .AddTransient(Of IProductDataService, ProductDataService)
            .AddTransient(Of IProductColorDataService, ProductColorDataService)
            .AddTransient(Of IProductInventoryLocationDataService, ProductInventoryLocationDataService)
            .AddTransient(Of IRackShelfColumnDataService, RackShelfColumnDataService)
            .AddTransient(Of ISystemOwnerService, SystemOwnerService)

            ' Repositories
            .AddTransient(Of IAccountRepository, AccountRepository)
            .AddTransient(Of ICartonSizeRepository, CartonSizeRepository)
            .AddTransient(Of ICategoryRepository, CategoryRepository)
            .AddTransient(Of IColorRepository, ColorRepository)
            .AddTransient(Of IContactRepository, ContactRepository)
            .AddTransient(Of IInventoryLocationRepository, InventoryLocationRepository)
            .AddTransient(Of ILineupRepository, LineupRepository)
            .AddTransient(Of IMovementHistoryRepository, MovementHistoryRepository)
            .AddTransient(Of IOrderRepository, OrderRepository)
            .AddTransient(Of IOrderItemRepository, OrderItemRepository)
            .AddTransient(Of IPackingListRepository, PackingListRepository)
            .AddTransient(Of IPackingListCartonRepository, PackingListCartonRepository)
            .AddTransient(Of IPickListOrderItemRepository, PickListOrderItemRepository)
            .AddTransient(Of IPickListOrderRepository, PickListOrderRepository)
            .AddTransient(Of IPickListRepository, PickListRepository)
            .AddTransient(Of IPositionViewRepository, PositionViewRepository)
            .AddTransient(Of IProductColorRepository, ProductColorRepository)
            .AddTransient(Of IProductColorSizeRepository, ProductColorSizeRepository)
            .AddTransient(Of IProductInventoryLocationRepository, ProductInventoryLocationRepository)
            .AddTransient(Of IProductRepository, ProductRepository)
            .AddTransient(Of IRackShelfColumnRepository, RackShelfColumnRepository)
            .AddTransient(Of IUserRepository, UserRepository)
            .AddTransient(Of IUserActivityRepository, UserActivityRepository)
            .AddTransient(Of IOrderRepository, OrderRepository)
            .AddTransient(Of IListOfValueRepository, ListOfValueRepository)

            .AddTransient(Of IPolicyHelper, PolicyHelper)

            .AddTransient(GetType(IExcelParser(Of)), GetType(ExcelParser(Of)))
        End With
    End Sub

    Private Shared Sub ConfigureDbContextOptions(options As DbContextOptionsBuilder)
        Dim manager As New sqlModule.Manager
        options.UseMySql(connectionString:=manager.GetConnString)
        'UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)

        If Debugger.IsAttached Then

            Dim dbCommandConsoleLoggerFactory As New LoggerFactory({
                New ConsoleLoggerProvider(
                    Function(category, level)
                        Return category = DbLoggerCategory.Database.Command.Name AndAlso
                            level = LogLevel.Information
                    End Function, True)
                })

            options = options.
                EnableSensitiveDataLogging().
                UseLoggerFactory(dbCommandConsoleLoggerFactory)
        End If
    End Sub

End Class