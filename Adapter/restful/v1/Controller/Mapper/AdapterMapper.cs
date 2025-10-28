using FacturacionService.Adapter.Entity;
using FacturacionService.Domain.Entity;
using System.Collections.Generic;
using System.Linq;

namespace FacturacionService.Adapter.restful.v1.Mapper
{
    public class AdapterMapper : IAdapterMapper
    {
        // ✅ Convierte una Factura del dominio a una entidad adaptadora
        public AdapterFacturaEntity ToAdapter(Factura f) => new()
        {
            IdFactura = f.IdFactura,
            IdProducto = f.IdProducto,
            FechaFactura = f.FechaFactura,
            NombreProducto = f.NombreProducto,
            Cantidad = f.Cantidad,
            Precio = f.Precio,
            Descuento = f.Descuento,
            Subtotal = f.Subtotal,
            IVA = f.IVA,
            Total = f.Total,
            MetodoPago = f.MetodoPago,
            EstadoFactura = f.EstadoFactura
        };

        // ✅ Convierte una lista de Facturas a lista de AdapterFacturaEntity
        public List<AdapterFacturaEntity> ToAdapterList(IEnumerable<Factura> list) =>
            list?.Select(ToAdapter).ToList() ?? new List<AdapterFacturaEntity>();

        // ✅ Convierte una entidad adaptadora (DTO) a una Factura de dominio
        public Factura ToDomain(AdapterFacturaEntity dto) => new()
        {
            IdFactura = dto.IdFactura,
            IdProducto = dto.IdProducto,
            FechaFactura = dto.FechaFactura,
            NombreProducto = dto.NombreProducto,
            Cantidad = dto.Cantidad,
            Precio = dto.Precio,
            Descuento = dto.Descuento,
            Subtotal = dto.Subtotal,
            IVA = dto.IVA,
            Total = dto.Total,
            MetodoPago = dto.MetodoPago,
            EstadoFactura = dto.EstadoFactura
        };
    }
}
