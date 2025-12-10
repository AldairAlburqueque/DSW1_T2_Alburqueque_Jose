using Microsoft.EntityFrameworkCore;
using DSW1_T2_Alburqueque_Jose.Domain.Entities;
using DSW1_T2_Alburqueque_Jose.Domain.Ports.Out;
using DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Context;

namespace DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Repositories
{
  public class BookRepository : Repository<Book>, IBookRepository
  {
    //private DbSet<Book> _dbSet;

    public BookRepository(ApplicationDbContext context) : base(context)
    {
      // _dbSet = context.Set<Book>();
    }

    /// <summary>
    /// Obtiene un libro por su ISBN
    /// </summary>
    public async Task<Book?> GetByISBNAsync(string isbn)
    {
      return await _dbSet
          .FirstOrDefaultAsync(b => b.ISBN == isbn);
    }

    /// <summary>
    /// Buscar libros por título o autor (opcional)
    /// </summary>
    public async Task<IEnumerable<Book>> SearchByTitleOrAuthorAsync(string query)
    {
      return await _dbSet
          .Where(b => EF.Functions.Like(b.Title, $"%{query}%") ||
                      EF.Functions.Like(b.Author, $"%{query}%"))
          .ToListAsync();
    }
  }
}
