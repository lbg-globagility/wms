using System;
using System.Collections.Generic;
using System.Text;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.Repositories;
using WarehouseManagementSystem.Infrastructure.Data.Repositories.Base;

namespace WarehouseManagementSystem.Infrastructure.Data.Repositories
{
    public class PickListOrderRepository : SavableRepository<PickListOrder>, IPickListOrderRepository
    {
        public PickListOrderRepository(SystemContext context) : base(context)
        {
        }
    }
}
