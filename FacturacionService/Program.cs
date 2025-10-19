using FacturacionService.Application.Service;

var builder = WebApplication.CreateBuilder(args);

// Servicios base
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Inyección de dependencias
builder.Services.AddScoped<IFacturaService, FacturaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
    
        c.RoutePrefix = string.Empty;
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "FacturacionService v1");
    });
}


app.UseHttpsRedirection();
app.MapControllers();
app.Run();
