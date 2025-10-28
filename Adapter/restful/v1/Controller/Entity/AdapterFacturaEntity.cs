using System;

namespace FacturacionService.Adapter.Entity
{
    public class AdapterFacturaEntity
    {
        public int IdFactura { get; set; }
        public int IdProducto { get; set; }
        public DateTime FechaFactura { get; set; }
        public string NombreProducto { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Descuento { get; set; }
        public decimal Subtotal { get; set; }
        public decimal IVA { get; set; }
        public decimal Total { get; set; }
        public string MetodoPago { get; set; } = string.Empty;
        public string EstadoFactura { get; set; } = string.Empty;
    }
}

