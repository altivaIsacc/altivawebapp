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
        IList<TbPrTraslado> GetAllTraslado();//si
        TbPrTraslado Save(TbPrTraslado domain);
        TbPrTraslado Update(TbPrTraslado domain);
        TbPrTraslado GetTrasladoById(long id);//si
        bool Delete(TbPrTraslado domain);            
        bool SaveTrasladoInventario(IList<TbPrTrasladoInventario> domain);//si
        void DeleteTrasladoInventario(IList<long> domain);
        bool UpdateTrasladoInventario(IList<TbPrTrasladoInventario> domain);//si

        IList<TbPrTraslado> GetTrasladosSinAnular();
    }
}
