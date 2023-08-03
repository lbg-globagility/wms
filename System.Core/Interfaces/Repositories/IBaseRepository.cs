namespace WarehouseManagementSystem.Core.Interfaces.Repositories
{
    public interface IBaseRepository
    {
        bool IsNewEntity(int? id);
    }
}