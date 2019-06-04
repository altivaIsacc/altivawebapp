using AltivaWebApp.Domains;
using AltivaWebApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public class CotizacionDetalleService:ICotizacionDetalleService
    {
        private readonly ICotizacionDetalleRepository cotizacionDetalleRepository ;

        public IList<TbFaCotizacionDetalle> GetAll()
        {
            return cotizacionDetalleRepository.GetAll();
        }
    }
}
