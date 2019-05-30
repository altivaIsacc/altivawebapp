using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Mappers
{
    public interface IHaciendaMap
    {
        TbCeColaAprobacion CreateCACompra(TbPrCompra domain);
    }
}
