using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AltivaWebApp.Domains;
using AltivaWebApp.GEDomain;

namespace AltivaWebApp.Services
{
   public interface ICajaService
    {
        IList<TbFaCaja> GetInfoCaja();
        TbFaCaja Save(TbFaCaja domain);
        TbFaCaja Update(TbFaCaja domain);
        IList<TbFaCaja> GetAllCajas();
        TbFaCaja GetCajaById(int id);
        bool UpdateCajaAperturaDenominacion(IList<TbFaCajaAperturaDenominacion> domain);
        TbFaCajaAperturaDenominacion SaveCajaAperturaDenominacion(TbFaCajaAperturaDenominacion domain);
        IList<TbFaCajaAperturaDenominacion> GetAllCajaAperturaDenominacionByIdCaja(int id);

    }
}
