namespace FacturacionService.Domain.Utils
{
    public static class CalculosFactura
    {
        public static double CalcularImpuesto(double subtotal, double tasa)
        {
            return subtotal * tasa;
        }

        public static double CalcularTotal(double subtotal, double impuesto, double descuento = 0)
        {
            return subtotal + impuesto - descuento;
        }
    }
}
