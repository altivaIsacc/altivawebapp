using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface ITrasladoService
    {

        IList<TbPrTraslado> GetAllTraslado();//si
        TbPrTraslado Save(TbPrTraslado domain);//si
        TbPrTraslado Update(TbPrTraslado domain);
        bool Delete(TbPrTraslado domain);     
        TbPrTraslado GetTrasladoById(long id);//si
        bool SaveTrasladoInventario(IList<TbPrTrasladoInventario> domain);//si
        bool UpdateTrasladoInventario(IList<TbPrTrasladoInventario> domain);//si
        void DeleteTrasladoInventario(IList<long> id);

        IList<TbPrTraslado> GetTrasladosSinAnular();
    }
}
