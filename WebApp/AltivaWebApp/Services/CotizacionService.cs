using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class CotizacionService:ICotizacionService
    {
        private readonly ICotizacionRepository repository;

        public CotizacionService(ICotizacionRepository cotizacionRepository)
        {
            repository = cotizacionRepository;
        }

        public IList<TbFaCotizacion> GetAll()
        {
            return repository.GetAll();
        }
 
        public IList< TbFaCotizacion> GetInfoCotizacion()
        {
            return repository.GetInfoCotizacion();
        }

    }
}
