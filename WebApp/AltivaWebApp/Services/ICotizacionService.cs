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
       IList< TbFaCotizacion> GetInfoCotizacion();
        TbFaCotizacion Save(TbFaCotizacion domain);
        TbFaCotizacion Update(TbFaCotizacion domain);
        IList<TbFaCotizacion> GetAllCotizacion();
        TbFaCotizacion GetCotizacionById(int id);
        IList<TbFaCotizacionDetalle> GetAllCotizacionDetalleByIdCotizacion(int id);
        TbFaCotizacionDetalle SaveCotizacionDetalle(TbFaCotizacionDetalle domain);
        bool DeleteCotizacionDetalle(TbFaCotizacionDetalle domain);
        bool UpdateCotizacionDetalle(IList<TbFaCotizacionDetalle> domain);
        TbFaCotizacionDetalle GetCotizacionDetalleById(long id);
    }
}
