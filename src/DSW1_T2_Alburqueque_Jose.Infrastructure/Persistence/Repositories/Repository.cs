using DSW1_T2_Alburqueque_Jose.Domain.Ports.Out;
using DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Repositories
{
  public class Repository<T> : IRepository<T> where T : class
  {
    protected readonly ApplicationDbContext _context;
    protected readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
      _context = context;
      _dbSet = context.Set<T>();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
      return await _dbSet.FindAsync(id);
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
      return await _dbSet.ToListAsync();
    }

    public async Task<T> CreateAsync(T entity)
    {
      await _dbSet.AddAsync(entity);
      return entity;
    }

    public Task<T> UpdateAsync(T entity)
    {
      _dbSet.Update(entity);
      return Task.FromResult(entity);
    }

    public async Task<bool> DeleteAsync(int id)
    {
      var entity = await GetByIdAsync(id);
      if (entity == null) return false;

      _dbSet.Remove(entity);
      return true;
    }

    public async Task<bool> ExistsAsync(int id)
    {
      var entity = await GetByIdAsync(id);
      return entity != null;
    }
  }
}
