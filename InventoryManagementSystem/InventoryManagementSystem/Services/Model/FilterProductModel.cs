using InventoryManagementSystem.Models.Entities;

namespace InventoryManagementSystem.Services.Model;

public class FilterProductModel
{
    public Category? category { get; set; }
    public string? search { get; set; }
}