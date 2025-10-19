using Microsoft.AspNetCore.Mvc;
using FacturacionService.Domain.Entity;
using FacturacionService.Application.Service;

namespace FacturacionService.Adapter.restful.v1.Controller
{
    [ApiController]
    [Route("api/v1/facturas")]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaService _facturaService;

        public FacturasController(IFacturaService facturaService)
        {
            _facturaService = facturaService;
        }

        [HttpPost]
        public IActionResult CrearFactura([FromBody] Factura factura)
        {
            var nuevaFactura = _facturaService.GenerarFactura(factura);
            return Ok(nuevaFactura);
        }

        [HttpGet]
        public IActionResult ObtenerFacturas()
        {
            var facturas = _facturaService.ObtenerFacturas();
            return Ok(facturas);
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerFacturaPorId(int id)
        {
            var factura = _facturaService.ObtenerFacturaPorId(id);
            if (factura == null)
                return NotFound($"No se encontró la factura con ID {id}");
            return Ok(factura);
        }

        [HttpPut("anular/{id}")]
        public IActionResult AnularFactura(int id)
        {
            var resultado = _facturaService.AnularFactura(id);
            if (!resultado)
                return NotFound($"No se pudo anular la factura {id}");
            return Ok($"Factura {id} anulada correctamente.");
        }
    }
}
