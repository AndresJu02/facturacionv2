using Microsoft.AspNetCore.Mvc;
using FacturacionService.Models;

namespace FacturacionService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FacturasController : ControllerBase
    {
        private static List<Factura> facturas = new();

        [HttpPost]
        public IActionResult GenerarFactura([FromBody] Factura factura)
        {
            factura.IdFactura = facturas.Count + 1;
            facturas.Add(factura);
            return Ok(factura);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerFactura(int id)
        {
            var factura = facturas.FirstOrDefault(f => f.IdFactura == id);
            if (factura == null) return NotFound();
            return Ok(factura);
        }

        [HttpPut("{id}/pagar")]
        public IActionResult PagarFactura(int id)
        {
            var factura = facturas.FirstOrDefault(f => f.IdFactura == id);
            if (factura == null) return NotFound();
            factura.EstadoFactura = "Pagada";
            return Ok(factura);
        }

        [HttpPut("{id}/anular")]
        public IActionResult AnularFactura(int id)
        {
            var factura = facturas.FirstOrDefault(f => f.IdFactura == id);
            if (factura == null) return NotFound();
            factura.EstadoFactura = "Anulada";
            return Ok(factura);
        }
    }
}
