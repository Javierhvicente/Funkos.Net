using System.Text;
using Funkos.Net.Database;
using Microsoft.EntityFrameworkCore;
using Serilog;

Console.OutputEncoding = Encoding.UTF8;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";
Console.WriteLine($"Environment: {environment}");

var configuration = new ConfigurationBuilder()
    .AddJsonFile($"logger.{environment}.json", optional: false, reloadOnChange: true)
    .Build();

var logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

var builder =
    WebApplication
        .CreateBuilder(args);
        
builder.Services.AddLogging(logging =>
{
    logging.ClearProviders(); // Limpia los proveedores de log por defecto
    logging.AddSerilog(logger, true); // Añade Serilog como un proveedor de log
});
logger.Debug("Serilog added as default logger");
builder.Services.AddDbContext<FunkoDbContext>(options =>
    {
        options.UseInMemoryDatabase("Funkos")
            // Disable log
            .EnableSensitiveDataLogging(); // Habilita el registro de datos sensibles
        logger.Debug("In-memory database added");
    }
);
logger.Debug("Heroes in-memory database added");   

builder.Services.AddMemoryCache();

builder.Services.AddControllers();
logger.Debug("Controllers added");     