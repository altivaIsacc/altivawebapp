using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;

namespace AltivaWebApp.Services
{
    public class CotizacionConfigService
    {
        private readonly ICotizacionRepository repository;

        public IList<TbFaCotizacion> GetAll()
        {
            return repository.GetAll();
        }
    }
}
