using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models.Entities;

public class BaseModel
{
    [Key]
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public bool IsDeleted { get; set; } = false;
}