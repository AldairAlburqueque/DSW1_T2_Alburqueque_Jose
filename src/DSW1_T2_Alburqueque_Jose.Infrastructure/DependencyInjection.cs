using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DSW1_T2_Alburqueque_Jose.Domain.Ports.Out;
using DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Context;
using DSW1_T2_Alburqueque_Jose.Infrastructure.Persistence.Repositories;

namespace DSW1_T2_Alburqueque_Jose.Infrastructure
{
  public static class DependencyInjection
  {
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
      // Leer variables de entorno para la conexión
      var host = Environment.GetEnvironmentVariable("DB_HOST");
      var port = Environment.GetEnvironmentVariable("DB_PORT");
      var database = Environment.GetEnvironmentVariable("DB_NAME");
      var user = Environment.GetEnvironmentVariable("DB_USER");
      var password = Environment.GetEnvironmentVariable("DB_PASSWORD");

      var connectionString = $"Server={host};Port={port};Database={database};User={user};Password={password};";

      Console.WriteLine($"Connection String: {connectionString}");

      // Registrar DbContext
      services.AddDbContext<ApplicationDbContext>(options =>
          options.UseMySql(
              connectionString,
              new MySqlServerVersion(new Version(8, 0, 0))
          )
      );

      // Registrar repositorios y UnitOfWork
      services.AddScoped<IBookRepository, BookRepository>();
      services.AddScoped<ILoanRepository, LoanRepository>();
      services.AddScoped<IUnitOfWork, UnitOfWork>();

      return services;
    }
  }
}
