using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Repositories
{
   public interface IAdjuntoRepository
    {
        void Crear(List<TbSeAdjunto> pAdjunto);
    }
}
