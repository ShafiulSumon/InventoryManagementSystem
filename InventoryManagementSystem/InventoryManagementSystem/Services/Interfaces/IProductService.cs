using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Services.Model;

namespace InventoryManagementSystem.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
    Task<List<ProductEntity>> GetFilteredProductsAsync(FilterProductModel filter);
    Task<ProductEntity?> GetProductByIdAsync(int id);
    Task CreateProductAsync(ProductEntity product);
    Task UpdateProductAsync(ProductEntity product);
    Task DeleteProductAsync(int id);
}