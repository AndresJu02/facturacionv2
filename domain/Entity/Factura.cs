namespace FacturacionService.Domain.Entity
{
    public class Factura
    {
        public int IdFactura { get; set; }
        public DateTime FechaFactura { get; set; } = DateTime.Now;
        public double MontoTotal { get; set; }
        public double ImpuestoAplicado { get; set; }
        public double? Descuento { get; set; }
        public string MetodoPago { get; set; } = string.Empty; // efectivo, tarjeta, transferencia
        public string EstadoFactura { get; set; } = "pendiente"; // pagada, pendiente, anulada
    }
}
