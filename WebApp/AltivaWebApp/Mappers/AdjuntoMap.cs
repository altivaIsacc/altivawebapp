using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.ViewModels;

namespace AltivaWebApp.Mappers
{
    public class AdjuntoMap : IAdjuntoMap
    {
        public TbSeAdjunto crear( int id, string ruta)
        {
            return viewToModelAdjunto(id,ruta);
        }

        public TbSeAdjunto viewToModelAdjunto(int id,string ruta)
        {
            AdjuntoViewModel domain = new AdjuntoViewModel
            {
              IdMensaje =id,
              Ruta = ruta,
              Estado = true
            };

            return Adjunto(domain);
        }

        public TbSeAdjunto Adjunto(AdjuntoViewModel domain)
        {
            TbSeAdjunto aj = new TbSeAdjunto
            {
                IdMensaje = domain.IdMensaje,
                Ruta = domain.Ruta,
                Estado =domain.Estado

            };
            return aj;
        }
    }
}
