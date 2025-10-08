namespace FacturacionService.Models;

public class Factura
{
    public int IdFactura { get; set; }
    public DateTime FechaFactura { get; set; } = DateTime.Now;
    public double MontoTotal { get; set; }
    public double ImpuestoAplicado { get; set; }
    public double? Descuento { get; set; }

    // Campos obligatorios
    public required string MetodoPago { get; set; }   // efectivo, tarjeta, transferencia
    public required string EstadoFactura { get; set; } // pagada, pendiente, anulada

    // Para detalle de producto
    public List<Producto> Productos { get; set; } = new();

    // --- Métodos ---
    public double CalcularSubtotal()
    {
        return Productos.Sum(p => p.PrecioUnitario * p.Cantidad);
    }

    public void AplicarDescuento(double descuento)
    {
        Descuento = descuento;
    }

    public double CalcularImpuesto(double porcentaje = 0.19)
    {
        var subtotal = CalcularSubtotal();
        ImpuestoAplicado = subtotal * porcentaje;
        return ImpuestoAplicado;
    }

    public double CalcularTotal()
    {
        var subtotal = CalcularSubtotal();
        var total = subtotal + ImpuestoAplicado - (Descuento ?? 0);
        MontoTotal = total;
        return MontoTotal;
    }

    public void RegistrarPago(string metodoPago)
    {
        MetodoPago = metodoPago;
        EstadoFactura = "Pagada";
    }

    public void AnularFactura()
    {
        EstadoFactura = "Anulada";
    }

    public string ImprimirFactura()
    {
        return $"Factura N° {IdFactura}\n" +
               $"Fecha: {FechaFactura}\n" +
               $"Productos: {Productos.Count}\n" +
               $"Total: {MontoTotal:C}\n" +
               $"Método de pago: {MetodoPago}\n" +
               $"Estado: {EstadoFactura}";
    }
}

public class Producto
{
    public int IdProducto { get; set; }
    public required string NombreProducto { get; set; } // 🔹 Obligatorio
    public double PrecioUnitario { get; set; }
    public int Cantidad { get; set; }
}
