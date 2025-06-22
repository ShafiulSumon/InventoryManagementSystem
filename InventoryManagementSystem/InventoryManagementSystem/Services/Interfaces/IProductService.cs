using InventoryManagementSystem.Models.Entities;

namespace InventoryManagementSystem.Services.Interfaces;

public interface IProductService
{
    Task<IEnumerable<ProductEntity>> GetAllProductsAsync();
    Task<List<ProductEntity>> GetFilteredProductsAsync(Category? category);
    Task<ProductEntity?> GetProductByIdAsync(int id);
    Task CreateProductAsync(ProductEntity product);
    Task UpdateProductAsync(ProductEntity product);
    Task DeleteProductAsync(int id);
}