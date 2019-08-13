using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
   public interface ICotizacionRepository
    {
        IList<TbFaCotizacion> GetInfoCotizacion();
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
