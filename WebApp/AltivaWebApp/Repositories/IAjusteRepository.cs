using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface IAjusteRepository
    {
        TbPrAjuste Save(TbPrAjuste domain);
        TbPrAjuste Update(TbPrAjuste domain);
        bool Delete(TbPrAjuste domain);
        IList<TbPrAjuste> GetAllAjustes();
        TbPrAjuste GetAjusteById(int id);
        bool SaveAjusteInventario(IList<TbPrAjusteInventario> domain);
        void DeleteAjusteInventario(IList<long> domain);
        bool UpdateAjusteInventario(IList<TbPrAjusteInventario> domain);
        IList<TbCoCuentaContable> GetAllCC();
        IList<TbCoCentrosDeGastos> GetAllCG();

    }
}
