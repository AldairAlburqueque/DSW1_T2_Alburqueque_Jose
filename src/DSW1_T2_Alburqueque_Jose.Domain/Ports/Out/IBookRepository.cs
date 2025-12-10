using DSW1_T2_Alburqueque_Jose.Domain.Entities;

namespace DSW1_T2_Alburqueque_Jose.Domain.Ports.Out
{
  public interface IBookRepository : IRepository<Book>
  {
    Task<Book?> GetByISBNAsync(string isbn);
  }
}