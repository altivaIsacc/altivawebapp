using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Services
{
    public interface ICotizacionService
    {
        IList<TbFaCotizacion> GetAll();
       IList< TbFaCotizacion> GetInfoCotizacion();
    }
}
