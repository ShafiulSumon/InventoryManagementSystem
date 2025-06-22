namespace InventoryManagementSystem.Models.Entities;

public class ProductEntity : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public required Category Category { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
}