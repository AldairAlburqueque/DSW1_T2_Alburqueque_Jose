using DSW1_T2_Alburqueque_Jose.Domain.Entities;

namespace DSW1_T2_Alburqueque_Jose.Domain.Ports.Out
{
  public interface ILoanRepository : IRepository<Loan>
  {
    Task<IEnumerable<Loan>> GetActiveLoansByBookIdAsync(int bookId);
  }
}