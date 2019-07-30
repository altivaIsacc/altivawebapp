using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IFamiliaOnlineService
    {
        TbPrFamiliaVentaOnline Save(TbPrFamiliaVentaOnline domain);
        TbPrFamiliaVentaOnline Update(TbPrFamiliaVentaOnline domain);
        bool Delete(TbPrFamiliaVentaOnline domain);
        IList<TbPrFamiliaVentaOnline> GetAll();
        TbPrFamiliaVentaOnline GetFamiliaById(int id);
        IList<TbPrFamiliaVentaOnline> GetAllFamilias();
        IList<TbPrFamiliaVentaOnline> GetAllSubFamilias();
        void UpdateSubFamilia(IList<TbPrFamiliaVentaOnline> subFamilias);
        TbPrFamiliaVentaOnline GetFamiliaByDescripcion(string descripcion);
    }
}
