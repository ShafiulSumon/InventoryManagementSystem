using InventoryManagementSystem.Repositories.Interfaces;

namespace InventoryManagementSystem.Data.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;

    public UnitOfWork(AppDbContext context, IProductRepository productRepository)
    {
        _context = context;
        ProductRepository = productRepository;
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }

    public IProductRepository ProductRepository { get; }
    
    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }
}