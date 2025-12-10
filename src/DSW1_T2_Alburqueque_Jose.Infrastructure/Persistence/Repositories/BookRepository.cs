using Microsoft.EntityFrameworkCore;
using DSW1_T2_Alburqueque_Jose.Domain.Entities;
using DSW1_T2_Alburqueque_Jose.Domain.Ports.Out;
using DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Context;

namespace DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Repositories
{
  public class BookRepository : Repository<Book>, IBookRepository
  {

    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<Book?> GetByISBNAsync(string isbn)
    {
      return await _dbSet
          .FirstOrDefaultAsync(b => b.ISBN == isbn);
    }

    public async Task<IEnumerable<Book>> SearchByTitleOrAuthorAsync(string query)
    {
      return await _dbSet
          .Where(b => EF.Functions.Like(b.Title, $"%{query}%") ||
                      EF.Functions.Like(b.Author, $"%{query}%"))
          .ToListAsync();
    }
  }
}
