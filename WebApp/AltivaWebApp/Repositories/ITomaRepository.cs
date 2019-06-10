using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Repositories
{
    public interface ITomaRepository
    {
        TbPrToma Save(TbPrToma domain);
        TbPrToma Update(TbPrToma domain);
        IList<TbPrToma> GetAll();
        TbPrToma GetTomaByID(long id);
        IList<TbPrTomaDetalle> GetDetallesByTomaId(long id);
        IList<TbPrTomaDetalle> GetAllDetalleByIdD(IList<int> domain);
        IList<TbPrTomaDetalle> SaveTomaDetalle(IList<TbPrTomaDetalle> domain);
        IList<TbPrTomaDetalle> EliminarTomaDetalle(IList<TbPrTomaDetalle> domain);
        IList<TbPrTomaDetalle> UpdateTomaDetalle(IList<TbPrTomaDetalle> domain);
        IList<TbPrToma> GetAllTomaConBodega();
        IList<TbPrTomaDetalle> GenerateTD(TbPrToma domain);
        bool ExisteTomaInicial();
        IList<TbPrToma> GetCombinables(int idBodega);
        TbPrToma CombinarTomas(int id, IList<int> domain);
    }
}
