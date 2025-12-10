using Microsoft.EntityFrameworkCore;
using DSW1_T2_Alburqueque_Jose.Domain.Entities;
using DSW1_T2_Alburqueque_Jose.Domain.Ports.Out;
using DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Context;

namespace DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Repositories
{
  public class LoanRepository : Repository<Loan>, ILoanRepository
  {
    //private DbSet<Loan> _dbSet;

    public LoanRepository(ApplicationDbContext context) : base(context)
    {
      // _dbSet = context.Set<Loan>();
    }

    /// <summary>
    /// Obtiene todos los préstamos activos de un libro específico
    /// </summary>
    public async Task<IEnumerable<Loan>> GetActiveLoansByBookIdAsync(int bookId)
    {
      return await _dbSet
          .Where(l => l.BookId == bookId && l.Status == "Active")
          .ToListAsync();
    }

    /// <summary>
    /// Obtener préstamo con información del libro (opcional si agregas navegación)
    /// </summary>
    public async Task<Loan?> GetWithBookAsync(int id)
    {
      return await _dbSet
          .Include(l => l.Book) // requiere que agregues propiedad Book en Loan
          .FirstOrDefaultAsync(l => l.Id == id);
    }

    /// <summary>
    /// Buscar préstamos activos de un estudiante (opcional)
    /// </summary>
    public async Task<IEnumerable<Loan>> GetActiveLoansByStudentAsync(string studentName)
    {
      return await _dbSet
          .Where(l => l.StudentName == studentName && l.Status == "Active")
          .ToListAsync();
    }
  }
}
