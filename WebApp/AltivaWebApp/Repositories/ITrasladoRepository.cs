using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//agregado por lenin
namespace AltivaWebApp.Repositories
{
    public interface ITrasladoRepository
    {
       
        TbPrTraslado Save(TbPrTraslado domain);
        TbPrTraslado Update(TbPrTraslado domain);
        bool Delete(TbPrTraslado domain);
        IList<TbPrTraslado> GetAllTraslado();
        TbPrTraslado GetTrasladoById(long id);
        IList<TbPrTrasladoInventario> SaveOrUpdateTrasladoInventario(IList<TbPrTrasladoInventario> domain);
        void DeleteTrasladoInventario(IList<long> domain);
        IList<TbPrTraslado> GetTrasladosSinAnular();

        TbPrTraslado GetTrasladoForKardex(int id, IList<long> idDetalles);

    }
}
