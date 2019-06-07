using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IFamiliaOnlineRepository
    {
        TbPrFamiliaVentaOnline GetFamiliaById(int id);
        TbPrFamiliaVentaOnline Save(TbPrFamiliaVentaOnline domain);
        TbPrFamiliaVentaOnline Update(TbPrFamiliaVentaOnline domain);
        bool Delete(TbPrFamiliaVentaOnline domain);
        IList<TbPrFamiliaVentaOnline> GetAll();
        IList<TbPrFamiliaVentaOnline> GetAllFamilias();
        IList<TbPrFamiliaVentaOnline> GetAllSubFamilias();
        void UpdateSubFamilia(IList<TbPrFamiliaVentaOnline> subFamilias);
    }
}
