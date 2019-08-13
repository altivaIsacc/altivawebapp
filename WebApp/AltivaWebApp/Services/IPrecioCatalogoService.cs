using AltivaWebApp.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltivaWebApp.Services
{
    public interface IPrecioCatalogoService
    {
        
      bool Update(IList<TbPrPrecioCatalogo> domain);
        IList<TbPrPrecioCatalogo> GetAll();
        TbPrPrecioCatalogo GetPrecioCatalogoById(int id);
        IList<TbPrPrecioCatalogo> GetAllPrecioCatalogo();

        bool SaveFromInventario(int idIventario);
         bool SaveFromPrecios(int idTipoPrecio);
        IList<TbPrPrecioCatalogo> GetPreciosWithReqs();
    }
}
