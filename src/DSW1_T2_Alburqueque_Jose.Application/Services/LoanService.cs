using AutoMapper;
using DSW1_T2_Alburqueque_Jose.Application.DTOs;
using DSW1_T2_Alburqueque_Jose.Application.Interfaces;
using DSW1_T2_Alburqueque_Jose.Domain.Entities;
using DSW1_T2_Alburqueque_Jose.Domain.Ports.Out;

namespace DSW1_T2_Alburqueque_Jose.Application.Services
{
  public class LoanService : ILoanService
  {
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public LoanService(IUnitOfWork unit, IMapper mapper)
    {
      _unit = unit;
      _mapper = mapper;
    }


    // CREATE LOAN
    public async Task<LoanDto> CreateLoanAsync(CreateLoanDto dto)
    {
      var book = await _unit.Books.GetByIdAsync(dto.BookId)
          ?? throw new Exception("Libro no encontrado");

      if (book.Stock <= 0)
        throw new Exception("No se puede prestar. Stock agotado");

      // Reducir stock
      book.Stock--;
      await _unit.Books.UpdateAsync(book);

      // Crear préstamo
      var loan = _mapper.Map<Loan>(dto);

      await _unit.Loans.CreateAsync(loan);
      await _unit.SaveChangesAsync();

      return _mapper.Map<LoanDto>(loan);
    }


    // RETURN LOAN
    public async Task<LoanDto> ReturnLoanAsync(int loanId)
    {
      var loan = await _unit.Loans.GetByIdAsync(loanId)
          ?? throw new Exception("Préstamo no encontrado");

      if (loan.Status == "Returned")
        throw new Exception("El préstamo ya fue devuelto");

      loan.Status = "Returned";
      loan.ReturnDate = DateTime.Now;

      // Recuperar libro y aumentar stock
      var book = await _unit.Books.GetByIdAsync(loan.BookId)
          ?? throw new Exception("Libro no encontrado al devolver");

      book.Stock++;

      await _unit.Books.UpdateAsync(book);
      await _unit.Loans.UpdateAsync(loan);
      await _unit.SaveChangesAsync();

      return _mapper.Map<LoanDto>(loan);
    }

    // GET ALL
    public async Task<IEnumerable<LoanDto>> GetAllAsync()
    {
      var loans = await _unit.Loans.GetAllAsync();
      return _mapper.Map<IEnumerable<LoanDto>>(loans);
    }


    // GET BY ID
    public async Task<LoanDto?> GetByIdAsync(int id)
    {
      var loan = await _unit.Loans.GetByIdAsync(id);
      return loan == null ? null : _mapper.Map<LoanDto>(loan);
    }
  }
}
