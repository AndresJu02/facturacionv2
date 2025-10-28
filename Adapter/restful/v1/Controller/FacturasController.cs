using Microsoft.AspNetCore.Mvc;
using FacturacionService.Application.Service;
using FacturacionService.Adapter.Entity;
using FacturacionService.Adapter.restful.v1.Mapper;
using System.Threading.Tasks;

namespace FacturacionService.Adapter.restful.v1.Controller
{
    [ApiController]
    [Route("api/v1/facturas")]
    public class FacturasController : ControllerBase
    {
        private readonly IFacturaService _service;
        private readonly IAdapterMapper _mapper;

        public FacturasController(IFacturaService service, IAdapterMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GenerarFactura([FromBody] AdapterFacturaEntity payload)
        {
            var domain = _mapper.ToDomain(payload);
            var saved = await _service.GenerarFacturaAsync(domain);
            var dto = _mapper.ToAdapter(saved);
            return CreatedAtAction(nameof(ObtenerFacturaPorId), new { id = dto.IdFactura }, dto);
        }

        [HttpGet]
        public async Task<IActionResult> ObtenerFacturas()
        {
            var list = await _service.ObtenerFacturasAsync();
            return Ok(_mapper.ToAdapterList(list));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> ObtenerFacturaPorId(int id)
        {
            var f = await _service.ObtenerFacturaPorIdAsync(id);
            if (f == null) return NotFound();
            return Ok(_mapper.ToAdapter(f));
        }

        [HttpPut("anular/{id:int}")]
        public async Task<IActionResult> AnularFactura(int id)
        {
            var ok = await _service.AnularFacturaAsync(id);
            if (!ok) return NotFound();
            return Ok(new { message = $"Factura {id} anulada" });
        }
    }
}
