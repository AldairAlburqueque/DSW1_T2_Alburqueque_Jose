using Microsoft.EntityFrameworkCore;
using DSW1_T2_Alburqueque_Jose.Domain.Entities;
using DSW1_T2_Alburqueque_Jose.Domain.Ports.Out;
using DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Context;

namespace DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Repositories
{
  public class LoanRepository : Repository<Loan>, ILoanRepository
  {

    public LoanRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Loan>> GetActiveLoansByBookIdAsync(int bookId)
    {
      return await _dbSet
          .Where(l => l.BookId == bookId && l.Status == "Active")
          .ToListAsync();
    }

    public async Task<Loan?> GetWithBookAsync(int id)
    {
      return await _dbSet
          .Include(l => l.Book)
          .FirstOrDefaultAsync(l => l.Id == id);
    }


    public async Task<IEnumerable<Loan>> GetActiveLoansByStudentAsync(string studentName)
    {
      return await _dbSet
          .Where(l => l.StudentName == studentName && l.Status == "Active")
          .ToListAsync();
    }
  }
}
