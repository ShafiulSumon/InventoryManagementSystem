using InventoryManagementSystem.Data.UnitOfWork;
using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Services.Interfaces;
using InventoryManagementSystem.Services.Model;
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

    public async Task<List<ProductEntity>> GetFilteredProductsAsync(FilterProductModel filter)
    {
        var query = _unitOfWork.ProductRepository.Query();
        query = query.Where(x => !x.IsDeleted);
        query = query.OrderBy(x => x.Id);
        if (filter.category != null)
        {
            query = query.Where(x => x.Category == filter.category);
        }

        if (!string.IsNullOrEmpty(filter.search))
        {
            query = query.Where(x => x.Name.Contains(filter.search));
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
            // doing soft delete
            product.IsDeleted = true;
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.SaveAsync();
        }
    }
}