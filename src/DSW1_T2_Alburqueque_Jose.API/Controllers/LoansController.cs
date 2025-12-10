using Microsoft.AspNetCore.Mvc;
using DSW1_T2_Alburqueque_Jose.Application.DTOs;
using DSW1_T2_Alburqueque_Jose.Application.Interfaces;

namespace DSW1_T2_Alburqueque_Jose.API.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class LoansController : ControllerBase
  {
    private readonly ILoanService _loanService;

    public LoansController(ILoanService loanService)
    {
      _loanService = loanService;
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var loans = await _loanService.GetAllAsync();
      return Ok(loans);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
      var loan = await _loanService.GetByIdAsync(id);
      if (loan == null)
        return NotFound();
      return Ok(loan);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLoanDto dto)
    {
      try
      {
        var created = await _loanService.CreateLoanAsync(dto);
        return Ok(created);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }

    [HttpPost("{id:int}/return")]
    public async Task<IActionResult> Return(int id)
    {
      try
      {
        var returnedLoan = await _loanService.ReturnLoanAsync(id);
        return Ok(returnedLoan);
      }
      catch (Exception ex)
      {
        return BadRequest(new { message = ex.Message });
      }
    }
  }
}
