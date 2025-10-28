using FacturacionService.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FacturacionService.Application.Service
{
    public interface IFacturaService
    {
        Task<Factura> GenerarFacturaAsync(Factura factura);
        Task<IEnumerable<Factura>> ObtenerFacturasAsync();
        Task<Factura?> ObtenerFacturaPorIdAsync(int id);
        Task<bool> AnularFacturaAsync(int id);
    }
}
