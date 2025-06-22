using InventoryManagementSystem.Data;
using InventoryManagementSystem.Models.Entities;
using InventoryManagementSystem.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Repositories.Implementations;

public class Repository<T> :  IRepository<T> where T : BaseEntity
{
    private readonly DbSet<T> _dbSet;
    
    public Repository(AppDbContext context)
    {
        _dbSet = context.Set<T>();
    }
    
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Add(T entity)
    {
        _dbSet.Add(entity);
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public IQueryable<T> Query()
    {
        return _dbSet.AsQueryable().AsNoTracking();
    }
}