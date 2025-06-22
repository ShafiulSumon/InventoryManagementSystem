using InventoryManagementSystem.Models.Entities;

namespace InventoryManagementSystem.Models.ViewModels;

public class ProductListViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Category Category { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string Status { get; set; }
}