namespace DSW1_T2_Alburqueque_Jose.Domain.Entities
{
  public class Loan
  {
    public int Id { get; set; }
    public int BookId { get; set; }
    public string StudentName { get; set; } = string.Empty;
    public DateTime LoanDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string Status { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    // Navegación opcional (si usarás EF)
    public Book? Book { get; set; }
  }
}