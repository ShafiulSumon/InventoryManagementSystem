using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Models.ViewModels;
using InventoryManagementSystem.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    // GET
    public async Task<IActionResult> Index([FromQuery] Category? category)
    {
        var products = await _productService.GetFilteredProductsAsync(category);
        var productsViewModel = new List<ProductListViewModel>();
        foreach (var data in products)
        {
            string status = data.Quantity switch
            {
                0 => "Out of Stock",
                <= 5 => "Low Stock",
                _ => "In Stock"
            };
            productsViewModel.Add(new ProductListViewModel
            {
                Id = data.Id,
                Name = data.Name,
                Category = data.Category,
                Price = data.Price,
                Quantity = data.Quantity,
                Status = status
            });
        }
        return View(productsViewModel);
    }
}