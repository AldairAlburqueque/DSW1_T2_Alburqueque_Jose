using AutoMapper;
using DSW1_T2_Alburqueque_Jose.Application.DTOs;
using DSW1_T2_Alburqueque_Jose.Application.Interfaces;
using DSW1_T2_Alburqueque_Jose.Domain.Entities;
using DSW1_T2_Alburqueque_Jose.Domain.Ports.Out;

namespace DSW1_T2_Alburqueque_Jose.Application.Services
{
  public class BookService : IBookService
  {
    private readonly IUnitOfWork _unit;
    private readonly IMapper _mapper;

    public BookService(IUnitOfWork unit, IMapper mapper)
    {
      _unit = unit;
      _mapper = mapper;
    }

    public async Task<BookDto> CreateAsync(CreateBookDto dto)
    {
      // ISBN único
      var existing = await _unit.Books.GetByISBNAsync(dto.ISBN);
      if (existing != null)
        throw new Exception("El ISBN ya está registrado");

      var book = _mapper.Map<Book>(dto);
      await _unit.Books.CreateAsync(book);
      await _unit.SaveChangesAsync();

      return _mapper.Map<BookDto>(book);
    }

    public async Task<IEnumerable<BookDto>> GetAllAsync()
    {
      var books = await _unit.Books.GetAllAsync();
      return _mapper.Map<IEnumerable<BookDto>>(books);
    }

    public async Task<BookDto?> GetByIdAsync(int id)
    {
      var book = await _unit.Books.GetByIdAsync(id);
      return _mapper.Map<BookDto>(book);
    }
  }
}
