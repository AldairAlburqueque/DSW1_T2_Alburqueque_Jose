namespace DSW1_T2_Alburqueque_Jose.Domain.Ports.Out
{
  public interface IUnitOfWork
  {
    IBookRepository Books { get; }
    ILoanRepository Loans { get; }

    Task<int> SaveChangesAsync();
  }
}