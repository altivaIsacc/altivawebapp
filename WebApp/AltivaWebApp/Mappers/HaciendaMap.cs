using AltivaWebApp.Domains;
using AltivaWebApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public class HaciendaMap: IHaciendaMap
    {
        private readonly IHaciendaService service; 

        public HaciendaMap(IHaciendaService service)
        {
            this.service = service;
        }

        public TbCeColaAprobacion CreateCACompra(TbPrCompra domain)
        {
            return service.SaveCA(FromCompraToCA(domain, "X"));
        }

        public TbCeColaAprobacion FromCompraToCA(TbPrCompra domain, string estado)
        {
            return new TbCeColaAprobacion
            {
                Estado = "X",
                Fecha = DateTime.Now,
                FechaDoc = domain.FechaDocumento,
                IdDoc = domain.Id,
                MontoDoc = domain.TotalBase,
                NumDoc = domain.NumeroDocumento,
                TipoDoc = "COMPRA",
                Anulado = domain.Anulado
            };
        }

    }
}
