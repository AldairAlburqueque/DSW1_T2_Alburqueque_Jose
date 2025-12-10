using DSW1_T2_Alburqueque_Jose.Application.DTOs;

namespace DSW1_T2_Alburqueque_Jose.Application.Interfaces
{
  public interface IBookService
  {
    Task<BookDto> CreateAsync(CreateBookDto dto);
    Task<IEnumerable<BookDto>> GetAllAsync();
    Task<BookDto?> GetByIdAsync(int id);

    Task<BookDto?> UpdateAsync(int id, CreateBookDto dto);
    Task<bool> DeleteAsync(int id);
  }
}
