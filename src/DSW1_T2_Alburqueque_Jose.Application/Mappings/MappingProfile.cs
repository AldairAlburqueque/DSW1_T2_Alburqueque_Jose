using AutoMapper;
using DSW1_T2_Alburqueque_Jose.Application.DTOs;
using DSW1_T2_Alburqueque_Jose.Domain.Entities;

namespace DSW1_T2_Alburqueque_Jose.Application.Mapping
{
  public class MappingProfile : Profile
  {
    public MappingProfile()
    {
      // BOOKS
      CreateMap<CreateBookDto, Book>()
          .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.Now));
      CreateMap<Book, BookDto>();

      // LOANS
      CreateMap<CreateLoanDto, Loan>()
          .ForMember(dest => dest.LoanDate, opt => opt.MapFrom(_ => DateTime.Now))
          .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => "Active"));
      CreateMap<Loan, LoanDto>();
    }
  }
}
