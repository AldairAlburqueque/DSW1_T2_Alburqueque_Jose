using Microsoft.Extensions.DependencyInjection;
using DSW1_T2_Alburqueque_Jose.Application.Interfaces;
using DSW1_T2_Alburqueque_Jose.Application.Services;
using DSW1_T2_Alburqueque_Jose.Application.Mapping;

namespace DSW1_T2_Alburqueque_Jose.Application
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
      // Registrar AutoMapper
      services.AddAutoMapper(typeof(MappingProfile));

      // Registrar servicios
      services.AddScoped<IBookService, BookService>();
      services.AddScoped<ILoanService, LoanService>();

      return services;
    }
  }
}
