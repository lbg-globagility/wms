using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WarehouseManagementSystem.Core.Entities;
using WarehouseManagementSystem.Core.Interfaces.DomainServices.Base;

namespace WarehouseManagementSystem.Core.Interfaces.DomainServices
{
    public interface IPickListDataService : IBaseSavableDataService<PickList>
    {
        Task<PickList> GetByOrderIdAsync(int orderId);
    }
}
