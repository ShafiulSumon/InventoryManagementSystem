namespace InventoryManagementSystem.Utils;

public class StockHelper
{
    public static string CurrentStock(int Quantity) => Quantity == 0 ? ConstantMessage.OutOfStock : (Quantity <= 5) ? ConstantMessage.LowStock : ConstantMessage.InStock;
}