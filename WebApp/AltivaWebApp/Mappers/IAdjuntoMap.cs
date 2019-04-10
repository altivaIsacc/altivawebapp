using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.ViewModels;
using AltivaWebApp.GEDomain;
namespace AltivaWebApp.Mappers
{
   public interface IAdjuntoMap
    {
        TbSeAdjunto crear(int id, string ruta);
        TbSeAdjunto viewToModelAdjunto(int id, string ruta);

        TbSeAdjunto Adjunto(AdjuntoViewModel domain);
    }
}
