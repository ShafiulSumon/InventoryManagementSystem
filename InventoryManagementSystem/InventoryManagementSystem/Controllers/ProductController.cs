using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Models.ViewModels;
using InventoryManagementSystem.Services.Interfaces;
using InventoryManagementSystem.Services.Model;
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
    public async Task<IActionResult> Index([FromQuery] FilterProductModel filter)
    {
        var products = await _productService.GetFilteredProductsAsync(filter);
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

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm]ProductEntity product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }
        await _productService.CreateProductAsync(product);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Details(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpPost]
    public async Task<IActionResult> Edit([FromForm] ProductEntity product)
    {
        if (!ModelState.IsValid)
        {
            return View(product);
        }
        await _productService.UpdateProductAsync(product);
        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int id)
    {
        var product = await _productService.GetProductByIdAsync(id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        await _productService.DeleteProductAsync(id);
        return RedirectToAction("Index");
    }
}