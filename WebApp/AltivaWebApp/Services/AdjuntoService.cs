using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.GEDomain;
using AltivaWebApp.Repositories;
namespace AltivaWebApp.Services
{
    public class AdjuntoService : IAdjuntoService
    {
        public IAdjuntoRepository AdjuntoRepository;

        public AdjuntoService(IAdjuntoRepository pAdjuntoRepository)
        {
            this.AdjuntoRepository = pAdjuntoRepository;
        }
        public void Crear(List<TbSeAdjunto> domain)
        {
             this.AdjuntoRepository.Crear(domain);
        }
    }
}
