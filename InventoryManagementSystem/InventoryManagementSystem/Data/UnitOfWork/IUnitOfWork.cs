using InventoryManagementSystem.Repositories.Interfaces;

namespace InventoryManagementSystem.Data.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IProductRepository ProductRepository { get; }
    Task<int> SaveAsync();
}