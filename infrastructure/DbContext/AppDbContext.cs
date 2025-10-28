using Microsoft.EntityFrameworkCore;
using FacturacionService.Domain.Entity;

namespace FacturacionService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Factura> Facturas { get; set; }
    }
}
