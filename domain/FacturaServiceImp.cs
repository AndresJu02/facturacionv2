using FacturacionService.Application.Service;
using FacturacionService.Domain.Entity;
using FacturacionService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacturacionService.Domain
{
    public class FacturaServiceImp : IFacturaService
    {
        private readonly AppDbContext _db;

        public FacturaServiceImp(AppDbContext db)
        {
            _db = db;
        }

        public async Task<Factura> GenerarFacturaAsync(Factura factura)
        {
            factura.FechaFactura = DateTime.Now;

         
            factura.Subtotal = factura.Cantidad * factura.Precio;

            const decimal IVA_PORCENTAJE = 19m;
            factura.IVA = factura.Subtotal * (IVA_PORCENTAJE / 100);

        
            factura.Total = factura.Subtotal + factura.IVA - factura.Descuento;

            factura.EstadoFactura = "Pendiente";

            _db.Facturas.Add(factura);
            await _db.SaveChangesAsync();

            return factura;
        }

        public async Task<IEnumerable<Factura>> ObtenerFacturasAsync()
        {
            return await _db.Facturas
                .AsNoTracking()
                .OrderByDescending(f => f.FechaFactura)
                .ToListAsync();
        }

        public Task<Factura?> ObtenerFacturaPorIdAsync(int id)
        {
            return _db.Facturas
                .AsNoTracking()
                .FirstOrDefaultAsync(f => f.IdFactura == id);
        }

        public async Task<bool> AnularFacturaAsync(int id)
        {
            var factura = await _db.Facturas.FindAsync(id);
            if (factura == null) return false;

            factura.EstadoFactura = "Anulada";
            _db.Facturas.Update(factura);

            return await _db.SaveChangesAsync() > 0;
        }
    }
}
