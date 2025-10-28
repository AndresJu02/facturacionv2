namespace FacturacionService.Domain.Utils
{
    public static class CalculosFactura
    {
        public static double CalcularImpuesto(double subtotal, double tasaImpuesto)
            => subtotal * tasaImpuesto;

        public static double CalcularTotal(double subtotal, double impuesto, double descuento = 0)
            => subtotal + impuesto - descuento;
    }
}
