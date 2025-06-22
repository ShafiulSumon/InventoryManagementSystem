using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Repositories.Interfaces;

namespace InventoryManagementSystem.Repositories.Implementations;

public class ProductRepository : Repository<ProductEntity>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
        
    }
}