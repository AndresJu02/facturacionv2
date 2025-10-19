using FacturacionService.Domain.Entity;

namespace FacturacionService.Application.Service
{
    public interface IFacturaService
    {
        Factura GenerarFactura(Factura factura);
        IEnumerable<Factura> ObtenerFacturas();
        Factura? ObtenerFacturaPorId(int id);
        bool AnularFactura(int id);
    }
}
