using WarehouseManagementSystem.Core.Entities;
using static WarehouseManagementSystem.Core.Helpers.ProgressGenerator;

namespace WarehouseManagementSystem.Core.Interfaces
{
    public interface IPickListAutomationResult : IResult
    {
        string No { get; }

        string Name { get; }

        int Id { get; }

        string Description { get; }

        PickListOrderItem PickListOrderItem { get; }
    }
}
