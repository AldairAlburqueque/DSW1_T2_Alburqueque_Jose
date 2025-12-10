using Microsoft.AspNetCore.Mvc;
using DSW1_T2_Alburqueque_Jose.Application.DTOs;
using DSW1_T2_Alburqueque_Jose.Application.Interfaces;

namespace DSW1_T2_Alburqueque_Jose.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
      _bookService = bookService;
    }

    // GET api/books
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var books = await _bookService.GetAllAsync();
      return Ok(books);
    }

    // GET api/books/5
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
      var book = await _bookService.GetByIdAsync(id);
      if (book == null)
        return NotFound();
      return Ok(book);
    }

    // POST api/books
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBookDto dto)
    {
      try
      {
        var created = await _bookService.CreateAsync(dto);
        return Ok(created);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }
  }
}
