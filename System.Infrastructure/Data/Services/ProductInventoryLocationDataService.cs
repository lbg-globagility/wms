using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces;
using WarehouseManagementSystem.Core.Interfaces.DomainServices;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Services.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Services
{
    public class ProductInventoryLocationDataService : BaseSavableDataService<ProductInventoryLocation>, IProductInventoryLocationDataService
    {
        public ProductInventoryLocationDataService(IProductInventoryLocationRepository productInventoryLocationRepository,
            IUserActivityRepository userActivityRepository,
            SystemContext context,
            IPolicyHelper policy) :

            base(productInventoryLocationRepository,
                userActivityRepository,
                context,
                policy,
                entityName: "ProductInventoryLocation")
        {
        }
    }
}