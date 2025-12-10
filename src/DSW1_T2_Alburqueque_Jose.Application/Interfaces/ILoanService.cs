using DSW1_T2_Alburqueque_Jose.Application.DTOs;

namespace DSW1_T2_Alburqueque_Jose.Application.Interfaces
{
  public interface ILoanService
  {
    Task<IEnumerable<LoanDto>> GetAllAsync();
    Task<LoanDto> CreateLoanAsync(CreateLoanDto dto);
    Task<LoanDto> ReturnLoanAsync(int id);
    Task<LoanDto?> GetByIdAsync(int id);
  }
}
