using InventoryManagementSystem.Data.UnitOfWork;
using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Services.Implementations;

public class ProductService : IProductService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProductService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    public async Task<IEnumerable<ProductEntity>> GetAllProductsAsync()
    {
        return await _unitOfWork.ProductRepository.GetAllAsync();
    }

    public async Task<List<ProductEntity>> GetFilteredProductsAsync(Category? category)
    {
        var query = _unitOfWork.ProductRepository.Query();
        if (category != null)
        {
            query = query.Where(x => x.Category == category);
        }

        return await query.ToListAsync();
    }

    public async Task<ProductEntity?> GetProductByIdAsync(int id)
    {
        return await _unitOfWork.ProductRepository.GetByIdAsync(id);
    }

    public async Task CreateProductAsync(ProductEntity product)
    {
        _unitOfWork.ProductRepository.Add(product);
        await _unitOfWork.SaveAsync();
    }

    public async Task UpdateProductAsync(ProductEntity product)
    {
        _unitOfWork.ProductRepository.Update(product);
        await _unitOfWork.SaveAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _unitOfWork.ProductRepository.GetByIdAsync(id);
        if (product != null)
        {
            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.SaveAsync();
        }
    }
}