using FacturacionService.Adapter.Entity;
using FacturacionService.Domain.Entity;
using System.Collections.Generic;

namespace FacturacionService.Adapter.restful.v1.Mapper
{
    public interface IAdapterMapper
    {
        AdapterFacturaEntity ToAdapter(Factura f);
        List<AdapterFacturaEntity> ToAdapterList(IEnumerable<Factura> list);
        Factura ToDomain(AdapterFacturaEntity dto);
    }
}
