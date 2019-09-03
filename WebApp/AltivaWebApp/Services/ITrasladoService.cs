using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface ITrasladoService
    {
        TbPrTraslado Save(TbPrTraslado domain);//si
        TbPrTraslado Update(TbPrTraslado domain);
        bool Delete(TbPrTraslado domain);
        IList<TbPrTraslado> GetAllTraslado();//si          
        TbPrTraslado GetTrasladoById(long id);//si
        IList<TbPrTrasladoInventario> SaveOrUpdateTrasladoInventario(IList<TbPrTrasladoInventario> domain);
        void DeleteTrasladoInventario(IList<long> id);

        IList<TbPrTraslado> GetTrasladosSinAnular();
    }
}
