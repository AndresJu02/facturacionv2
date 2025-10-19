using FacturacionService.Domain.Entity;
using FacturacionService.Domain.Utils;

namespace FacturacionService.Application.Service
{
    public class FacturaService : IFacturaService
    {
        private readonly List<Factura> _facturas = new();

        public Factura GenerarFactura(Factura factura)
        {
            factura.IdFactura = _facturas.Count + 1;

            double subtotal = factura.MontoTotal;
            double impuesto = CalculosFactura.CalcularImpuesto(subtotal, 0.19); // IVA por defecto
            factura.ImpuestoAplicado = impuesto;
            factura.MontoTotal = CalculosFactura.CalcularTotal(subtotal, impuesto, factura.Descuento ?? 0);

            _facturas.Add(factura);
            return factura;
        }

        public IEnumerable<Factura> ObtenerFacturas()
        {
            return _facturas;
        }

        public Factura? ObtenerFacturaPorId(int id)
        {
            return _facturas.FirstOrDefault(f => f.IdFactura == id);
        }

        public bool AnularFactura(int id)
        {
            var factura = _facturas.FirstOrDefault(f => f.IdFactura == id);
            if (factura == null) return false;

            factura.EstadoFactura = "anulada";
            return true;
        }
    }
}
