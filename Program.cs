using Microsoft.EntityFrameworkCore;
using FacturacionService.Infrastructure.Data;
using FacturacionService.Application.Service;
using FacturacionService.Domain;
using FacturacionService.Adapter.restful.v1.Mapper;


var builder = WebApplication.CreateBuilder(args);

// Agregar controladores
builder.Services.AddControllers();

// Documentación Swagger (puedes quitarlo si no lo necesitas)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuración del DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 32)) // Usa tu versión de MySQL
    ));

// Inyección de dependencias
builder.Services.AddScoped<IFacturaService, FacturaServiceImp>();
builder.Services.AddScoped<IAdapterMapper, AdapterMapper>();


// Configuración del pipeline
var app = builder.Build();

// Swagger solo en entorno de desarrollo
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirección HTTPS y mapeo de controladores
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
