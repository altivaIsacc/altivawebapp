using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IFamiliaRepository
    {
        TbPrFamilia GetFamiliaById(int id);
        TbPrFamilia Save(TbPrFamilia domain);
        TbPrFamilia Update(TbPrFamilia domain);
        bool Delete(TbPrFamilia domain);
        IList<TbPrFamilia> GetAll();
        IList<TbPrFamilia> GetAllFamilias();
        IList<TbPrFamilia> GetAllSubFamilias();
        void UpdateSubFamilia(IList<TbPrFamilia> subFamilias);
        TbPrFamilia GetFamiliaByDescripcion(string descripcion);
    }
}
